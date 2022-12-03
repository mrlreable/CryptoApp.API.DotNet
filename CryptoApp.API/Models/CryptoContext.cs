using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CryptoApp.API.Models
{
    public class CryptoContext : IdentityDbContext<User>
    {
        public CryptoContext(DbContextOptions<CryptoContext> options) : base(options)
        {
        }

        private CryptoContext()
        {

        }

        public static CryptoContext CreateContext()
        {
            return new CryptoContext();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Stocks)
                .WithMany(s => s.Users)
                .UsingEntity<UserStock>();

            modelBuilder.Entity<CryptoCurrency>()
                .HasKey(cc => cc.Id);

            modelBuilder.Entity<Currency>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Stock>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<UserCrypto>(uc => { 
                uc.HasKey(uc => new { uc.UserId, uc.CryptoId });
                uc.Property(uc => uc.UserId).ValueGeneratedNever();
                uc.Property(uc => uc.CryptoId).ValueGeneratedNever();
            });

            modelBuilder.Entity<UserCurrency>(uc =>
            {
                uc.HasKey(uc => new { uc.UserId, uc.CurrencyId });
                uc.Property(uc => uc.UserId).ValueGeneratedNever();
                uc.Property(uc => uc.CurrencyId).ValueGeneratedNever();
            });

            modelBuilder.Entity<UserStock>(us =>
            {
                us.HasKey(us => new { us.UserId, us.StockId });
                us.Property(us => us.UserId).ValueGeneratedNever();
                us.Property(us => us.StockId).ValueGeneratedNever();
            });

            modelBuilder.Entity<CryptoCurrency>()
                .HasOne(cc => cc.UpdatedBy)
                .WithMany(u => u.UpdatedCryptos)
                .HasForeignKey(n => n.UpdatedById);

            modelBuilder.Entity<Stock>()
                .HasOne(cc => cc.UpdatedBy)
                .WithMany(u => u.UpdatedStocks)
                .HasForeignKey(n => n.UpdatedById);

            modelBuilder.Entity<Currency>()
                .HasOne(cc => cc.UpdatedBy)
                .WithMany(u => u.UpdatedCurrencies)
                .HasForeignKey(n => n.UpdatedById);

            modelBuilder.Entity<News>()
                .HasOne(n => n.CreatedBy)
                .WithMany(u => u.NewsCreated)
                .HasForeignKey(n => n.CreatedById);

            Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .HasData(new Currency
                {
                    Id = 1,
                    Name = "Hungarian Forint",
                    ShortName = "HUF",
                    IsSupported = true,
                    Change = 0.93,
                    Description = "HUF is the currency of Hungary",
                    ExchangeRateHUF = 1,
                    ExchangeRateEUR = 408.23,
                    ExchangeRateUSD = 392.03,
                    CentralBank = "Hungarian National Bank"
                },
                new Currency
                {
                    Id = 2,
                    Name = "euro",
                    ShortName = "EUR",
                    IsSupported = true,
                    Change = -0.13,
                    Description = "The euro (symbol: €; code: EUR) is the official currency of 19 out of the 27 member states of the European Union (EU).",
                    ExchangeRateHUF = 0.0024,
                    ExchangeRateEUR = 1,
                    ExchangeRateUSD = 0.95,
                    CentralBank = "Eurosystem"
                },
                new Currency
                {
                    Id = 3,
                    Name = "United States dollar",
                    ShortName = "USD",
                    IsSupported = true,
                    Change = -0.13,
                    Description = "The United States dollar (symbol: $; code: USD; also abbreviated US$ or U.S. Dollar, to distinguish it from other dollar-denominated currencies; referred to as the dollar, U.S. dollar, American dollar, or colloquially buck) is the official currency of the United States and several other countries.",
                    ExchangeRateHUF = 0.0026,
                    ExchangeRateEUR = 1.05,
                    ExchangeRateUSD = 1,
                    CentralBank = "Eurosystem"
                });
            modelBuilder.Entity<CryptoCurrency>()
                .HasData(new CryptoCurrency
                {
                    Id = 1,
                    Name = "Bitcoin",
                    ShortName = "BTC",
                    IsSupported = true,
                    Change = -0.73,
                    Description = "Bitcoin (abbreviation: BTC; sign: ₿) is a decentralized digital currency that can be transferred on the peer-to-peer bitcoin network.",
                    Price = 6_599_123.59
                },
                new CryptoCurrency
                {
                    Id = 2,
                    Name = "Ether",
                    ShortName = "ETH",
                    IsSupported = true,
                    Change = -0.73,
                    Description = " Ether (Abbreviation: ETH;[a] sign: Ξ) is the native cryptocurrency of the Ethereum blockcahin.",
                    Price = 494_679.17
                },
                new CryptoCurrency
                {
                    Id = 3,
                    Name = "Polygon",
                    ShortName = "MATIC",
                    IsSupported = true,
                    Change = -0.73,
                    Description = "Polygon (MATIC) is an Ethereum token that powers the Polygon Network, a scaling solution for Ethereum.",
                    Price = 358.19,
                    MarketCap = 3.1e12
                });
            modelBuilder.Entity<Stock>()
                .HasData(new Stock
                {
                    Id = 1,
                    Name = "Uniper",
                    ShortName = "UN01.DE",
                    IsSupported = true,
                    Change = 1.75,
                    Description = "Uniper SE. An international energy company, based in Düsseldorf, Germany.",
                    Price = 3.51,
                    Spread = 0.03
                },
                new Stock
                {
                    Id = 2,
                    Name = "Apple",
                    ShortName = "AAPL",
                    IsSupported = true,
                    Change = -0.34,
                    Description = "An American multinational hardware and software company.",
                    Price = 147.25,
                    Spread = 1.11
                },
                new Stock
                {
                    Id = 3,
                    Name = "Netflix",
                    ShortName = "NFLX",
                    IsSupported = true,
                    Change = 1.08,
                    Description = "A leading online entertainment services company.",
                    Price = 319.16,
                    Spread = 2.4
                });
            modelBuilder.Entity<News>()
                .HasData(new News
                {
                    Id = 1,
                    Label = "Crypto",
                    Title = "Is Solana Dead?",
                    CreatedAt = DateTime.Now,
                    CreatedById = "4a3bb735-a5bf-469d-a60d-f0f8eac836eb",
                    Content = @"There’s no way around it — November was a rough month for crypto. Markets are down, lenders and funds are dropping like flies, and the bear market vibes are in full effect. As we continue to wade through the wreckage of FTX and Alameda, it’s clear some communities were hit a lot harder than others. This week, we dive into the tough times that have hit the Solana ecosystem, digging into how exactly the network is struggling and where the community is showing resilience."
                });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CryptoCurrency> CryptoCurrencies { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<UserCrypto> UserCryptoCurrencies { get; set; }
        public DbSet<UserCurrency> UserCurrencies { get; set; }
        public DbSet<UserStock> UserStocks { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
