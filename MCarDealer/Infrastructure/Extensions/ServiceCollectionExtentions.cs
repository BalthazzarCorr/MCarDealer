namespace MCarDealer.Infrastructure.Extensions
{
   using System.Reflection;
   using Microsoft.Extensions.DependencyInjection;

   public static class ServiceCollectionExtentions
   {
      public IServiceCollection RegisterDomainServices(this IServiceCollection services)
      {
         Assembly.GetAssembly();

         return services;
      }
   }
}
