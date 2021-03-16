using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.FormationServiceP
{
    public interface IFormationServiceP : IService<Formation>
    {
        Formation Get(Guid formationId);
        new void Insert(Formation formation);
        new void Update(Formation formation);
        Formation Single(Expression<Func<Formation, bool>> predicate);
    }
}
