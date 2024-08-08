using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.RequestBus
{
    public record AppPageResult<T> where T : class
    {
        public AppPageResult(int totalRecords, IEnumerable<T> records)
        {
            TotalRecords = totalRecords;
            Records = records;
        }

        public int TotalRecords { get; }
        public int RecordsOnPage => Records?.Count() ?? 0;
        public bool HasRecords => RecordsOnPage > 0;
        public IEnumerable<T> Records { get; }
    }
}
