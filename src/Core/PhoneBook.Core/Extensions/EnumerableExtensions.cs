using PhoneBook.Core.RequestBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Extensions
{
    public static class EnumerableExtensions
    {

        public static AppPageResult<T> ToPage<T>(this IEnumerable<T> query, int PageN, int? recordOnPage) where T : class
        {
            var totalCount = query.Count();

            if (PageN < 1)
                PageN = 1;

            var skip = (PageN - 1) * (recordOnPage ?? 0);
            var result = query.Skip(skip);

            if (recordOnPage.HasValue)
                result = result.Take(recordOnPage.Value);

            var lst = result.ToList();
            return new AppPageResult<T>(totalCount, lst);
        }
    }
}
