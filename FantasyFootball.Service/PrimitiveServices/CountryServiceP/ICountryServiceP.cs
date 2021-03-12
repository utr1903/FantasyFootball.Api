using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.CountryServiceP
{
    public interface ICountryServiceP : IService<Country>
    {
        Country Get(Guid countryId);
        new void Insert(Country country);
        new void Update(Country country);
        Country Single(Expression<Func<Country, bool>> predicate);
    }
}
