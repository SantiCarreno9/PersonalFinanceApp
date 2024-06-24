using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceApp.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //modelBuilder.Entity<Transaction>()
            //.HasOne(t => t.TransactionType)                        

            //modelBuilder.Entity<Transaction>()
            //    .HasOne(t => t.TransactionType)
            //    .WithMany(tt => tt.Transactions)
            //    .HasForeignKey(t => t.TransactionTypeId);

            //modelBuilder.Entity<Transaction>()
            //    .HasOne(t => t.PaymentMethod)
            //    .WithMany(pm => pm.Transactions)
            //    .HasForeignKey(t => t.PaymentMethodId);

            //modelBuilder.Entity<TransactionDetail>()
            //    .HasKey(td => new { td.TransactionId, td.LineNumber });

            //modelBuilder.Entity<TransactionDetail>()
            //    .HasOne(td => td.Transaction)
            //    .WithMany(t => t.)
            //    .HasForeignKey(td => td.TransactionId);
        }
    }
}
