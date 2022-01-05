using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IContainerRepository :IAsyncGenericRepository<Container>
    {
        Task<List<Container[]>> GetVehicleWithContainersCluster(int id, int N);
    }
}
