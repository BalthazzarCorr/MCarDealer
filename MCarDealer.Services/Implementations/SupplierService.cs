namespace MCarDealer.Services.Implementations
{
   using System.Collections.Generic;
   using System.Linq;
   using Data;
   using Models.Suppliers;

   public class SupplierService : ISupplierService
   {
      private readonly CarDealerDbContext db;

      public SupplierService(CarDealerDbContext db)
      {
         this.db = db;
      }

      public IEnumerable<SupplierListingModel> AllListings(bool isImporter)
         => this.db
            .Suppliers
            .OrderByDescending(s=>s.Id)
            .Where(c => c.IsImporter == isImporter)
            .Select(c => new SupplierListingModel()
            {
               Id = c.Id,
               Name = c.Name,
               TotalParts = c.Parts.Count
            }).ToList();



      public IEnumerable<SupplierModel> All()
         => this.db
            .Suppliers
            .OrderBy(s => s.Name)
            .Select(s => new SupplierModel
            {
               Id = s.Id,
               Name = s.Name,

            }).ToList();
   }
}
