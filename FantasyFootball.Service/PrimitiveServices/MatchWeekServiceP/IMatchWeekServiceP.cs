using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.MatchWeekServiceP
{
    public interface IMatchWeekServiceP : IService<MatchWeek>
    {
        MatchWeek Get(Guid matchWeekId);
        new void Insert(MatchWeek matchWeek);
        new void Update(MatchWeek matchWeek);
        MatchWeek Single(Expression<Func<MatchWeek, bool>> predicate);
    }
}
