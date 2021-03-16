using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.UserTeamPlayerServiceP
{
    public interface IUserTeamPlayerServiceP : IService<UserTeamPlayer>
    {
        UserTeamPlayer Get(Guid userTeamPlayerId);
        new void Insert(UserTeamPlayer userTeamPlayer);
        new void Update(UserTeamPlayer userTeamPlayer);
        UserTeamPlayer Single(Expression<Func<UserTeamPlayer, bool>> predicate);
    }
}
