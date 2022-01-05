using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ContainerRepository : GenericRepository<Container> , IContainerRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ContainerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Container[]>> GetVehicleWithContainersCluster(int id, int N)
        {
            List<Container> containersList = dbContext.Containers.Where(x => x.VehicleId == id).ToList();
            List<Container> x = containersList;
            List<Container[]> result = new List<Container[]>();
            int countOfContainer = containersList.Count();
            int numberOfClusterItem = countOfContainer / N;
            if (countOfContainer%N ==0)
            {
                switch (N)
                {
                    case 2:
                        Container[] c21 = new Container[numberOfClusterItem];
                        Container[] c22 = new Container[numberOfClusterItem];
                        x.CopyTo(0, c21, 0, numberOfClusterItem);
                        x.CopyTo(numberOfClusterItem, c22, 0, numberOfClusterItem);
                        result.Add(c21);
                        result.Add(c22);
                        break;
                    case 3:
                        Container[] c31 = new Container[numberOfClusterItem];
                        Container[] c32 = new Container[numberOfClusterItem];
                        Container[] c33 = new Container[numberOfClusterItem];
                        x.CopyTo(0, c31, 0, numberOfClusterItem);
                        x.CopyTo(numberOfClusterItem, c32, 0, numberOfClusterItem);
                        x.CopyTo(numberOfClusterItem * 2, c33, 0, numberOfClusterItem);
                        result.Add(c31);
                        result.Add(c32);
                        result.Add(c33);
                        break;
                    case 4:
                        Container[] c41 = new Container[numberOfClusterItem];
                        Container[] c42 = new Container[numberOfClusterItem];
                        Container[] c43 = new Container[numberOfClusterItem];
                        Container[] c44 = new Container[numberOfClusterItem];
                        x.CopyTo(0, c41, 0, numberOfClusterItem);
                        x.CopyTo(numberOfClusterItem, c42, 0, numberOfClusterItem);
                        x.CopyTo((numberOfClusterItem * 2), c43, 0, numberOfClusterItem);
                        x.CopyTo((numberOfClusterItem * 3), c44, 0, numberOfClusterItem);
                        result.Add(c41);
                        result.Add(c42);
                        result.Add(c43);
                        result.Add(c44);
                        break;
                    case 5:
                        Container[] c51 = new Container[numberOfClusterItem];
                        Container[] c52 = new Container[numberOfClusterItem];
                        Container[] c53 = new Container[numberOfClusterItem];
                        Container[] c54 = new Container[numberOfClusterItem];
                        Container[] c55 = new Container[numberOfClusterItem];
                        x.CopyTo(0, c51, 0, numberOfClusterItem);
                        x.CopyTo(numberOfClusterItem, c52, 0, numberOfClusterItem);
                        x.CopyTo(numberOfClusterItem * 2, c53, 0, numberOfClusterItem);
                        x.CopyTo(numberOfClusterItem * 3, c54, 0, numberOfClusterItem);
                        x.CopyTo(numberOfClusterItem * 4, c55, 0, numberOfClusterItem);
                        result.Add(c51);
                        result.Add(c52);
                        result.Add(c53);
                        result.Add(c54);
                        result.Add(c55);
                        break;
                    default:
                        Container[] def = new Container[x.Count];
                        x.CopyTo(0, def, 0, x.Count);
                        result.Add(def);
                        break;
                }
            }

            return await Task.FromResult(result);

        }
    }
}
