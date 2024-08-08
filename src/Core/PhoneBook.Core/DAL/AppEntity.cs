using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.DAL
{
    public interface IAppEntity
    {
        DateTimeOffset? CreatedAt { get; set; }
        DateTimeOffset? UpdatedAt { get; set; }
    }

    public interface IAppEntity<TKey> : IAppEntity
    {
        TKey Id { get; set; }
    }

    public abstract class AppEntity : IAppEntity
    {
        public string CorrelationId { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public abstract class AppEntity<TKey> : AppEntity, IAppEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
