using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.PlayerHistoryRepository;

namespace FantasyFootball.Service.PrimitiveServices.PlayerHistoryServiceP
{
    public class PlayerHistoryServiceP : Service<PlayerHistory>, IPlayerHistoryServiceP
    {
        public PlayerHistoryServiceP(IPlayerHistoryRepository<PlayerHistory> repository) : base(repository)
        {
        }

        public PlayerHistory Get(Guid playerHistoryId) => Repository.FindAsync(playerHistoryId).Result;

        public new void Insert(PlayerHistory playerHistory) => Repository.Insert(playerHistory);

        public new void Update(PlayerHistory playerHistory) => Repository.Update(playerHistory);

        public PlayerHistory Single(Expression<Func<PlayerHistory, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
