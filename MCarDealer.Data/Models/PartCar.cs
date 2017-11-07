namespace MCarDealer.Data.Models
{
   public class PartCar
   {
      public int Id { get; set; }

      public int Part_Id { get; set; }

      public Part Part { get; set; }

      public int Car_Id { get; set; }

      public Car Car { get; set; }
   }
}
