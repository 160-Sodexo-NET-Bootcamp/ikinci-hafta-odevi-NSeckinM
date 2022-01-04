using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        private readonly ApplicationDbContext dbContext;

        public VehicleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Vehicle> GetVehicleWithContainers(int id)
        {
            Vehicle vehicle = dbContext.Vehicles.Include(x => x.Containers).FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(vehicle);
        }
        

        // To Do 
        public Task<Vehicle> GetVehicleWithContainersCluster(int id, int N)
        {
            Vehicle vehicle = dbContext.Vehicles.Include(x => x.Containers).FirstOrDefault(x => x.Id == id);
            int countOfContainer = vehicle.Containers.Count();
            int numberOfClusterItem = countOfContainer / N;

            List<Container> x = vehicle.Containers;

            for (int i = 1; i <= N; i++)
            {
                Container[] cdizi = new Container[] { };

                for (int j = 1 ; j < numberOfClusterItem; j++)
                {
                    cdizi.Append(vehicle.Containers[j*i-1].);
                }
                //x.Add();

            };
            return null;

        }
    }
}
