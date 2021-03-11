using FantasyFootball.Entity.Models;
using FantasyFootball.Service.AdvancedServices.UsersService.Authenticator.Models;

namespace FantasyFootball.Service.AdvancedServices.UsersService.UserAuthenticationHandler
{
    public interface IUserAuthenticationHandler
    {
        AuthenticationResultModel Authenticate(User loginCredentials);
    }
}
