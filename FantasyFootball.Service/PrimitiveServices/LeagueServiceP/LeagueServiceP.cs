using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.UserRepository;

namespace FantasyFootball.Service.PrimitiveServices.LeagueServiceP
{
    public class LeagueServiceP : Service<League>, ILeagueServiceP
    {
        public LeagueServiceP(IUserRepository<League> repository) : base(repository)
        {
        }

        public League Get(Guid leagueId) => Repository.FindAsync(leagueId).Result;

        public new void Insert(League league) => Repository.Insert(league);

        public new void Update(League league) => Repository.Update(league);

        public League Single(Expression<Func<League, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
