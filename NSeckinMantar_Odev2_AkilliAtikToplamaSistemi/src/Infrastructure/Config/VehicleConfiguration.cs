using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(x => x.VehicleName).HasMaxLength(50);
            builder.Property(x => x.VehiclePlate).HasMaxLength(14);

            builder.HasMany(x => x.Containers).WithOne(x => x.Vehicle).IsRequired(false);
        }
    }
}
