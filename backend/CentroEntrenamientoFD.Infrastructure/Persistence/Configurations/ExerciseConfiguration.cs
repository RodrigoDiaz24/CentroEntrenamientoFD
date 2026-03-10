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
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("Exercises");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasMany(x => x.Slots)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Slots)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
