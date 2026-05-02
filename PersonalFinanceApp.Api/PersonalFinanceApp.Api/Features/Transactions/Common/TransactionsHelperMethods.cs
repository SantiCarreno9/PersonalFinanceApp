using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Entities;

namespace PersonalFinanceApp.Api.Features.Transactions.Common;

internal static class TransactionsHelperMethods
{
    public static IQueryable<Transaction> FilterTransactions(IQueryable<Transaction> transactionsQueryable, TransactionFilters filters)
    {
        if (filters == null)
            return transactionsQueryable;

        if (filters.Type != null)
            transactionsQueryable = transactionsQueryable.Where(t => t.Type == filters.Type);

        if (filters.StartDate.HasValue)
            transactionsQueryable = transactionsQueryable.Where(t => t.Date.CompareTo(filters.StartDate.Value) >= 0);

        if (filters.EndDate.HasValue)
            transactionsQueryable = transactionsQueryable.Where(t => t.Date.CompareTo(filters.EndDate.Value) <= 0);

        if (filters.MinAmount != null)
            transactionsQueryable = transactionsQueryable.Where(t => (double)t.TotalAmount >= (double)filters.MinAmount);

        if (filters.MaxAmount != null)
            transactionsQueryable = transactionsQueryable.Where(t => (double)t.TotalAmount <= (double)filters.MaxAmount);

        if (!string.IsNullOrEmpty(filters.Location))
            transactionsQueryable = transactionsQueryable.Where(t => !string.IsNullOrEmpty(t.Location) && t.Location.Contains(filters.Location, StringComparison.CurrentCultureIgnoreCase));

        if (filters.PaymentMethods != null)
            transactionsQueryable = transactionsQueryable.Where(t => filters.PaymentMethods.Contains(t.PaymentMethod));

        if (filters.Categories != null)
        {
            transactionsQueryable = transactionsQueryable
                .AsNoTracking()
                .Include(t => t.TransactionDetails);
            transactionsQueryable = transactionsQueryable.Where(t => filters.Categories.Contains(t.Category)
            || t.Category == Category.Multiple && t.TransactionDetails.FirstOrDefault(td => filters.Categories.Contains(td.Category)) != null);
        }

        if (!string.IsNullOrWhiteSpace(filters.Description))
        {
            transactionsQueryable = transactionsQueryable
                .AsNoTracking()
                .Include(t => t.TransactionDetails);
            transactionsQueryable = transactionsQueryable.Where(t => t.TransactionDetails.FirstOrDefault(td => !string.IsNullOrEmpty(td.Description) &&
                                td.Description.Contains(filters.Description, StringComparison.CurrentCultureIgnoreCase)) != null);
        }

        return transactionsQueryable;
    }

    //public static bool IsCurrentUserAccount(DBSet<Account> accounts, int accountId, int userId)
    //{
    //    return accounts.
    //}
}
