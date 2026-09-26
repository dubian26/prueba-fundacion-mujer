using System.Linq.Expressions;
using System.Reflection;

namespace MyCatalog.Base.Extensions;

public static class ExpressionExtensions
{
    public static MemberInfo? GetMember<T, TProperty>(this Expression<Func<T, TProperty>> expression)
    {
        if (RemoveUnary(expression.Body) is not MemberExpression memberExp)
            return null;

        Expression? currentExpr = memberExp.Expression;

        // Unwind the expression to get the root object that
        // the expression acts upon.
        while (true)
        {
            currentExpr = RemoveUnary(currentExpr);

            if (currentExpr != null && currentExpr.NodeType == ExpressionType.MemberAccess)
            {
                currentExpr = ((MemberExpression)currentExpr).Expression;
            }
            else
            {
                break;
            }
        }

        if (currentExpr is null || currentExpr.NodeType != ExpressionType.Parameter)
            return null; // We don't care if we're not acting upon the model instance.

        return memberExp.Member;
    }

    private static Expression? RemoveUnary(Expression? toUnwrap)
    {
        if (toUnwrap is UnaryExpression expression)
            return expression.Operand;

        return toUnwrap;
    }
}
