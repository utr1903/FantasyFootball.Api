using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.PlayerPositionServiceP
{
    public interface IPlayerPositionServiceP : IService<PlayerPosition>
    {
        PlayerPosition Get(Guid playerPositionId);
        new void Insert(PlayerPosition playerPosition);
        new void Update(PlayerPosition playerPosition);
        PlayerPosition Single(Expression<Func<PlayerPosition, bool>> predicate);
    }
}
