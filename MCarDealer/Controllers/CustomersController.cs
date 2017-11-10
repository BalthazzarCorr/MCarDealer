namespace MCarDealer.Controllers
{
   using Microsoft.AspNetCore.Mvc;
   using Models.Customers;
   using Services;
   using Services.Models;

   [Route("customers")]
   public class CustomersController : Controller
   {
      private readonly ICustomerService customers;

      public CustomersController(ICustomerService customers)
      {
         this.customers = customers;
      }

      [Route("all/{order}")]
      public IActionResult All(string order)
      {
         var orderDirection = order.ToLower() == "ascending" ? OrderDirection.Ascending : OrderDirection.Descending;


         var customers = this.customers.OrderdCustomers(orderDirection);

         return View(new AllCustomerModel
         {
            Customers = customers,
            OrderDirection = orderDirection
         });
      }

      [Route("{id}")]
      public IActionResult TotalSales(int id)
         => View(this.customers.TotalSales(id));
   }
}
