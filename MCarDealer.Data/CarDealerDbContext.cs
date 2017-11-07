namespace MCarDealer.Data
{
   using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
   using Microsoft.EntityFrameworkCore;
   using Models;


   public class CarDealerDbContext : IdentityDbContext<ApplicationUser>
   {
      public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
          : base(options)
      {

      }


      public DbSet<Car> Cars { get; set; }
      public DbSet<Sale> Sales { get; set; }
      public DbSet<Supplier> Suppliers { get; set;}
      public DbSet<Customer> Customers { get; set; }


      protected override void OnModelCreating(ModelBuilder builder)
      {
         builder.Entity<PartCar>().HasOne(c => c.Car).WithMany(p => p.Parts).HasForeignKey(c => c.Car_Id);
         builder.Entity<PartCar>().HasOne(c => c.Part).WithMany(c => c.Cars).HasForeignKey(p => p.Part_Id); 

         builder.Entity<Sale>().HasOne(s => s.Car).WithMany(c => c.Sales).HasForeignKey(c => c.Car_Id);

         builder.Entity<Sale>().HasOne(c => c.Customer).WithMany(c => c.Sales).HasForeignKey(c => c.Customer_Id);


         base.OnModelCreating(builder);

      }
   }
}
