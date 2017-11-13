namespace MCarDealer.Controllers
{
   using System;
   using Microsoft.AspNetCore.Mvc;
   using Models.Parts;
   using Services;

   public class PartsController : Controller
   {
      private const int PageSize = 25;

      private readonly IPartService parts;

      public PartsController(IPartService parts)
      {
         this.parts = parts;
      }


      public IActionResult Create() => View();

      public IActionResult All(int page = 1)
         => View( new PartsPageListingModel
         {
            Parts = this.parts.All(page,PageSize),
            CurrentPage = page,
            TotalPages = (int)Math.Ceiling(this.parts.Total()/(double)PageSize)
         });
   }
}