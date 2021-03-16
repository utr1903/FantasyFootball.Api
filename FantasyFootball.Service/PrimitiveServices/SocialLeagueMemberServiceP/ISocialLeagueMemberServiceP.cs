using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.SocialLeagueMemberServiceP
{
    public interface ISocialLeagueMemberServiceP : IService<SocialLeagueMember>
    {
        SocialLeagueMember Get(Guid socialLeagueMemberId);
        new void Insert(SocialLeagueMember socialLeagueMember);
        new void Update(SocialLeagueMember socialLeagueMember);
        SocialLeagueMember Single(Expression<Func<SocialLeagueMember, bool>> predicate);
    }
}
