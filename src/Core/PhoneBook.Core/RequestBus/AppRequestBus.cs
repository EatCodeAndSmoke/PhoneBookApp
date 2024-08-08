using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.RequestBus
{
    public interface IAppRequestBus
    {
        Task<AppOutput> SendAsync(AppRequest req);
    }
}
