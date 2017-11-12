namespace MCarDealer.Services
{
   using System;
   using System.Collections.Generic;
   using Models;
   using Models.Customers;

   public interface ICustomerService
   {
      IEnumerable<CustomerModel> OrderdCustomers(OrderDirection order);

      CustomerTotalSalesModel TotalSales(int id);

      void Create(string name , DateTime birthdate,bool isYoungDriver);

      CustomerModel Edit(int id);

      void Edit(int id, string name, DateTime birthDate, bool isYoungDriver);

      bool Exists(int id);
   }
}
