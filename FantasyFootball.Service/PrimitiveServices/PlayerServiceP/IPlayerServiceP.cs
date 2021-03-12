using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.PlayerServiceP
{
    public interface IPlayerServiceP : IService<Player>
    {
        Player Get(Guid playerId);
        new void Insert(Player player);
        new void Update(Player player);
        Player Single(Expression<Func<Player, bool>> predicate);
    }
}
