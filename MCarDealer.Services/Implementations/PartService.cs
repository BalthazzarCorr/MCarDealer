﻿namespace MCarDealer.Services.Implementations
{
   using System.Collections.Generic;
   using System.Linq;
   using Data;
   using Data.Models;
   using Models.Parts;

   public class PartService : IPartService
   {
   
      private readonly CarDealerDbContext db;

      public PartService(CarDealerDbContext db)
      {
         this.db = db;
      }


      public void Create(string name, decimal price, int quantity, int supplierId)
      {
         var part = new Part
         {
            Name = name,
            Price = price,
            Quantity = quantity > 0 ? quantity : 1,
            Supplier_Id = supplierId
         };

         this.db.Parts.Add(part);

         this.db.SaveChanges();
      }


      public IEnumerable<PartListingModel> All(int page = 1,int pageSize = 10)
         => this.db
            .Parts
            .OrderByDescending(p=>p.Id)
            .Skip((page-1)* pageSize)
            .Take(pageSize)
            .Select(p => new PartListingModel
            {
               Id = p.Id,
               Name = p.Name,
               Price = p.Price,
               Quantity = p.Quantity,
               SupplierName = p.Supplier.Name
            }).ToList();

      public int Total() => this.db.Parts.Count();

 
   }
}
