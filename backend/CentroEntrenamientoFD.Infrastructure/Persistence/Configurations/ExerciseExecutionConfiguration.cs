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
    public class ExerciseExecutionConfiguration : IEntityTypeConfiguration<ExerciseExecution>
    {
        public void Configure(EntityTypeBuilder<ExerciseExecution> builder)
        {
            builder.ToTable("ExerciseExecutions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ExerciseId)
                .IsRequired();

            builder.HasMany(x => x.MicroExecutions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.MicroExecutions)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
