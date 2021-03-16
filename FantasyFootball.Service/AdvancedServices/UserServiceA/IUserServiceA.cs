using FantasyFootball.Entity.Models;
using FantasyFootball.Service.AdvancedServices.UserServiceA.Authenticator.Models;
using FantasyFootball.Service.AdvancedServices.UserServiceA.UserSettingsHandler.Models;
using System;

namespace FantasyFootball.Service.AdvancedServices.UserServiceA
{
    public interface IUserServiceA
    {
        AuthenticationResultModel AuthenticateUser(User loginCredentials);
        UserSettingsGetResultModel GetUserSettings(Guid userId);
    }
}
