using FantasyFootball.Entity.Models;
using FantasyFootball.Service.AdvancedServices.UsersService.Authenticator.Models;

namespace FantasyFootball.Service.AdvancedServices.UsersService.Authenticator
{
    public interface IAuthenticator
    {
        AuthenticationResultModel AuthenticateUser(User loginCredentials);
    }
}
