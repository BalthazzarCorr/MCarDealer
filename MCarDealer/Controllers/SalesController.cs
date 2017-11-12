namespace MCarDealer.Controllers
{
   using System.Globalization;
   using Infrastructure.Extensions;
   using Microsoft.AspNetCore.Mvc;
   using Services;

   [Route("sales")]
   public class SalesController : Controller
   {
      private readonly ISaleService sales;

      public SalesController(ISaleService sales)
      {
         this.sales = sales;
      }

     
      [Route("all")]
      public IActionResult All()
         => View(this.sales.All());

      [Route("{id}")]
      public IActionResult Details(int id)
         => this.ViewOrNotFound(this.sales.Details(id));


      [Route("discounted")]
      public IActionResult Discounted()
         => View(this.sales.Discounted());

      [Route("discounted/{percent}")]
      public IActionResult DiscountedByPercent(double percent)
         => View(this.sales.DiscountByPercent(percent));

   }
}
