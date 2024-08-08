using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Localization
{
    public interface IAppTranslator
    {
        ValueTask<string> TranslateAsync(string keyWord, AppLanguage lang);
        ValueTask<IDictionary<string, AppWordEntity>> TranslateEnumAsync<TEnum>() where TEnum : Enum;
    }
}
