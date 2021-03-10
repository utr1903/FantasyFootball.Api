using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.UsersService
{
    public interface IUsersServiceP : IService<Users>
    {
        Users Single(Expression<Func<Users, bool>> predicate);
    }
}
