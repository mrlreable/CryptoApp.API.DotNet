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
    [Migration("20221201204452_Added_Wallets")]
    partial class Added_Wallets
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
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UpdatedById");

                    b.ToTable("CryptoCurrencies");
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
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Currencies");
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
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<double>("Spread")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("CryptoApp.API.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
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

                    b.Property<string>("CCVHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumberHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOnCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Wallet");
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
                        .WithMany("UserStocks")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoApp.API.Models.User", "User")
                        .WithMany("UserStocks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CryptoApp.API.Models.Wallet", b =>
                {
                    b.HasOne("CryptoApp.API.Models.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CryptoApp.API.Models.CryptoCurrency", b =>
                {
                    b.Navigation("UserCryptos");
                });

            modelBuilder.Entity("CryptoApp.API.Models.Currency", b =>
                {
                    b.Navigation("UserCurrencies");
                });

            modelBuilder.Entity("CryptoApp.API.Models.Stock", b =>
                {
                    b.Navigation("UserStocks");
                });

            modelBuilder.Entity("CryptoApp.API.Models.User", b =>
                {
                    b.Navigation("NewsCreated");

                    b.Navigation("UpdatedCryptos");

                    b.Navigation("UpdatedCurrencies");

                    b.Navigation("UpdatedStocks");

                    b.Navigation("UserCryptos");

                    b.Navigation("UserCurrencies");

                    b.Navigation("UserStocks");

                    b.Navigation("Wallets");
                });
#pragma warning restore 612, 618
        }
    }
}
