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


            builder.Property(e => e.PortfolioName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Portfolios)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Portfolio_User_UserId");
            builder.HasData(
                new Portfolio { Id = 1, PortfolioName = "Joh's Portflio", UserId = 1 },
                new Portfolio { Id = 2, PortfolioName = "Bob's Portflio", UserId = 2 },
                new Portfolio { Id = 3, PortfolioName = "Alice's Portflio", UserId = 3 }
                );
        }
    }
}
