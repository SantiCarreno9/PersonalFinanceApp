using BaseLibrary.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceApp.Api.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
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

            modelBuilder.Entity<IdentityUser>()
                .HasMany<Transaction>()
                .WithOne()
                .HasForeignKey(t=>t.UserId)
                .IsRequired();            

            modelBuilder.Entity<TransactionDetail>()
                .HasOne(td => td.Transaction)
                .WithMany(t => t.TransactionDetails)
                .HasForeignKey(td => td.TransactionId)                
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<PaymentMethod>()
                .Property(c => c.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<TransactionType>()
                .Property(c => c.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Transaction>()
                .Property(c => c.Location)
                .HasDefaultValue("Unknown");

            modelBuilder.Entity<Transaction>()
                .Property(t => t.TransactionTypeId)
                .HasDefaultValue(1/*Expense*/);
        }
    }
}
