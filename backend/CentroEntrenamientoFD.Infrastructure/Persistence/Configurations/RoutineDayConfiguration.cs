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
    public class RoutineDayConfiguration : IEntityTypeConfiguration<RoutineDay>
    {
        public void Configure(EntityTypeBuilder<RoutineDay> builder)
        {
            builder.ToTable("RoutineDays");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DayNumber)
                .IsRequired();

            builder.HasMany(x => x.Exercises)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Exercises)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
