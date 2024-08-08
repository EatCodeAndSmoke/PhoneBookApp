using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.RequestBus
{
    public interface IAppPageRequest
    {
        public int PageNumber { get; set; }
        public int? RecordsOnPage { get; set; }
    }

    public abstract class AppPageRequest : AppRequest, IAppPageRequest
    {
        public int PageNumber { get; set; }
        public int? RecordsOnPage { get; set; }
    }

    public abstract class AppPageRequest<TBody> : AppRequest<TBody>, IAppPageRequest where TBody : class
    {
        public int PageNumber { get; set; }
        public int? RecordsOnPage { get; set; }
    }
}
