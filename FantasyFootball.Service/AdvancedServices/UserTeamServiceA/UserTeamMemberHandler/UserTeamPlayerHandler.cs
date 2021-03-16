using FantasyFootball.Common.AuthChecker;
using FantasyFootball.Common.Exceptions;
using FantasyFootball.Entity.Models;
using FantasyFootball.Service.AdvancedServices.UserTeamServiceA.UserTeamMemberHandler.Models;
using FantasyFootball.Service.PrimitiveServices.PlayerHistoryServiceP;
using FantasyFootball.Service.PrimitiveServices.PlayerPositionServiceP;
using FantasyFootball.Service.PrimitiveServices.PositionServiceP;
using FantasyFootball.Service.PrimitiveServices.UserTeamPlayerServiceP;
using FantasyFootball.Service.PrimitiveServices.UserTeamServiceP;
using LinqKit;
using System;
using System.Linq;

namespace FantasyFootball.Service.AdvancedServices.UserTeamServiceA.UserTeamPlayerHandler
{
    public class UserTeamPlayerHandler
    {
        // Primitive Services
        private readonly IUserTeamServiceP _userTeamServiceP;
        private readonly IUserTeamPlayerServiceP _userTeamPlayerServiceP;
        private readonly IPlayerHistoryServiceP _playerHistoryServiceP;
        private readonly IPlayerPositionServiceP _playerPositionServiceP;
        private readonly IPositionServiceP _positionServiceP;

        // Commons
        private readonly IAuthChecker _authChecker;

        // Class Variables
        private Guid _callerId;

        public UserTeamPlayerHandler(
            
            // Primitive Services
            IUserTeamServiceP userTeamServiceP,
            IUserTeamPlayerServiceP userTeamPlayerServiceP,
            IPlayerHistoryServiceP playerHistoryServiceP,
            IPlayerPositionServiceP playerPositionServiceP,
            IPositionServiceP positionServiceP,

            // Commons
            IAuthChecker authChecker)
        {
            // Primitive Services
            _userTeamServiceP = userTeamServiceP;
            _userTeamPlayerServiceP = userTeamPlayerServiceP;
            _playerHistoryServiceP = playerHistoryServiceP;
            _playerPositionServiceP = playerPositionServiceP;
            _positionServiceP = positionServiceP;

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

            var position = _positionServiceP.Get(dto.PositionId);
            if (position == null)
                throw new PositionNotFound();

            var predicatePosition = PredicateBuilder.New<PlayerPosition>(true);
            predicatePosition = predicatePosition.And(x => x.PlayerId == playerHistory.PlayerId);
            predicatePosition = predicatePosition.And(x => x.PositionId == position.Id);

            var canPlayOnGivenPosition = _playerPositionServiceP.Queryable().Where(predicatePosition).Any();
            if (!canPlayOnGivenPosition)
                throw new PlayerPositionNotValid();

            var predicateUserTeamPlayer = PredicateBuilder.New<UserTeamPlayer>(true);
            predicateUserTeamPlayer = predicateUserTeamPlayer.And(x => x.UserTeamId == userTeam.Id);
            predicateUserTeamPlayer = predicateUserTeamPlayer.And(x => x.PlayerHistoryId == playerHistory.Id);
            predicateUserTeamPlayer = predicateUserTeamPlayer.And(x => x.PositionId == position.Id);

            var oldPlayerOnGivenPosition = _userTeamPlayerServiceP.Queryable().Where(predicateUserTeamPlayer).FirstOrDefault();
            if (oldPlayerOnGivenPosition != null)
                _userTeamPlayerServiceP.Delete(oldPlayerOnGivenPosition);

            var newPlayerOnGivenPosition = new UserTeamPlayer
            {
                Id = Guid.NewGuid(),
                PlayerHistoryId = playerHistory.Id,
                UserTeamId = userTeam.Id,
                PositionId = position.Id
            };

            _userTeamPlayerServiceP.Insert(newPlayerOnGivenPosition);
        }
    }
}
