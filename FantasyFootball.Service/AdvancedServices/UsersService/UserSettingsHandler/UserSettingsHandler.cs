using FantasyFootball.Service.AdvancedServices.UsersService.UserSettingsHandler.Models;
using FantasyFootball.Service.PrimitiveServices.UsersService;
using Microsoft.AspNetCore.Http;
using System;

namespace FantasyFootball.Service.AdvancedServices.UsersService.UserSettingsHandler
{
    public class UserSettingsHandler : IUserSettingsHandler
    {
        // Primitive Services
        private IUsersServiceP _usersServiceP;

        // Http & Config
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserSettingsHandler(

            // Primitive Services
            IUsersServiceP usersServiceP,

            // Http & Config
            IHttpContextAccessor httpContextAccessor)
        {
            // Primitive Services
            _usersServiceP = usersServiceP;

            // Http & Config
            _httpContextAccessor = httpContextAccessor;
        }

        public UserSettingsGetResultModel Get(Guid userId)
        {
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
