namespace MyCatalog.Base.Models;

public sealed class Result<T>
{
   public int TotalReg { get; set; } = 0;
   public IEnumerable<T> Data { get; set; } = [];

   public Result(T data)
   {
      TotalReg = 1;
      Data = [data];
   }

   public Result(IEnumerable<T> data)
   {
      TotalReg = data.Count();
      Data = data;
   }

   public Result(IEnumerable<T> data, int totalReg)
   {
      TotalReg = totalReg;
      Data = data;
   }

   public static Result<T> Empty() =>
      new([], 0);
}
