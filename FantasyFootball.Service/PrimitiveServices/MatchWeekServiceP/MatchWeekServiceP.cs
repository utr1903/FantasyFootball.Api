using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.MatchWeekRepository;

namespace FantasyFootball.Service.PrimitiveServices.MatchWeekServiceP
{
    public class MatchWeekServiceP : Service<MatchWeek>, IMatchWeekServiceP
    {
        public MatchWeekServiceP(IMatchWeekRepository<MatchWeek> repository) : base(repository)
        {
        }

        public MatchWeek Get(Guid matchWeekId) => Repository.FindAsync(matchWeekId).Result;

        public new void Insert(MatchWeek matchWeek) => Repository.Insert(matchWeek);

        public new void Update(MatchWeek matchWeek) => Repository.Update(matchWeek);

        public MatchWeek Single(Expression<Func<MatchWeek, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
