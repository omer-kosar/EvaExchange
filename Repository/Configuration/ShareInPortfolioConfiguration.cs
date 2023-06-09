﻿using Entities.Models;
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
    public class ShareInPortfolioConfiguration : IEntityTypeConfiguration<ShareInPortfolio>
    {
        public void Configure(EntityTypeBuilder<ShareInPortfolio> builder)
        {

            builder.ToTable("ShareInPortfolio");

            builder.HasOne(d => d.Portfolio)
                .WithMany(p => p.ShareInPortfolios)
                .HasForeignKey(d => d.PortfolioId)
                .HasConstraintName("FK_ShareInPortfolio_Portfolio_PortfolioId");

            builder.HasOne(d => d.Share)
                .WithMany(p => p.ShareInPortfolios)
                .HasForeignKey(d => d.ShareId)
                .HasConstraintName("FK_ShareInPortfolio_Share_ShareId");
            builder.HasData(
                new ShareInPortfolio { Id = 1, PortfolioId = 1, ShareId = 1 },
                new ShareInPortfolio { Id = 2, PortfolioId = 1, ShareId = 2 },
                new ShareInPortfolio { Id = 3, PortfolioId = 2, ShareId = 1 },
                new ShareInPortfolio { Id = 4, PortfolioId = 2, ShareId = 2 }
                );
        }
    }
}
