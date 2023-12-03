using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusStatistics.Domain.Common;

namespace VirusStatistics.Domain.Users
{
    public static class EmailErrors
    {
        public static readonly Error Empty = new Error("Email.Empty", "Email is empty");
        public static readonly Error InvalidFormat = new Error("Email.InvalidFormat", "Email format is invalid");
    }
}
