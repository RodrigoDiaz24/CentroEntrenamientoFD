using CentroEntrenamientoFD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Infrastructure.Persistence.Configurations
{
    public class MicroExecutionConfiguration : IEntityTypeConfiguration<MicroExecution>
    {
        public void Configure(EntityTypeBuilder<MicroExecution> builder)
        {
            builder.ToTable("MicroExecutions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SlotOrder)
                .IsRequired();

            builder.Property(x => x.Reps)
                .IsRequired();

            builder.Property(x => x.Weight)
                .HasPrecision(6, 2)
                .IsRequired();
        }
    }
}
