namespace MCarDealer.Controllers
{
   using Microsoft.AspNetCore.Mvc;
   using Services;

   public class PartsController : Controller
   {
      private readonly IPartService parts;

      public PartsController(IPartService parts)
      {
         this.parts = parts;
      }

      public IActionResult All(int page = 1)
         => View(this.parts.All(page));

   }
}
