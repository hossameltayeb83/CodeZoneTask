using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Persistence.Configurations
{
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasMany(e => e.Items)
                .WithMany(e => e.Stores)
                .UsingEntity(typeof(StoreItem));
            builder.Property(e=>e.Name)
                .HasMaxLength(100);
            builder.Property(e=>e.Image)
                .HasMaxLength(100);
        }
    }
}
