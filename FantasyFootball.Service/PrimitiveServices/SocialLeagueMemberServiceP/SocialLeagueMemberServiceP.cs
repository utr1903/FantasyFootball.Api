using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.SocialLeagueMemberRepository;

namespace FantasyFootball.Service.PrimitiveServices.SocialLeagueMemberServiceP
{
    public class SocialLeagueMemberServiceP : Service<SocialLeagueMember>, ISocialLeagueMemberServiceP
    {
        public SocialLeagueMemberServiceP(ISocialLeagueMemberRepository<SocialLeagueMember> repository) : base(repository)
        {
        }

        public SocialLeagueMember Get(Guid socialLeagueMemberMemberId) => Repository.FindAsync(socialLeagueMemberMemberId).Result;

        public new void Insert(SocialLeagueMember socialLeagueMemberMember) => Repository.Insert(socialLeagueMemberMember);

        public new void Update(SocialLeagueMember socialLeagueMemberMember) => Repository.Update(socialLeagueMemberMember);

        public SocialLeagueMember Single(Expression<Func<SocialLeagueMember, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
