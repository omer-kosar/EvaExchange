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
    public class ShareConfiguration : IEntityTypeConfiguration<Share>
    {
        public void Configure(EntityTypeBuilder<Share> builder)
        {
          
                builder.ToTable("Share");

                builder.HasIndex(e => e.Symbol, "UQ_Share_Symbol")
                    .IsUnique();

                builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.LatestPrice).HasColumnType("decimal(18, 2)");

                builder.Property(e => e.Symbol)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            
        }
    }
}
