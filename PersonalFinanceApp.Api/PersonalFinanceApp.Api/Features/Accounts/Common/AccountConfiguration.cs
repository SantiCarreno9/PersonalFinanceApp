using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinanceApp.Api.Entities;

namespace PersonalFinanceApp.Api.Features.Accounts.Common;

internal sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.Name)
            .HasMaxLength(50);
        
        //builder.OwnsMany(typeof(User), "Users").OwnsMany(typeof(Account),"Accounts").;
    }
}
