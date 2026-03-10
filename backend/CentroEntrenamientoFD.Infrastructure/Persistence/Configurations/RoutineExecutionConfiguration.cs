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
    public class RoutineExecutionConfiguration : IEntityTypeConfiguration<RoutineExecution>
    {
        public void Configure(EntityTypeBuilder<RoutineExecution> builder)
        {
            builder.ToTable("RoutineExecutions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.ClientRoutineId)
                .IsRequired();

            builder.Property(x => x.WeekNumber)
                .IsRequired();

            builder.Property(x => x.Date)
                .IsRequired();

            builder.HasMany(x => x.ExerciseExecutions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.ExerciseExecutions)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
