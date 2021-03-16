using FantasyFootball.Common.AuthChecker;
using FantasyFootball.Common.Exceptions;
using FantasyFootball.Service.AdvancedServices.UserTeamService.UserTeamMemberHandler.Models;
using FantasyFootball.Service.PrimitiveServices.PlayerHistoryServiceP;
using FantasyFootball.Service.PrimitiveServices.UserTeamPlayerServiceP;
using FantasyFootball.Service.PrimitiveServices.UserTeamServiceP;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyFootball.Service.AdvancedServices.UserTeamService.UserTeamPlayerHandler
{
    public class UserTeamPlayerHandler
    {
        // Primitive Services
        private readonly IUserTeamServiceP _userTeamServiceP;
        private readonly IUserTeamPlayerServiceP _userTeamPlayerServiceP;
        private readonly IPlayerHistoryServiceP _playerHistoryServiceP;

        private readonly IAuthChecker _authChecker;

        // Class Variables
        private Guid _callerId;

        public UserTeamPlayerHandler(
            
            // Primitive Services
            IUserTeamServiceP userTeamServiceP,
            IUserTeamPlayerServiceP userTeamPlayerServiceP,
            IPlayerHistoryServiceP playerHistoryServiceP,
            
            // Commons
            IAuthChecker authChecker)
        {
            // Primitive Services
            _userTeamServiceP = userTeamServiceP;
            _userTeamPlayerServiceP = userTeamPlayerServiceP;
            _playerHistoryServiceP = playerHistoryServiceP;

            // Commons
            _authChecker = authChecker;
        }

        public void AddPlayerToTeam(AddUserTeamPlayerRequestModel dto)
        {
            _callerId = _authChecker.GetCallerId();

            var userTeam = _userTeamServiceP.Get(dto.UserTeamId);
            if (userTeam == null)
                throw new UserTeamNotFound();

            if (userTeam.UserId != _callerId)
                throw new UserNotAuthorized();

            var playerHistory = _playerHistoryServiceP.Get(dto.PlayerHistoryId);
            if (playerHistory == null)
                throw new PlayerHistoryNotFound();


        }
    }
}
