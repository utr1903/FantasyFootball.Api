using FantasyFootball.Entity.Models;
using FantasyFootball.Service.AdvancedServices.UsersService.Authenticator;
using FantasyFootball.Service.AdvancedServices.UsersService.Authenticator.Models;

namespace FantasyFootball.Service.AdvancedServices.UsersService
{
    public class UsersServiceA
    {
        private IAuthenticator _authenticator;

        public UsersServiceA(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public AuthenticationResultModel AuthenticateUser(User loginCredentials) =>
            _authenticator.AuthenticateUser(loginCredentials);
    }
}
