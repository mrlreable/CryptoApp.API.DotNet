﻿// <auto-generated />
using System;
using CryptoApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CryptoApp.API.Migrations
{
    [DbContext(typeof(CryptoContext))]
    [Migration("20221203190928_UserStock")]
    partial class UserStock
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CryptoApp.API.Models.CryptoCurrency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Change")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsSupported")
                        .HasColumnType("bit");

                    b.Property<double?>("MarketCap")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UpdatedById");

                    b.ToTable("CryptoCurrencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Change = -0.72999999999999998,
                            Description = "Bitcoin (abbreviation: BTC; sign: ₿) is a decentralized digital currency that can be transferred on the peer-to-peer bitcoin network.",
                            IsSupported = true,
                            Name = "Bitcoin",
                            Price = 6599123.5899999999,
                            ShortName = "BTC"
                        },
                        new
                        {
                            Id = 2,
                            Change = -0.72999999999999998,
                            Description = " Ether (Abbreviation: ETH;[a] sign: Ξ) is the native cryptocurrency of the Ethereum blockcahin.",
                            IsSupported = true,
                            Name = "Ether",
                            Price = 494679.16999999998,
                            ShortName = "ETH"
                        },
                        new
                        {
                            Id = 3,
                            Change = -0.72999999999999998,
                            Description = "Polygon (MATIC) is an Ethereum token that powers the Polygon Network, a scaling solution for Ethereum.",
                            IsSupported = true,
                            MarketCap = 3100000000000.0,
                            Name = "Polygon",
                            Price = 358.19,
                            ShortName = "MATIC"
                        });
                });

            modelBuilder.Entity("CryptoApp.API.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CentralBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Change")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<double>("ExchangeRateEUR")
                        .HasColumnType("float");

                    b.Property<double>("ExchangeRateHUF")
                        .HasColumnType("float");

                    b.Property<double>("ExchangeRateUSD")
                        .HasColumnType("float");

                    b.Property<bool>("IsSupported")
                        .HasColumnType("bit");

                    b.Property<string>("MinorUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CentralBank = "Hungarian National Bank",
                            Change = 0.93000000000000005,
                            Description = "HUF is the currency of Hungary",
                            ExchangeRateEUR = 408.23000000000002,
                            ExchangeRateHUF = 1.0,
                            ExchangeRateUSD = 392.02999999999997,
                            IsSupported = true,
                            Name = "Hungarian Forint",
                            ShortName = "HUF"
                        },
                        new
                        {
                            Id = 2,
                            CentralBank = "Eurosystem",
                            Change = -0.13,
                            Description = "The euro (symbol: €; code: EUR) is the official currency of 19 out of the 27 member states of the European Union (EU).",
                            ExchangeRateEUR = 1.0,
                            ExchangeRateHUF = 0.0023999999999999998,
                            ExchangeRateUSD = 0.94999999999999996,
                            IsSupported = true,
                            Name = "euro",
                            ShortName = "EUR"
                        },
                        new
                        {
                            Id = 3,
                            CentralBank = "Eurosystem",
                            Change = -0.13,
                            Description = "The United States dollar (symbol: $; code: USD; also abbreviated US$ or U.S. Dollar, to distinguish it from other dollar-denominated currencies; referred to as the dollar, U.S. dollar, American dollar, or colloquially buck) is the official currency of the United States and several other countries.",
                            ExchangeRateEUR = 1.05,
                            ExchangeRateHUF = 0.0025999999999999999,
                            ExchangeRateUSD = 1.0,
                            IsSupported = true,
                            Name = "United States dollar",
                            ShortName = "USD"
                        });
                });

            modelBuilder.Entity("CryptoApp.API.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "There’s no way around it — November was a rough month for crypto. Markets are down, lenders and funds are dropping like flies, and the bear market vibes are in full effect. As we continue to wade through the wreckage of FTX and Alameda, it’s clear some communities were hit a lot harder than others. This week, we dive into the tough times that have hit the Solana ecosystem, digging into how exactly the network is struggling and where the community is showing resilience.",
                            CreatedAt = new DateTime(2022, 12, 3, 20, 9, 28, 520, DateTimeKind.Local).AddTicks(491),
                            CreatedById = "4a3bb735-a5bf-469d-a60d-f0f8eac836eb",
                            Label = "Crypto",
                            Title = "Is Solana Dead?"
                        });
                });

            modelBuilder.Entity("CryptoApp.API.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Change")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsSupported")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<double>("Spread")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Stocks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Change = 1.75,
                            Description = "Uniper SE. An international energy company, based in Düsseldorf, Germany.",
                            IsSupported = true,
                            Name = "Uniper",
                            Price = 3.5099999999999998,
                            ShortName = "UN01.DE",
                            Spread = 0.029999999999999999
                        },
                        new
                        {
                            Id = 2,
                            Change = -0.34000000000000002,
                            Description = "An American multinational hardware and software company.",
                            IsSupported = true,
                            Name = "Apple",
                            Price = 147.25,
                            ShortName = "AAPL",
                            Spread = 1.1100000000000001
                        },
                        new
                        {
                            Id = 3,
                            Change = 1.0800000000000001,
                            Description = "A leading online entertainment services company.",
                            IsSupported = true,
                            Name = "Netflix",
                            Price = 319.16000000000003,
                            ShortName = "NFLX",
                            Spread = 2.3999999999999999
                        });
                });

            modelBuilder.Entity("CryptoApp.API.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CryptoApp.API.Models.UserCrypto", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CryptoId")
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<DateTime>("LatestPurchase")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "CryptoId");

                    b.HasIndex("CryptoId");

                    b.ToTable("UserCryptoCurrencies");
                });

            modelBuilder.Entity("CryptoApp.API.Models.UserCurrency", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<DateTime>("LatestPurchase")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "CurrencyId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("UserCurrencies");
                });

            modelBuilder.Entity("CryptoApp.API.Models.UserStock", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<DateTime>("LatestPurchase")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "StockId");

                    b.HasIndex("StockId");

                    b.ToTable("UserStocks");
                });

            modelBuilder.Entity("CryptoApp.API.Models.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cardholder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("UserId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StockUser", b =>
                {
                    b.Property<int>("StocksId")
                        .HasColumnType("int");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StocksId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("StockUser");
                });

            modelBuilder.Entity("CryptoApp.API.Models.CryptoCurrency", b =>
                {
                    b.HasOne("CryptoApp.API.Models.User", "UpdatedBy")
                        .WithMany("UpdatedCryptos")
                        .HasForeignKey("UpdatedById");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("CryptoApp.API.Models.Currency", b =>
                {
                    b.HasOne("CryptoApp.API.Models.User", "UpdatedBy")
                        .WithMany("UpdatedCurrencies")
                        .HasForeignKey("UpdatedById");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("CryptoApp.API.Models.News", b =>
                {
                    b.HasOne("CryptoApp.API.Models.User", "CreatedBy")
                        .WithMany("NewsCreated")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoApp.API.Models.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("CryptoApp.API.Models.Stock", b =>
                {
                    b.HasOne("CryptoApp.API.Models.User", "UpdatedBy")
                        .WithMany("UpdatedStocks")
                        .HasForeignKey("UpdatedById");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("CryptoApp.API.Models.UserCrypto", b =>
                {
                    b.HasOne("CryptoApp.API.Models.CryptoCurrency", "Crypto")
                        .WithMany("UserCryptos")
                        .HasForeignKey("CryptoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoApp.API.Models.User", "User")
                        .WithMany("UserCryptos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crypto");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CryptoApp.API.Models.UserCurrency", b =>
                {
                    b.HasOne("CryptoApp.API.Models.Currency", "Currency")
                        .WithMany("UserCurrencies")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoApp.API.Models.User", "User")
                        .WithMany("UserCurrencies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CryptoApp.API.Models.UserStock", b =>
                {
                    b.HasOne("CryptoApp.API.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoApp.API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CryptoApp.API.Models.Wallet", b =>
                {
                    b.HasOne("CryptoApp.API.Models.Currency", "Currency")
                        .WithMany("Wallets")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoApp.API.Models.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CryptoApp.API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CryptoApp.API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoApp.API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CryptoApp.API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StockUser", b =>
                {
                    b.HasOne("CryptoApp.API.Models.Stock", null)
                        .WithMany()
                        .HasForeignKey("StocksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoApp.API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CryptoApp.API.Models.CryptoCurrency", b =>
                {
                    b.Navigation("UserCryptos");
                });

            modelBuilder.Entity("CryptoApp.API.Models.Currency", b =>
                {
                    b.Navigation("UserCurrencies");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("CryptoApp.API.Models.User", b =>
                {
                    b.Navigation("NewsCreated");

                    b.Navigation("UpdatedCryptos");

                    b.Navigation("UpdatedCurrencies");

                    b.Navigation("UpdatedStocks");

                    b.Navigation("UserCryptos");

                    b.Navigation("UserCurrencies");

                    b.Navigation("Wallets");
                });
#pragma warning restore 612, 618
        }
    }
}