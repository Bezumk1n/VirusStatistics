using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusStatistics.Domain.Common
{
    public abstract class Entity
    {
        #region Properties
        public Guid Id { get; init; }
        public readonly List<IDomainEvent> DomainEvents = new List<IDomainEvent>();
        #endregion
        #region Constructor
        public Entity(Guid id)
        {
            Id = id;
        }
        #endregion
        #region Methods
        protected void Raise(IDomainEvent domainEvent)
        {
            DomainEvents.Add(domainEvent);
        }
        #endregion
    }
}
