using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core
{
    #region Interfaces
    /// <summary>
    /// აპლიკაციის რექუესთი, ტანის გარეშე
    /// </summary>
    public interface IAppInput
    {
        public string Id { get; set; }
        public string CorrelationId { get; set; }
        public string Name { get; }
        public AppLanguage Lang { get; set; }
    }


    /// <summary>
    /// აპლიკაციის რექუესთი, ტანით
    /// </summary>
    /// <typeparam name="TBody"></typeparam>
    public interface IAppInput<TBody> : IAppInput where TBody : class
    {
        TBody Body { get; set; }
    }

    #endregion

    #region Abstract Classes

    /// <summary>
    /// აპლიკაციის რექუესთი, ტანის გარეშე
    /// </summary>
    public abstract class AppInput : IAppInput
    {
        public string Id { get; set; }
        public string CorrelationId { get; set; }
        public abstract string Name { get; }
        public AppLanguage Lang { get; set; }
    }

    /// <summary>
    /// აპლიკაციის რექუესთი, ტანით
    /// </summary>
    /// <typeparam name="TBody"></typeparam>
    public abstract class AppInput<TBody> : AppInput, IAppInput<TBody> where TBody : class
    {
        public TBody Body { get; set; }
    }

    #endregion
}
