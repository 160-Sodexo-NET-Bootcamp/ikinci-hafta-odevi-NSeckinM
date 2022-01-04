using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IContainerRepository Containers { get; }

        public IVehicleRepository Vehicles { get; }


        public UnitOfWork(ApplicationDbContext dbContext, IContainerRepository containerRepository, IVehicleRepository vehicleRepository)
        {
            _dbContext = dbContext;
            Containers = containerRepository;
            Vehicles = vehicleRepository;
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
