namespace MCarDealer.Services
{
   using System.Collections.Generic;
   using Models;
   using Models.Suppliers;

   public interface ISupplierService
   {
      IEnumerable<SupplierListingModel> AllListings(bool isImporter);

      IEnumerable<SupplierModel> All();
   }
}
