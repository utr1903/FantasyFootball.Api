using FantasyFootball.Entity.Models;
using FantasyFootball.Service.AdvancedServices.UsersService.UserAuthenticationHandler;
using FantasyFootball.Service.AdvancedServices.UsersService.Authenticator.Models;
using System;
using FantasyFootball.Service.AdvancedServices.UsersService.UserSettingsHandler.Models;
using FantasyFootball.Service.AdvancedServices.UsersService.UserSettingsHandler;

namespace FantasyFootball.Service.AdvancedServices.UsersService
{
    public class UsersServiceA : IUsersServiceA
    {
        // Custom Classes
        private readonly IUserAuthenticationHandler _userAuthenticationHandler;
        private readonly IUserSettingsHandler _userSettingsHandler;        

        public UsersServiceA(
            
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
            _userSettingsHandler.Get(userId);
    }
}
