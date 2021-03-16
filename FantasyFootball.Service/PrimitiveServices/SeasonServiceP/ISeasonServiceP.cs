using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.SeasonServiceP
{
    public interface ISeasonServiceP : IService<Season>
    {
        Season Get(Guid seasonId);
        new void Insert(Season season);
        new void Update(Season season);
        Season Single(Expression<Func<Season, bool>> predicate);
    }
}
