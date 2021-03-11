using FantasyFootball.Service.AdvancedServices.UsersService.UserSettingsHandler.Models;
using System;

namespace FantasyFootball.Service.AdvancedServices.UsersService.UserSettingsHandler
{
    public interface IUserSettingsHandler
    {
        UserSettingsGetResultModel Get(Guid userId);
    }
}
