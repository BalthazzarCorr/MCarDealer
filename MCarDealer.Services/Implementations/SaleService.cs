namespace MCarDealer.Services.Implementations
{
   using System.Collections.Generic;
   using System.Linq;
   using Data;
   using Models.Sales;

   public class SaleService : ISaleService
   {
      private readonly CarDealerDbContext db;

      public SaleService(CarDealerDbContext db)
      {
         this.db = db;
      }

      public IEnumerable<SaleListModel> All()
         => this.db
         .Sales
         .Select(s => new SaleListModel
         {
            CustomerName = s.Customer.Name,
            IsYoungDriver = s.Customer.IsYoungDriver,
            Discount = s.Discount,
            Price = s.Car.Parts.Sum(p => p.Part.Price)

         })
         .ToList();

   }
}
