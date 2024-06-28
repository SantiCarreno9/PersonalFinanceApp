using System.Security.Claims;

namespace BaseLibrary.Extensions
{
    public static class ClaimsExtensionMethods
    {
        public static string GetUserId(this ClaimsPrincipal User)
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        }
    }
}
