namespace PersonalFinanceApp.Api.Features.Users.Common;

public interface IPasswordHasher
{
    string Hash(string password);

    bool Verify(string password, string passwordHash);
}
