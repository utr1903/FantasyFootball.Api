using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace FantasyFootball.Common.AuthChecker
{
    public class AuthChecker : IAuthChecker
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthChecker(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetCallerId() =>
            Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
    }
}
