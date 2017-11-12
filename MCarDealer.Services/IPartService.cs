namespace MCarDealer.Services
{
   using System.Collections.Generic;
   using Models.Parts;

   public interface IPartService
   {
     IEnumerable<PartListingModel> All(int page = 1);
   }
}
