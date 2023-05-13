using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class SharePriceConfiguration : IEntityTypeConfiguration<SharePrice>
    {
        public void Configure(EntityTypeBuilder<SharePrice> builder)
        {

            builder.ToTable("SharePrice");

            builder.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.PriceDate).HasColumnType("datetime");

            builder.HasOne(d => d.Share)
                .WithMany(p => p.SharePrices)
                .HasForeignKey(d => d.ShareId)
                .HasConstraintName("FK_SharePrice_Share_ShareId");
        }
    }
}
