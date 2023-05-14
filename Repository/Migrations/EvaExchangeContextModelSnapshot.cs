﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(EvaExchangeContext))]
    partial class EvaExchangeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.EvaUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EvaUser", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PortfolioName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Portfolio", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Share", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("varchar(3)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Symbol" }, "UQ_Share_Symbol")
                        .IsUnique();

                    b.ToTable("Share", (string)null);
                });

            modelBuilder.Entity("Entities.Models.ShareInPortfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<int?>("ShareId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("ShareId");

                    b.ToTable("ShareInPortfolio", (string)null);
                });

            modelBuilder.Entity("Entities.Models.SharePrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PriceDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("ShareId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShareId");

                    b.ToTable("SharePrice", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Trade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("ShareId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TradeDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("TradePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TradeType")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShareId");

                    b.HasIndex("UserId");

                    b.ToTable("Trade", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Portfolio", b =>
                {
                    b.HasOne("Entities.Models.EvaUser", "User")
                        .WithMany("Portfolios")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Portfolio_User_UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.ShareInPortfolio", b =>
                {
                    b.HasOne("Entities.Models.Portfolio", "Portfolio")
                        .WithMany("ShareInPortfolios")
                        .HasForeignKey("PortfolioId")
                        .HasConstraintName("FK_ShareInPortfolio_Portfolio_PortfolioId");

                    b.HasOne("Entities.Models.Share", "Share")
                        .WithMany("ShareInPortfolios")
                        .HasForeignKey("ShareId")
                        .HasConstraintName("FK_ShareInPortfolio_Share_ShareId");

                    b.Navigation("Portfolio");

                    b.Navigation("Share");
                });

            modelBuilder.Entity("Entities.Models.SharePrice", b =>
                {
                    b.HasOne("Entities.Models.Share", "Share")
                        .WithMany("SharePrices")
                        .HasForeignKey("ShareId")
                        .HasConstraintName("FK_SharePrice_Share_ShareId");

                    b.Navigation("Share");
                });

            modelBuilder.Entity("Entities.Models.Trade", b =>
                {
                    b.HasOne("Entities.Models.Share", "Share")
                        .WithMany("Trades")
                        .HasForeignKey("ShareId")
                        .HasConstraintName("FK_Trade_Share_ShareId");

                    b.HasOne("Entities.Models.EvaUser", "User")
                        .WithMany("Trades")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Trade_User_UserId");

                    b.Navigation("Share");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.EvaUser", b =>
                {
                    b.Navigation("Portfolios");

                    b.Navigation("Trades");
                });

            modelBuilder.Entity("Entities.Models.Portfolio", b =>
                {
                    b.Navigation("ShareInPortfolios");
                });

            modelBuilder.Entity("Entities.Models.Share", b =>
                {
                    b.Navigation("ShareInPortfolios");

                    b.Navigation("SharePrices");

                    b.Navigation("Trades");
                });
#pragma warning restore 612, 618
        }
    }
}
