using Microsoft.EntityFrameworkCore;
using PhoneBook.Core;
using PhoneBook.Core.Localization;
using PhoneBook.Infrastructure.DAL;

namespace PhoneBook.Infrastructure.Localization
{
    public class AppTranslator : IAppTranslator
    {
        private readonly PhoneBookDbContext _context;

        public AppTranslator(PhoneBookDbContext context)
        {
            _context = context;
        }

        public async ValueTask<string> TranslateAsync(string keyWord, AppLanguage lang)
        {
            if(string.IsNullOrEmpty(keyWord))
                return null;

            var result = await _context.Words.Include(x => x.Meanings).FirstOrDefaultAsync(x => x.Code == keyWord);
            return result?.Meanings?.FirstOrDefault(x => x.Lang == lang)?.Meaning;
        }

        public ValueTask<IDictionary<string, AppWordEntity>> TranslateEnumAsync<TEnum>() where TEnum : Enum
        {
            throw new NotImplementedException();
        }
    }
}
