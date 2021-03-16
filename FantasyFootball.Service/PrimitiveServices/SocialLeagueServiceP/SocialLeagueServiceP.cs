using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.SocialLeagueRepository;

namespace FantasyFootball.Service.PrimitiveServices.SocialLeagueServiceP
{
    public class SocialLeagueServiceP : Service<SocialLeague>, ISocialLeagueServiceP
    {
        public SocialLeagueServiceP(ISocialLeagueRepository<SocialLeague> repository) : base(repository)
        {
        }

        public SocialLeague Get(Guid socialLeagueId) => Repository.FindAsync(socialLeagueId).Result;

        public new void Insert(SocialLeague socialLeague) => Repository.Insert(socialLeague);

        public new void Update(SocialLeague socialLeague) => Repository.Update(socialLeague);

        public SocialLeague Single(Expression<Func<SocialLeague, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
