using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IVehicleRepository : IAsyncGenericRepository<Vehicle>
    {
        Task<Vehicle> GetVehicleWithContainers(int id);
    }
}
