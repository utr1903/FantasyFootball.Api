using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.SocialLeagueServiceP
{
    public interface ISocialLeagueServiceP : IService<SocialLeague>
    {
        SocialLeague Get(Guid socialLeagueId);
        new void Insert(SocialLeague socialLeague);
        new void Update(SocialLeague socialLeague);
        SocialLeague Single(Expression<Func<SocialLeague, bool>> predicate);
    }
}
