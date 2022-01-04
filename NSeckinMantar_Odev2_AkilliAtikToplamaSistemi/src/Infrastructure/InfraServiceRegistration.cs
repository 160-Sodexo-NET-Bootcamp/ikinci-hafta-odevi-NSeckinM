using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.UnitOfWork;
using Infrastructure.Repositories;
using Infrastructure.UOW;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfraServiceRegistration
    {
        public static void AddInfraServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped(typeof(IAsyncGenericRepository<>), typeof(GenericRepository<>));
            serviceCollection.AddScoped<IContainerRepository, ContainerRepository>();
            serviceCollection.AddScoped<IVehicleRepository, VehicleRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
