namespace MCarDealer.Services
{
   using System.Collections.Generic;
   using Models;
   using Models.Customers;

   public interface ICustomerService
   {
      IEnumerable<CustomerModel> OrderdCustomers(OrderDirection order);

      CustomerTotalSalesModel TotalSales(int id);
   }
}
