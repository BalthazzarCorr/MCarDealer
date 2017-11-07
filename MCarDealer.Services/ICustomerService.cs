namespace MCarDealer.Services
{
   using System.Collections.Generic;
   using Models;

   public interface ICustomerService
   {
      IEnumerable<CustomerModel> OrderdCustomers(OrderDirection order);
   }
}
