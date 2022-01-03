using ApplicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IContainerRepository Container { get; }

        IVehicleRepository Vehicle { get; }

        int Complete();

    }
}
