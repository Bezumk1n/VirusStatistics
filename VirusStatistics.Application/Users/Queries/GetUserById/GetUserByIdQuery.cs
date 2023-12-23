using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusStatistics.Application.Abstractions.Messaging;

namespace VirusStatistics.Application.Users.Queries.GetUserById
{
    public sealed class GetUserByIdQuery: IQuery<UserResponse>
    {
        public Guid UserId { get; }
        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }

    }
}
