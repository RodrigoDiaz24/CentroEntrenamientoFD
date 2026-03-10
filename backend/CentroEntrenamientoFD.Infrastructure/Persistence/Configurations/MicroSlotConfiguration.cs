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
    public class MicroSlotConfiguration : IEntityTypeConfiguration<MicroSlot>
    {
        public void Configure(EntityTypeBuilder<MicroSlot> builder)
        {
            builder.ToTable("MicroSlots");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Order)
                .IsRequired();

            builder.HasOne<Exercise>()
                .WithMany(x => x.Slots)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
