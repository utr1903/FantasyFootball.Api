using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.UserRepository;

namespace FantasyFootball.Service.PrimitiveServices.UserServiceP
{
    public class UserServiceP : Service<User>, IUserServiceP
    {
        public UserServiceP(IUserRepository<User> repository) : base(repository)
        {
        }

        public User Get(Guid userId) => Repository.FindAsync(userId).Result;

        public new void Insert(User user) => Repository.Insert(user);

        public new void Update(User user) => Repository.Update(user);

        public User Single(Expression<Func<User, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
