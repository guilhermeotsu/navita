using Microsoft.AspNetCore.Http;
using Navita.Core.Interfaces;
using System;
using System.Security.Claims;

namespace Nativa.API.Extensions
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        
        public string Name => _accessor.HttpContext.User.Identity.Name;

        public Guid GetUserId()
            => IsAuthenicated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;

        public string GetUserEmail()
            => IsAuthenicated() ? _accessor.HttpContext.User.GetUserEmail() : null;

        public bool IsAuthenicated()
            => _accessor.HttpContext.User.Identity.IsAuthenticated;
    }

    public static class ClaimsPrincipalExtension
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst(ClaimTypes.Email);
            return claim?.Value;
        }
    }
}
