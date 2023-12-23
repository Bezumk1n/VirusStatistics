using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusStatistics.Application.Abstractions.Messaging;

namespace VirusStatistics.Application.Users.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery : IQuery<UserResponse>
    {
        public string Email { get; }
        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
