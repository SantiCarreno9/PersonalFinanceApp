using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Entities;

namespace PersonalFinanceApp.Api.Database;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<RefreshToken> RefreshTokens { get; set; }
    DbSet<Account> Accounts { get; set; }
    DbSet<Transaction> Transactions { get; set; }
    DbSet<TransactionDetail> TransactionDetails { get; set; }
    DbSet<Transfer> Transfers { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
