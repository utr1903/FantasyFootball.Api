using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.ClubServiceP
{
    public interface IClubServiceP : IService<Club>
    {
        Club Get(Guid clubId);
        new void Insert(Club club);
        new void Update(Club club);
        Club Single(Expression<Func<Club, bool>> predicate);
    }
}
