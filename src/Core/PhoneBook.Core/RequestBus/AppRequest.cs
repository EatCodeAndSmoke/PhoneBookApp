using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.RequestBus
{
    public abstract class AppRequest : AppInput, IRequest, IRequest<AppOutput>
    {
    }

    public abstract class AppRequest<TBody> : AppRequest, IAppInput<TBody> where TBody : class
    {
        public TBody Body { get; set; }
    }
}
