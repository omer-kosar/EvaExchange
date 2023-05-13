using System;
using System.Collections.Generic;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Repository.Configuration;

namespace Repository
{
    public partial class EvaExchangeContext : DbContext
    {
        public EvaExchangeContext(DbContextOptions<EvaExchangeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EvaUser> EvaUsers { get; set; } = null!;
        public virtual DbSet<Portfolio> Portfolios { get; set; } = null!;
        public virtual DbSet<Share> Shares { get; set; } = null!;
        public virtual DbSet<ShareInPortfolio> ShareInPortfolios { get; set; } = null!;
        public virtual DbSet<SharePrice> SharePrices { get; set; } = null!;
        public virtual DbSet<Trade> Trades { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.\\sqlexpress;database=EvaExchange;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.ApplyConfiguration(new EvaUserConfiguration());
            modelBuilder.ApplyConfiguration(new PortfolioConfiguration());
            modelBuilder.ApplyConfiguration(new ShareConfiguration());
            modelBuilder.ApplyConfiguration(new ShareInPortfolioConfiguration());
            modelBuilder.ApplyConfiguration(new SharePriceConfiguration());
            modelBuilder.ApplyConfiguration(new TradeConfiguration());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
