namespace MCarDealer.Infrastructure.Extensions
{
   public static class StringExtensions
   {
      public static string ToPrice(this decimal text)
      {
         return $"{text:F2} $";
      }

      public static string ToPercentage(this double text)
      { 
         return $"{text:F2} %";
      }
   }
}
