using ApplicationCore.Interfaces.Repository;
using System;

namespace ApplicationCore.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IContainerRepository Container { get; }

        IVehicleRepository Vehicle { get; }

        int Complete();

    }
}
