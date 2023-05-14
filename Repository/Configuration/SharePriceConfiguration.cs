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
            builder.HasData(new SharePrice { Price = 10, PriceDate = DateTime.Now, ShareId = 1, Id = 1 },
                        new SharePrice { Price = 20, PriceDate = DateTime.Now.AddDays(-1), ShareId = 1, Id = 2 },
                        new SharePrice { Price = 15, PriceDate = DateTime.Now, ShareId = 2, Id = 3 },
                        new SharePrice { Price = 30, PriceDate = DateTime.Now.AddDays(-2), ShareId = 2, Id = 4 },
                         new SharePrice { Price = 10, PriceDate = DateTime.Now, ShareId = 3, Id = 5 },
                        new SharePrice { Price = 12, PriceDate = DateTime.Now.AddDays(-2), ShareId = 3, Id = 6 }
                        );
        }
    }
}
