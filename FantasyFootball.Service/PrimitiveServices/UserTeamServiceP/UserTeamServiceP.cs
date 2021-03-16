using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.UserTeamRepository;

namespace FantasyFootball.Service.PrimitiveServices.UserTeamServiceP
{
    public class UserTeamServiceP : Service<UserTeam>, IUserTeamServiceP
    {
        public UserTeamServiceP(IUserTeamRepository<UserTeam> repository) : base(repository)
        {
        }

        public UserTeam Get(Guid userTeamId) => Repository.FindAsync(userTeamId).Result;

        public new void Insert(UserTeam userTeam) => Repository.Insert(userTeam);

        public new void Update(UserTeam userTeam) => Repository.Update(userTeam);

        public UserTeam Single(Expression<Func<UserTeam, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
