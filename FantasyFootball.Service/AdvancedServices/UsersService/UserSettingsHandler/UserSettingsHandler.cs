using FantasyFootball.Common.AuthChecker;
using FantasyFootball.Service.AdvancedServices.UsersService.UserSettingsHandler.Models;
using FantasyFootball.Service.PrimitiveServices.UsersService;
using Microsoft.AspNetCore.Http;
using System;

namespace FantasyFootball.Service.AdvancedServices.UsersService.UserSettingsHandler
{
    public class UserSettingsHandler : IUserSettingsHandler
    {
        // Primitive Services
        private readonly IUsersServiceP _usersServiceP;

        // Commons
        private readonly IAuthChecker _authChecker;

        public UserSettingsHandler(

            // Primitive Services
            IUsersServiceP usersServiceP,

            // Commons
            IAuthChecker authChecker)
        {
            // Primitive Services
            _usersServiceP = usersServiceP;

            // Commons
            _authChecker = authChecker;
        }

        public UserSettingsGetResultModel Get(Guid userId)
        {
            var callerId = _authChecker.GetCallerId();
            if (callerId != userId)
                throw new Exception("NoAuthorization");

            var user = _usersServiceP.Get(userId);
            if (user == null)
                throw new Exception("UserNotFound");

            var result = new UserSettingsGetResultModel
            {
                Username = user.Username,
                Password = user.Password
            };

            return result;
        }
    }
}
