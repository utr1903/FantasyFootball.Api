using FantasyFootball.Entity.Models;
using FantasyFootball.Service.AdvancedServices.UsersService.Authenticator.Models;

namespace FantasyFootball.Service.AdvancedServices.UsersService
{
    public interface IUsersServiceA
    {
        AuthenticationResultModel AuthenticateUser(User loginCredentials);
    }
}
