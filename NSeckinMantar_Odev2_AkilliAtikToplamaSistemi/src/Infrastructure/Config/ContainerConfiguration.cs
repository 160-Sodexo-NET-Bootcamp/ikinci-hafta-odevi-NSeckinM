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
    public class ContainerConfiguration : IEntityTypeConfiguration<Container>
    {
        public void Configure(EntityTypeBuilder<Container> builder)
        {
            builder.Property(x => x.ContainerName).HasMaxLength(50);
            builder.Property(x => x.Latitude).HasColumnType("decimal(10,6)");
            builder.Property(x => x.Longitude).HasColumnType("decimal(10,6)");


            builder.HasOne(x => x.Vehicle).WithMany(x => x.Containers).HasForeignKey(x => x.VehicleId).IsRequired(false);
        }
    }
}
