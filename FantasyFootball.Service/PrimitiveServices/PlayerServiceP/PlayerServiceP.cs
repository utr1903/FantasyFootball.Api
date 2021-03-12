using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.UserRepository;

namespace FantasyFootball.Service.PrimitiveServices.PlayerServiceP
{
    public class PlayerServiceP : Service<Player>, IPlayerServiceP
    {
        public PlayerServiceP(IUserRepository<Player> repository) : base(repository)
        {
        }

        public Player Get(Guid playerId) => Repository.FindAsync(playerId).Result;

        public new void Insert(Player player) => Repository.Insert(player);

        public new void Update(Player player) => Repository.Update(player);

        public Player Single(Expression<Func<Player, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
