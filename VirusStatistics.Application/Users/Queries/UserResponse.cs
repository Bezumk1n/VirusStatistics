using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusStatistics.Domain.Users;

namespace VirusStatistics.Application.Users.Queries
{
    public sealed class UserResponse
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public static UserResponse Create(User user)
        {
            var result = new UserResponse();
            result.Id = user.Id;
            result.Email = user.Email.Value;
            result.Name = user.Username;
            return result;
        }
    }
}
