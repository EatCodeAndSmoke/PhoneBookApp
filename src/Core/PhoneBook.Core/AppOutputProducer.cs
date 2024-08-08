using System.Net;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.Cacheing;
using PhoneBook.Core.DAL;
using PhoneBook.Core.Exceptions;
using PhoneBook.Core.Localization;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Core
{
    public class AppOutputProducer
    {
        private readonly Lazy<IAppUnitOfWork> _unitOfWorkLazy;
        private readonly Lazy<IAppRequestBus> _requestBusLazy;
        private readonly Lazy<IAppTranslator> _translatorLazy;
        private readonly Lazy<IAppCache> _cacheLazy;

        protected AppOutputProducer(IServiceProvider services)
        {
            Services = services;
            _unitOfWorkLazy = new Lazy<IAppUnitOfWork>(() => Services.GetRequiredService<IAppUnitOfWork>());
            _requestBusLazy = new Lazy<IAppRequestBus>(() => Services.GetRequiredService<IAppRequestBus>());
            _translatorLazy = new Lazy<IAppTranslator>(() => Services.GetRequiredService<IAppTranslator>());
            _cacheLazy = new Lazy<IAppCache>(() => Services.GetRequiredService<IAppCache>());
        }

        protected IServiceProvider Services { get; }
        public IAppUnitOfWork UnitOfWork => _unitOfWorkLazy.Value;
        public IAppRequestBus RequestBus => _requestBusLazy.Value;
        public IAppTranslator Translator => _translatorLazy.Value;
        public IAppCache Cache => _cacheLazy.Value;

        public AppOutput Ok(string responseCode = null) => AppOutput.Create((int)HttpStatusCode.OK, responseCode);
        public AppOutput<TResult> Ok<TResult>(TResult result, string responseCode = null) => AppOutput.Create((int)HttpStatusCode.OK, responseCode, result);
        public AppOutput BadRequest(string responseCode) => AppOutput.Create((int)HttpStatusCode.BadRequest, responseCode);
        public AppOutput BadRequest(IEnumerable<AppErrorDescriptor> errors, string responseCode = null) => AppOutput.Create((int)HttpStatusCode.BadRequest, responseCode, errors);
        public AppOutput Unautorized(string responseCode) => AppOutput.Create((int)HttpStatusCode.Unauthorized, responseCode);
        public AppOutput Forbidden(string responseCode) => AppOutput.Create((int)HttpStatusCode.Forbidden, responseCode);
        public AppOutput InternalError(string responseCode = null) => AppOutput.Create((int)HttpStatusCode.InternalServerError, responseCode);
        public AppOutput FromException(Exception ex) => AppOutput.Create(ex);
    }
}
