namespace MCarDealer.Services.Implementations
{
   using System.Collections.Generic;
   using System.Linq;
   using Data;
   using Models.Cars;
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
         .OrderByDescending(s=>s.Id)
         .Select(s => new SaleListModel
         {
            Id = s.Id,
            CustomerName = s.Customer.Name,
            IsYoungDriver = s.Customer.IsYoungDriver,
            Discount = s.Discount,
            Price = s.Car.Parts.Sum(p => p.Part.Price)

         })
         .ToList();


      public SaleDetailsModel Details(int id)
         => this.db
            .Sales.Where(s => s.Id == id).Select(s => new SaleDetailsModel
            {
               Id = s.Id,
               CustomerName = s.Customer.Name,
               IsYoungDriver = s.Customer.IsYoungDriver,
               Discount = s.Discount,
               Price = s.Car.Parts.Sum(p => p.Part.Price),
               Car = new CarModel
               {
                  Model = s.Car.Model,
                  Make = s.Car.Make,
                  TravelledDistance = s.Car.TravelledDistance
               }

            }).FirstOrDefault();


      public IEnumerable<SaleListModel> Discounted()
         => this.db.Sales.Where(s => s.Discount > 0).Select(s => new SaleListModel
         {
            Id = s.Id,
            CustomerName = s.Customer.Name,
            IsYoungDriver = s.Customer.IsYoungDriver,
            Discount = s.Discount,
            Price = s.Car.Parts.Sum(p => p.Part.Price),

         }).ToList();

      public IEnumerable<SaleListModel> DiscountByPercent(double percent)
         => this.db.Sales.Where(s => s.Discount == percent).Select(s => new SaleListModel
         {
            Id = s.Id,
            CustomerName = s.Customer.Name,
            IsYoungDriver = s.Customer.IsYoungDriver,
            Discount = s.Discount,
            Price = s.Car.Parts.Sum(p => p.Part.Price),

         }).ToList();
   };
}
