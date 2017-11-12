namespace MCarDealer.Services.Implementations
{
   using System.Collections.Generic;
   using System.Linq;
   using Data;
   using Models.Parts;

   public class PartService : IPartService
   {
      private const int PageSize = 25;
      private readonly CarDealerDbContext db;

      public PartService(CarDealerDbContext db)
      {
         this.db = db;
      }

      public IEnumerable<PartListingModel> All(int page = 1)
         => this.db
            .Parts
            .OrderByDescending(p=>p.Id)
            .Skip((page-1)* PageSize)
            .Take(PageSize)
            .Select(p => new PartListingModel
            {
               Id = p.Id,
               Name = p.Name,
               Price = p.Price,
               Quantity = p.Quantity,
               SupplierName = p.Supplier.Name
            }).ToList();
   }
}
