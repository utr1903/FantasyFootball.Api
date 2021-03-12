using FantasyFootball.Common.AuthChecker;
using FantasyFootball.Common.Exceptions;
using FantasyFootball.Service.AdvancedServices.UsersService.UserSettingsHandler.Models;
using FantasyFootball.Service.PrimitiveServices.UserServiceP;
using Microsoft.AspNetCore.Http;
using System;

namespace FantasyFootball.Service.AdvancedServices.UsersService.UserSettingsHandler
{
    public class UserSettingsHandler : IUserSettingsHandler
    {
        // Primitive Services
        private readonly IUserServiceP _usersServiceP;

        // Commons
        private readonly IAuthChecker _authChecker;

        public UserSettingsHandler(

            // Primitive Services
            IUserServiceP usersServiceP,

            // Commons
            IAuthChecker authChecker)
        {
            // Primitive Services
            _usersServiceP = usersServiceP;

            // Commons
            _authChecker = authChecker;
        }

        public UserSettingsGetResultModel GetUserSettings(Guid userId)
        {
            var callerId = _authChecker.GetCallerId();
            if (callerId != userId)
                throw new UserNotAuthorized();

            var user = _usersServiceP.Get(userId);
            if (user == null)
                throw new UserNotFound();

            var result = new UserSettingsGetResultModel
            {
                Username = user.Username,
                Password = user.Password
            };

            return result;
        }
    }
}
