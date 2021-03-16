using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.PlayerPositionRepository;

namespace FantasyFootball.Service.PrimitiveServices.PlayerPositionServiceP
{
    public class PlayerPositionServiceP : Service<PlayerPosition>, IPlayerPositionServiceP
    {
        public PlayerPositionServiceP(IPlayerPositionRepository<PlayerPosition> repository) : base(repository)
        {
        }

        public PlayerPosition Get(Guid playerPositionId) => Repository.FindAsync(playerPositionId).Result;

        public new void Insert(PlayerPosition playerPosition) => Repository.Insert(playerPosition);

        public new void Update(PlayerPosition playerPosition) => Repository.Update(playerPosition);

        public PlayerPosition Single(Expression<Func<PlayerPosition, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
