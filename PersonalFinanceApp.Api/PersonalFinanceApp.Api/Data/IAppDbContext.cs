using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceApp.Api.Data
{
    public interface IAppDbContext
    {
        DbSet<Transaction> Transactions { get; set; }
        DbSet<TransactionDetail> TransactionDetails { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<TransactionType> TransactionTypes { get; set; }
        DbSet<PaymentMethod> PaymentMethods { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
