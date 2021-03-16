using FantasyFootball.Common.AuthChecker;
using FantasyFootball.Common.Exceptions;
using FantasyFootball.Entity.Models;
using FantasyFootball.Service.AdvancedServices.UserTeamServiceA.UserTeamMemberHandler.Models;
using FantasyFootball.Service.PrimitiveServices.PlayerHistoryServiceP;
using FantasyFootball.Service.PrimitiveServices.PlayerPositionServiceP;
using FantasyFootball.Service.PrimitiveServices.UserTeamPlayerServiceP;
using FantasyFootball.Service.PrimitiveServices.UserTeamServiceP;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyFootball.Service.AdvancedServices.UserTeamServiceA.UserTeamPlayerHandler
{
    public class UserTeamPlayerHandler
    {
        // Primitive Services
        private readonly IUserTeamServiceP _userTeamServiceP;
        private readonly IUserTeamPlayerServiceP _userTeamPlayerServiceP;
        private readonly IPlayerHistoryServiceP _playerHistoryServiceP;
        private readonly IPlayerPositionServiceP _playerPositionServiceP;

        private readonly IAuthChecker _authChecker;

        // Class Variables
        private Guid _callerId;

        public UserTeamPlayerHandler(
            
            // Primitive Services
            IUserTeamServiceP userTeamServiceP,
            IUserTeamPlayerServiceP userTeamPlayerServiceP,
            IPlayerHistoryServiceP playerHistoryServiceP,
            IPlayerPositionServiceP playerPositionServiceP,

            // Commons
            IAuthChecker authChecker)
        {
            // Primitive Services
            _userTeamServiceP = userTeamServiceP;
            _userTeamPlayerServiceP = userTeamPlayerServiceP;
            _playerHistoryServiceP = playerHistoryServiceP;
            _playerPositionServiceP = playerPositionServiceP;

            // Commons
            _authChecker = authChecker;
        }

        // TODO : Add check for formation -> whether the formation has the given position !!!
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

            var predicatePosition = PredicateBuilder.New<PlayerPosition>(true);
            predicatePosition = predicatePosition.And(x => x.PlayerId == playerHistory.PlayerId);
            predicatePosition = predicatePosition.And(x => x.PositionId == dto.PositionId);

            var canPlayOnGivenPosition = _playerPositionServiceP.Queryable().Where(predicatePosition).Any();
            if (!canPlayOnGivenPosition)
                throw new PlayerPositionNotValid();

        }
    }
}
