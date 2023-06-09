﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
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
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.EvaUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("EvaUser", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "johndoe@email.com",
                            FirstName = "John",
                            LastName = "Doe",
                            UserName = "johndoe",
                            UserPassword = "password123"
                        },
                        new
                        {
                            Id = 2,
                            Email = "bobsmith@email.com",
                            FirstName = "Bob",
                            LastName = "Smith",
                            UserName = "bobsmith",
                            UserPassword = "password789"
                        },
                        new
                        {
                            Id = 3,
                            Email = "alicejohnson@email.com",
                            FirstName = "Alice",
                            LastName = "Johnson",
                            UserName = "alicejohnson",
                            UserPassword = "password1011"
                        });
                });

            modelBuilder.Entity("Entities.Models.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PortfolioName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Portfolio", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PortfolioName = "Joh's Portflio",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            PortfolioName = "Bob's Portflio",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            PortfolioName = "Alice's Portflio",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Entities.Models.Share", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("character varying(3)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Symbol" }, "UQ_Share_Symbol")
                        .IsUnique();

                    b.ToTable("Share", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Apple Inc.",
                            Symbol = "APL"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Amazon.com Inc.",
                            Symbol = "AMZ"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Microsoft Corporation",
                            Symbol = "MSF"
                        });
                });

            modelBuilder.Entity("Entities.Models.ShareInPortfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("PortfolioId")
                        .HasColumnType("integer");

                    b.Property<int?>("ShareId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("ShareId");

                    b.ToTable("ShareInPortfolio", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PortfolioId = 1,
                            ShareId = 1
                        },
                        new
                        {
                            Id = 2,
                            PortfolioId = 1,
                            ShareId = 2
                        },
                        new
                        {
                            Id = 3,
                            PortfolioId = 2,
                            ShareId = 1
                        },
                        new
                        {
                            Id = 4,
                            PortfolioId = 2,
                            ShareId = 2
                        });
                });

            modelBuilder.Entity("Entities.Models.SharePrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(18,2)");

                    b.Property<DateTimeOffset>("PriceDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ShareId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ShareId");

                    b.ToTable("SharePrice", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 10m,
                            PriceDate = new DateTimeOffset(new DateTime(2023, 5, 15, 14, 19, 34, 358, DateTimeKind.Unspecified).AddTicks(8055), new TimeSpan(0, 3, 0, 0, 0)),
                            ShareId = 1
                        },
                        new
                        {
                            Id = 2,
                            Price = 20m,
                            PriceDate = new DateTimeOffset(new DateTime(2023, 5, 14, 14, 19, 34, 358, DateTimeKind.Unspecified).AddTicks(8063), new TimeSpan(0, 3, 0, 0, 0)),
                            ShareId = 1
                        },
                        new
                        {
                            Id = 3,
                            Price = 15m,
                            PriceDate = new DateTimeOffset(new DateTime(2023, 5, 15, 14, 19, 34, 358, DateTimeKind.Unspecified).AddTicks(8074), new TimeSpan(0, 3, 0, 0, 0)),
                            ShareId = 2
                        },
                        new
                        {
                            Id = 4,
                            Price = 30m,
                            PriceDate = new DateTimeOffset(new DateTime(2023, 5, 13, 14, 19, 34, 358, DateTimeKind.Unspecified).AddTicks(8077), new TimeSpan(0, 3, 0, 0, 0)),
                            ShareId = 2
                        },
                        new
                        {
                            Id = 5,
                            Price = 10m,
                            PriceDate = new DateTimeOffset(new DateTime(2023, 5, 15, 14, 19, 34, 358, DateTimeKind.Unspecified).AddTicks(8079), new TimeSpan(0, 3, 0, 0, 0)),
                            ShareId = 3
                        },
                        new
                        {
                            Id = 6,
                            Price = 12m,
                            PriceDate = new DateTimeOffset(new DateTime(2023, 5, 13, 14, 19, 34, 358, DateTimeKind.Unspecified).AddTicks(8081), new TimeSpan(0, 3, 0, 0, 0)),
                            ShareId = 3
                        });
                });

            modelBuilder.Entity("Entities.Models.Trade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("ShareId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TradeDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("TradePrice")
                        .HasColumnType("numeric(18,2)");

                    b.Property<int>("TradeType")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ShareId");

                    b.HasIndex("UserId");

                    b.ToTable("Trade", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Quantity = 20,
                            ShareId = 1,
                            TradeDate = new DateTime(2023, 5, 15, 14, 19, 34, 359, DateTimeKind.Local).AddTicks(256),
                            TradePrice = 10m,
                            TradeType = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Quantity = 30,
                            ShareId = 2,
                            TradeDate = new DateTime(2023, 5, 15, 14, 19, 34, 359, DateTimeKind.Local).AddTicks(258),
                            TradePrice = 10m,
                            TradeType = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Quantity = 50,
                            ShareId = 1,
                            TradeDate = new DateTime(2023, 5, 15, 14, 19, 34, 359, DateTimeKind.Local).AddTicks(260),
                            TradePrice = 15m,
                            TradeType = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            Quantity = 60,
                            ShareId = 2,
                            TradeDate = new DateTime(2023, 5, 15, 14, 19, 34, 359, DateTimeKind.Local).AddTicks(261),
                            TradePrice = 15m,
                            TradeType = 1,
                            UserId = 2
                        });
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
