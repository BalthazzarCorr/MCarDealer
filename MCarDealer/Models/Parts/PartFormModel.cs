namespace MCarDealer.Models.Parts
{
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using Services.Models.Suppliers;

   public class PartFormModel
   {

   
      [Required]
      [MaxLength(100)]
      public string Name { get; set; }

      [Range(0, double.MaxValue)]
      public decimal Price { get; set; }

      [Range(0, int.MaxValue)]
      public int Quantity { get; set; }

      [Display(Name="Supplier")]
      public int Supplier_Id { get; set; }

      public IEnumerable<SupplierModel> AllSuppliers { get; set; }

   }
}
