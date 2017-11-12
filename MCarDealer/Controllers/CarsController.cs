namespace MCarDealer.Controllers
{
   using Microsoft.AspNetCore.Mvc;
   using Models.Cars;
   using Services;



   [Route("cars")]
   public class CarsController : Controller
   {
      private readonly ICarService cars;

      public CarsController( ICarService cars) 
      {
         this.cars = cars;
      }

      [Route("all")]
      public IActionResult All()
         => View(this.cars.All());

      [Route("{make}" , Order = 2)]
      public IActionResult ByMake(string make)
      {
         var cars = this.cars.ByMake(make);

         return View(new CarsByMakeModel
         {
            Make = make,
            Cars = cars
         });
      }

      [Route("parts",Order = 1)]
      public IActionResult Parts()
      {
         return View(this.cars.WithParts());
      }
   }
}
