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
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {

            builder.ToTable("Portfolio");

            builder.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.PortfolioName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Portfolios)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Portfolio_User_UserId");
        }
    }
}
