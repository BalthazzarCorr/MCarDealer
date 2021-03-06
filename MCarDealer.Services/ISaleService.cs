﻿namespace MCarDealer.Services
{
   using System.Collections.Generic;
   using Models.Sales;

   public interface ISaleService
   {
      IEnumerable<SaleListModel> All();

      SaleDetailsModel Details(int id);

      IEnumerable<SaleListModel> Discounted();

      IEnumerable<SaleListModel> DiscountByPercent(double percent);
   }
}
