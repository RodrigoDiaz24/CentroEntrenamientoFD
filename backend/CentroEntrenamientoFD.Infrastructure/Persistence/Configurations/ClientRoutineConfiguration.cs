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
    public class ClientRoutineConfiguration : IEntityTypeConfiguration<ClientRoutine>
    {
        public void Configure(EntityTypeBuilder<ClientRoutine> builder)
        {
            builder.ToTable("ClientRoutines");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ClientName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Objective)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.Date)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Days)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Mobility)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Days)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Navigation(x => x.Mobility)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
