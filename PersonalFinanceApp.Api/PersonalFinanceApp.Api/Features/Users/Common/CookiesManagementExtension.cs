using static PersonalFinanceApp.Api.Features.Users.Login.Login;

namespace PersonalFinanceApp.Api.Features.Users.Common;

public static class CookiesManagementExtension
{
    public static void SetTokensInsideCookies(LoginResponse token,
        HttpContext context,
        IConfiguration configuration)
    {
        context.Response.Cookies.Append("accessToken", token.AccessToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None,
            Expires = DateTimeOffset.UtcNow.AddMinutes(configuration.GetValue<int>("Jwt:ExpirationInMinutes"))
        });

        context.Response.Cookies.Append("refreshToken", token.RefreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None,
            Expires = DateTimeOffset.UtcNow.AddDays(7)
        });
    }
}
