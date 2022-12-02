using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CryptoApp.API.Models
{
    public class CryptoContext : IdentityDbContext<User>
    {
        public CryptoContext(DbContextOptions<CryptoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CryptoCurrency>()
                .HasKey(cc => cc.Id);

            modelBuilder.Entity<Currency>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Stock>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<UserCrypto>()
                .HasKey(uc => new { uc.UserId, uc.CryptoId });

            modelBuilder.Entity<UserCurrency>()
                .HasKey(uc => new { uc.UserId, uc.CurrencyId });

            modelBuilder.Entity<UserStock>()
                .HasKey(us => new { us.UserId, us.StockId });

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

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CryptoCurrency> CryptoCurrencies { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<UserCrypto> UserCryptoCurrencies { get; set; }
        public DbSet<UserCurrency> UserCurrencies { get; set; }
        public DbSet<UserStock> UserStocks { get; set; }
    }
}
