namespace MCarDealer.Services.Implementations
{
   using System.Collections.Generic;
   using System.Linq;
   using Data;
   using Models;

   public class SupplierService : ISupplierService
   {
      private readonly CarDealerDbContext db;

      public SupplierService(CarDealerDbContext db)
      {
         this.db = db;
      }

      public IEnumerable<SupplierModel> All(bool isImporter)
         => this.db
            .Suppliers
            .OrderByDescending(s=>s.Id)
            .Where(c => c.IsImporter == isImporter)
            .Select(c => new SupplierModel
            {
               Id = c.Id,
               Name = c.Name,
               TotalParts = c.Parts.Count
            }).ToList();
   }
}
