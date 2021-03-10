using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.UserRepository;

namespace FantasyFootball.Service.PrimitiveServices.UsersService
{
    public class UsersServiceP : Service<Users>, IUsersServiceP
    {
        public UsersServiceP(IUsersRepository<Users> repository) : base(repository)
        {
        }

        public Users Single(Expression<Func<Users, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
