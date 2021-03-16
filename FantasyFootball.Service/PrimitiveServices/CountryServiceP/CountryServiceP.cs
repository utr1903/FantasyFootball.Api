using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.UserRepository;
using FantasyFootball.Repositories.CountryRepository;

namespace FantasyFootball.Service.PrimitiveServices.CountryServiceP
{
    public class CountryServiceP : Service<Country>, ICountryServiceP
    {
        public CountryServiceP(ICountryRepository<Country> repository) : base(repository)
        {
        }

        public Country Get(Guid countryId) => Repository.FindAsync(countryId).Result;

        public new void Insert(Country country) => Repository.Insert(country);

        public new void Update(Country country) => Repository.Update(country);

        public Country Single(Expression<Func<Country, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
