using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.SeasonRepository;

namespace FantasyFootball.Service.PrimitiveServices.SeasonServiceP
{
    public class SeasonServiceP : Service<Season>, ISeasonServiceP
    {
        public SeasonServiceP(ISeasonRepository<Season> repository) : base(repository)
        {
        }

        public Season Get(Guid seasonId) => Repository.FindAsync(seasonId).Result;

        public new void Insert(Season season) => Repository.Insert(season);

        public new void Update(Season season) => Repository.Update(season);

        public Season Single(Expression<Func<Season, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
