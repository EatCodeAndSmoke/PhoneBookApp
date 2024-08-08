using PhoneBook.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Localization
{
    public class AppMeaningEntity : AppEntity<int>
    {
        public AppLanguage Lang { get; set; }
        public string Meaning { get; set; }
        public int WordId { get; set; }
        public AppWordEntity Word { get; set; }
    }
}
