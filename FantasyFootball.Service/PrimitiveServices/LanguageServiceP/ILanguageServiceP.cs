using FantasyFootball.Entity.Models;
using System;
using System.Linq.Expressions;
using URF.Core.Abstractions.Services;

namespace FantasyFootball.Service.PrimitiveServices.LanguageServiceP
{
    public interface ILanguageServiceP : IService<Language>
    {
        Language Get(Guid languageId);
        new void Insert(Language language);
        new void Update(Language language);
        Language Single(Expression<Func<Language, bool>> predicate);
    }
}
