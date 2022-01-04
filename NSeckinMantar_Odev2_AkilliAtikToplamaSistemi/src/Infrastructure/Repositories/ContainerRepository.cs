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
        public ContainerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
