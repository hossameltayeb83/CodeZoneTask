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
    internal class StoreItemConfiguration : IEntityTypeConfiguration<StoreItem>
    {
        public void Configure(EntityTypeBuilder<StoreItem> builder)
        {
           // builder.HasKey(e => new { e.StoreId, e.ItemId });
        }
    }
}
