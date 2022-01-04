using ApplicationCore.Interfaces.Repository;
using System;

namespace ApplicationCore.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IContainerRepository Containers { get; }

        IVehicleRepository Vehicles { get; }

        int Complete();

    }
}
