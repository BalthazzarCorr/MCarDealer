namespace MCarDealer.Controllers
{
   using Microsoft.AspNetCore.Mvc;
   using Microsoft.AspNetCore.Mvc.ViewEngines;
   using Services;

 
   public class SalesContoller : Controller
   {
      private readonly ISaleService sales;

      public SalesContoller(ISaleService sales)
      {
         this.sales = sales;
      }

      [Route("sales")]
      public IActionResult All()
         => View(this.sales.All());
      
   }
}
