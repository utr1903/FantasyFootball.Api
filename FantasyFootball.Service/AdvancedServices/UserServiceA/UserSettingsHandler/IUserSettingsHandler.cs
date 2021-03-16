using FantasyFootball.Service.AdvancedServices.UserServiceA.UserSettingsHandler.Models;
using System;

namespace FantasyFootball.Service.AdvancedServices.UserServiceA.UserSettingsHandler
{
    public interface IUserSettingsHandler
    {
        UserSettingsGetResultModel GetUserSettings(Guid userId);
    }
}
