using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.UserServiceP
{
    public interface IUserServiceP : IService<User>
    {
        User Get(Guid userId);
        new void Insert(User user);
        new void Update(User user);
        User Single(Expression<Func<User, bool>> predicate);
    }
}
