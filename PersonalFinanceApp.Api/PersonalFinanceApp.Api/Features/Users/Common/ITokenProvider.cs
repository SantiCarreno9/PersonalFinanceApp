using PersonalFinanceApp.Api.Entities;

namespace PersonalFinanceApp.Api.Features.Users.Common;

public interface ITokenProvider
{
    string Create(User user);
    string GenerateRefreshToken();
}
