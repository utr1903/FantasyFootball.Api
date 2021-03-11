using FantasyFootball.Entity.Models;
using FantasyFootball.Service.AdvancedServices.UsersService.Authenticator.Models;
using FantasyFootball.Service.AdvancedServices.UsersService.UserSettingsHandler.Models;
using System;

namespace FantasyFootball.Service.AdvancedServices.UsersService
{
    public interface IUsersServiceA
    {
        AuthenticationResultModel AuthenticateUser(User loginCredentials);
        UserSettingsGetResultModel GetUserSettings(Guid userId);
    }
}
