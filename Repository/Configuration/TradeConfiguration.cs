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
        }
    }
}
