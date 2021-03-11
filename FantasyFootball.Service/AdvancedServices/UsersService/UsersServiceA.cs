using FantasyFootball.Entity.Models;
using FantasyFootball.Service.AdvancedServices.UsersService.Authenticator;
using FantasyFootball.Service.AdvancedServices.UsersService.Authenticator.Models;
using Microsoft.AspNetCore.Http;

namespace FantasyFootball.Service.AdvancedServices.UsersService
{
    public class UsersServiceA : IUsersServiceA
    {
        // Custom Classes
        private IUserAuthenticator _authenticator;

        // Http & Config
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersServiceA(
            
            // Custom Classes
            IUserAuthenticator authenticator,

            // Http & Config
            IHttpContextAccessor httpContextAccessor)
        {
            // Custom Classes
            _authenticator = authenticator;

            // Http & Config
            _httpContextAccessor = httpContextAccessor;
        }

        public AuthenticationResultModel AuthenticateUser(User loginCredentials) =>
            _authenticator.Run(loginCredentials);
    }
}
