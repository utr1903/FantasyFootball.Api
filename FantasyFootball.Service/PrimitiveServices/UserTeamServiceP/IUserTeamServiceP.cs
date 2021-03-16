using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.UserTeamServiceP
{
    public interface IUserTeamServiceP : IService<UserTeam>
    {
        UserTeam Get(Guid userTeamId);
        new void Insert(UserTeam userTeam);
        new void Update(UserTeam userTeam);
        UserTeam Single(Expression<Func<UserTeam, bool>> predicate);
    }
}
