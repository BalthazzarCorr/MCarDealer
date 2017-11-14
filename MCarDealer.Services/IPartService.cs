namespace MCarDealer.Services
{
   using System.Collections.Generic;
   using Models.Parts;

   public interface IPartService
   {
      IEnumerable<PartListingModel> All(int page = 1, int pageSize = 10);

      int Total();

      void Create(string modelName, decimal modelPrice, int modelQuantity, int modelSupplierId);
   }
}
