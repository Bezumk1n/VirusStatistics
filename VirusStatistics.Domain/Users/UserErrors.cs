using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusStatistics.Domain.Common;

namespace VirusStatistics.Domain.Users
{
    public static class UserErrors
    {
        public static readonly Error EmailNotUniq = new Error("User.EmailNotUniq", $"The provided Email is not unique");
        public static Error NotFound(Guid userId) => new Error("User.NotFound", $"The user with Id = '{userId}' was not found");
        public static Error NotFoundByEmail(string email) => new Error("User.NotFoundByEmail", $"The user with the Email = '{email}' was not found");
    }
}
