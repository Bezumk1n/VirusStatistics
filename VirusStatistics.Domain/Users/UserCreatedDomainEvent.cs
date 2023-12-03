using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusStatistics.Domain.Common;

namespace VirusStatistics.Domain.Users
{
    public sealed class UserCreatedDomainEvent : IDomainEvent
    {
        public Guid Id { get; init; }
        public UserCreatedDomainEvent(Guid id)
        {
            Id = id;
        }
    }
}
