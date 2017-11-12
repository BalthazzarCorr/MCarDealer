namespace MCarDealer.Controllers
{
   using Infrastructure.Extensions;
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

      [Route(nameof(Create))]
      public IActionResult Create() => View();


      [HttpPost]
      [Route(nameof(Create))]
      public IActionResult Create(CustomerFormModel model)
      {
         if (!ModelState.IsValid)
         {
            return View(model);
         }

         this.customers.Create(
            model.Name,
            model.BirthDate,
            model.IsYoungDriver
            );
         return this.RedirectToAction(nameof(All),new {order = OrderDirection.Ascending});
      }


      [Route(nameof(Edit) + "/{id}")]
      public IActionResult Edit(int id)
      {
         var customer = this.customers.Edit(id);

         if (customer == null)
         {
            return NotFound();
         }

         var customerExists = this.customers.Exists(id);

         if (!customerExists)
         {
            return NotFound();
         }

         return View(new CustomerFormModel
         {
            Name = customer.Name,
            BirthDate = customer.BirthDate,
            IsYoungDriver = customer.IsYoungDriver
         });
      }



      [Route(nameof(Edit) + "/{id}")]
      [HttpPost]
      public IActionResult Edit(int id , CustomerFormModel model)
      {
         if (!ModelState.IsValid)
         {
            return View(model);
         }

         this.customers.Edit(
            id,
            model.Name,
            model.BirthDate,
            model.IsYoungDriver
         );
         return this.RedirectToAction(nameof(All), new {order = OrderDirection.Ascending});
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
            => this.ViewOrNotFound(this.customers.TotalSales(id));

   }
}
