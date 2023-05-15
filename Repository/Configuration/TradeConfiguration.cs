using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class TradeConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.ToTable("Trade");

            builder.Property(e => e.TradeDate).HasColumnType("datetime");

            builder.Property(e => e.TradePrice).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.Share)
                .WithMany(p => p.Trades)
                .HasForeignKey(d => d.ShareId)
                .HasConstraintName("FK_Trade_Share_ShareId");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Trades)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Trade_User_UserId");
            builder.HasData(
                new Trade { Id = 1, UserId = 1, ShareId = 1, TradeType = 1, Quantity = 20, TradePrice = 10, TradeDate = DateTime.Now },
                new Trade { Id = 2, UserId = 1, ShareId = 2, TradeType = 1, Quantity = 30, TradePrice = 10, TradeDate = DateTime.Now },
                new Trade { Id = 3, UserId = 2, ShareId = 1, TradeType = 1, Quantity = 50, TradePrice = 15, TradeDate = DateTime.Now },
                new Trade { Id = 4, UserId = 2, ShareId = 2, TradeType = 1, Quantity = 60, TradePrice = 15, TradeDate = DateTime.Now }
                );
        }
    }
}
