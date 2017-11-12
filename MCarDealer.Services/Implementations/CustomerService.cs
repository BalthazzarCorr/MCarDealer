namespace MCarDealer.Services.Implementation
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using Data;
   using Data.Models;
   using Models;
   using Models.Customers;
   using Models.Sales;

   public class CustomerService : ICustomerService
   {
      private readonly CarDealerDbContext db;

      public CustomerService(CarDealerDbContext db)
      {
         this.db = db;
      }


      public void Create(string name, DateTime birthdate, bool isYoungDriver)
      {
         var customer = new Customer
         {
            Name = name,
            BirthDate = birthdate,
            IsYoungDriver = isYoungDriver
         };

         this.db.Add(customer);
         this.db.SaveChanges();
      }

      public CustomerModel Edit(int id)
         => this.db
            .Customers
            .Where(c => c.Id == id)
            .Select(c => new CustomerModel
            {
               Id = c.Id,
               Name = c.Name,
               BirthDate = c.BirthDate,
               IsYoungDriver = c.IsYoungDriver,
            }).FirstOrDefault();

      public void Edit(int id, string name, DateTime birthDate, bool isYoungDriver)
      {
         var existingCustomer = this.db.Customers.Find(id);

         if (existingCustomer == null)
         {
            return;
         }

         existingCustomer.Name = name;
         existingCustomer.BirthDate = birthDate;
         existingCustomer.IsYoungDriver = isYoungDriver;

         this.db.SaveChanges();
      }

      public bool Exists(int id) => this.db.Customers.Any(c => c.Id == id);
      


      public IEnumerable<CustomerModel> OrderdCustomers(OrderDirection order)
      {
         var customerQuery = this.db.Customers.AsQueryable();

         switch (order)
         {
            case OrderDirection.Ascending:
               customerQuery = customerQuery.OrderBy(c => c.BirthDate).ThenBy(c => c.Name);
               break;
            case OrderDirection.Descending:
               customerQuery = customerQuery.OrderByDescending(c => c.BirthDate).ThenBy(c => c.Name);
               break;
            default:
               throw new InvalidOperationException($"Invalid order direction {order}");
         }

         return customerQuery.Select(c => new CustomerModel
         {
            Id = c.Id,
            Name = c.Name,
            BirthDate = c.BirthDate,
            IsYoungDriver = c.IsYoungDriver
         }).ToList();
      }

      public CustomerTotalSalesModel TotalSales(int id)
      {
         return this.db
            .Customers
            .Where(c => c.Id == id)
            .Select(c => new CustomerTotalSalesModel
            {
               Name = c.Name,
               IsYoungDriver = c.IsYoungDriver,
               BoughtCars = c.Sales.Select(s => new SaleModel
               {
                  Price = s.Car.Parts.Sum(p => p.Part.Price),
                  Discount = s.Discount
               })
            })
            .FirstOrDefault();
      }


   }
}
