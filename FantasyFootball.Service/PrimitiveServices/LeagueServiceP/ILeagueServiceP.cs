using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.LeagueServiceP
{
    public interface ILeagueServiceP : IService<League>
    {
        League Get(Guid leagueId);
        new void Insert(League league);
        new void Update(League league);
        League Single(Expression<Func<League, bool>> predicate);
    }
}
