using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.PlayerHistoryServiceP
{
    public interface IPlayerHistoryServiceP : IService<PlayerHistory>
    {
        PlayerHistory Get(Guid playerHistoryId);
        new void Insert(PlayerHistory playerHistory);
        new void Update(PlayerHistory playerHistory);
        PlayerHistory Single(Expression<Func<PlayerHistory, bool>> predicate);
    }
}
