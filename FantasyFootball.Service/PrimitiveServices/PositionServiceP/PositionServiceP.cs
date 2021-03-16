using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.PositionRepository;

namespace FantasyFootball.Service.PrimitiveServices.PositionServiceP
{
    public class PositionServiceP : Service<Position>, IPositionServiceP
    {
        public PositionServiceP(IPositionRepository<Position> repository) : base(repository)
        {
        }

        public Position Get(int positionId) => Repository.FindAsync(positionId).Result;

        public new void Insert(Position position) => Repository.Insert(position);

        public new void Update(Position position) => Repository.Update(position);

        public Position Single(Expression<Func<Position, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
