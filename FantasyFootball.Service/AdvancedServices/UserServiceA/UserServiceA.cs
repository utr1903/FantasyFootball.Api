using FantasyFootball.Entity.Models;
using FantasyFootball.Service.AdvancedServices.UserServiceA.UserAuthenticationHandler;
using FantasyFootball.Service.AdvancedServices.UserServiceA.Authenticator.Models;
using System;
using FantasyFootball.Service.AdvancedServices.UserServiceA.UserSettingsHandler.Models;
using FantasyFootball.Service.AdvancedServices.UserServiceA.UserSettingsHandler;

namespace FantasyFootball.Service.AdvancedServices.UserServiceA
{
    public class UserServiceA : IUserServiceA
    {
        // Custom Classes
        private readonly IUserAuthenticationHandler _userAuthenticationHandler;
        private readonly IUserSettingsHandler _userSettingsHandler;        

        public UserServiceA(
            
            // Custom Classes
            IUserAuthenticationHandler authenticator, IUserSettingsHandler userSettingsHandler)
        {
            // Custom Classes
            _userAuthenticationHandler = authenticator;
            _userSettingsHandler = userSettingsHandler;
        }

        public AuthenticationResultModel AuthenticateUser(User loginCredentials) =>
            _userAuthenticationHandler.Authenticate(loginCredentials);

        public UserSettingsGetResultModel GetUserSettings(Guid userId) =>
            _userSettingsHandler.GetUserSettings(userId);
    }
}
