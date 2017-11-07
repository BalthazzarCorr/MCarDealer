﻿namespace MCarDealer.Services.Implementations
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using Data;
   using Models;

   public class CustomerService : ICustomerService
   {
      private readonly CarDealerDbContext db;

      public CustomerService(CarDealerDbContext db)
      {
         this.db = db;
      }

      public IEnumerable<CustomerModel> OrderdCustomers(OrderDirection order)
      {
         var customerQuery = this.db.Customers.AsQueryable();

         switch (order)
         {
            case OrderDirection.Ascending:
               customerQuery = customerQuery.OrderBy(c => c.BirthDate).ThenBy(c=>c.Name);
               break;
            case OrderDirection.Descending:
               customerQuery = customerQuery.OrderByDescending(c => c.BirthDate).ThenBy(c=>c.Name);
               break;
            default:
               throw new InvalidOperationException($"Invalid order direction {order}");
         }

         return  customerQuery.Select(c=> new CustomerModel
         {
            Name = c.Name,
            BirthDate = c.BirthDate,
            IsYoungDriver = c.IsYoungDriver
         }).ToList();
      }
   }
}