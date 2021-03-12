using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.PositionServiceP
{
    public interface IPositionServiceP : IService<Position>
    {
        Position Get(Guid positionId);
        new void Insert(Position position);
        new void Update(Position position);
        Position Single(Expression<Func<Position, bool>> predicate);
    }
}
