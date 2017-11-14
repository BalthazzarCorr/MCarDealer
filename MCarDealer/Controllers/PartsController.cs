namespace MCarDealer.Controllers
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Linq;
   using Microsoft.AspNetCore.Mvc;
   using Microsoft.AspNetCore.Mvc.Rendering;
   using Models.Parts;
   using Services;

   public class PartsController : Controller
   {
      private const int PageSize = 25;

      private readonly IPartService parts;
      private readonly ISupplierService suppliers;

      public PartsController(IPartService parts, ISupplierService suppliers)
      {
         this.suppliers = suppliers;
         this.parts = parts;
      }


      public IActionResult Create() => View(new PartFormModel
      {
         AllSuppliers = this.GetSupplierListItems()
      });


      [HttpPost]
      public IActionResult Create(PartFormModel model)
      {
         if (!ModelState.IsValid)
         {
            model.AllSuppliers = this.GetSupplierListItems();
            return View(model);
         }

         this.parts.Create(
            model.Name,
            model.Price,
            model.Quantity,
            model.Supplier_Id
         );

         return RedirectToAction(nameof(All));
      }

      public IActionResult All(int page = 1)
         => View(new PartsPageListingModel
         {
            Parts = this.parts.All(page, PageSize),
            CurrentPage = page,
            TotalPages = (int)Math.Ceiling(this.parts.Total() / (double)PageSize)
         });

      private IEnumerable<SelectListItem> GetSupplierListItems() => this.suppliers.All()
         .Select(s => new SelectListItem
         {
            Text = s.Name,
            Value = s.Id.ToString()
         });
   }
}