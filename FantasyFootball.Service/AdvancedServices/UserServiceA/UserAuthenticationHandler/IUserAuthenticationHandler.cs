using FantasyFootball.Entity.Models;
using FantasyFootball.Service.AdvancedServices.UserServiceA.Authenticator.Models;

namespace FantasyFootball.Service.AdvancedServices.UserServiceA.UserAuthenticationHandler
{
    public interface IUserAuthenticationHandler
    {
        AuthenticationResultModel Authenticate(User loginCredentials);
    }
}
