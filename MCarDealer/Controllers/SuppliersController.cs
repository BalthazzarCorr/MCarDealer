namespace MCarDealer.Controllers
{
   using Microsoft.AspNetCore.Mvc;
   using Microsoft.CodeAnalysis.CSharp.Syntax;
   using Models.Suppliers;
   using Services;

   public class SuppliersController : Controller
   {
      private const string SupplierView = "Suppliers";

      private readonly ISupplierService suppliers;

      public SuppliersController(ISupplierService suppliers)
      {
         this.suppliers = suppliers;
      }


      public IActionResult Local()
                => View(SupplierView, this.GetSuppliersModel(false));



      public IActionResult Importers()
            => View(SupplierView, this.GetSuppliersModel(true));


      private SuppliersModel GetSuppliersModel(bool importers)
      {
         var type = importers ? "Importer" : "Local";

         var suppliers = this.suppliers.All(importers);

         return new SuppliersModel
         {
            Type = type,
            Suppliers = suppliers

         };
      }
   }
}
