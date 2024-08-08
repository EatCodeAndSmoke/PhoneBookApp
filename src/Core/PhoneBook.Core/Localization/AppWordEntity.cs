using PhoneBook.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Localization
{
    public class AppWordEntity : AppEntity<int>
    {
        public string Code { get; set; }
        public ICollection<AppMeaningEntity> Meanings { get; set; }
    }
}
