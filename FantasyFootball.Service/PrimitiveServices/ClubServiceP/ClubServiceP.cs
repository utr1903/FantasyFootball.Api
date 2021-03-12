using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.UserRepository;

namespace FantasyFootball.Service.PrimitiveServices.ClubServiceP
{
    public class ClubServiceP : Service<Club>, IClubServiceP
    {
        public ClubServiceP(IUserRepository<Club> repository) : base(repository)
        {
        }

        public Club Get(Guid clubId) => Repository.FindAsync(clubId).Result;

        public new void Insert(Club club) => Repository.Insert(club);

        public new void Update(Club club) => Repository.Update(club);

        public Club Single(Expression<Func<Club, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
