using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.UserTeamPlayerRepository;

namespace FantasyFootball.Service.PrimitiveServices.UserTeamPlayerServiceP
{
    public class UserTeamPlayerServiceP : Service<UserTeamPlayer>, IUserTeamPlayerServiceP
    {
        public UserTeamPlayerServiceP(IUserTeamPlayerRepository<UserTeamPlayer> repository) : base(repository)
        {
        }

        public UserTeamPlayer Get(Guid userTeamPlayerId) => Repository.FindAsync(userTeamPlayerId).Result;

        public new void Insert(UserTeamPlayer userTeamPlayer) => Repository.Insert(userTeamPlayer);

        public new void Update(UserTeamPlayer userTeamPlayer) => Repository.Update(userTeamPlayer);

        public UserTeamPlayer Single(Expression<Func<UserTeamPlayer, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
