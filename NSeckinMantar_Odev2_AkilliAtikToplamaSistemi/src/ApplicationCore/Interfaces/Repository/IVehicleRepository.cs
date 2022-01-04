using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IVehicleRepository : IAsyncGenericRepository<Vehicle>
    {
        Task<Vehicle> GetVehicleWithContainers(int id);
        Task<Vehicle> GetVehicleWithContainersCluster(int id, int N);
    }
}
