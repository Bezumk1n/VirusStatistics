using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusStatistics.Domain.Common;

namespace VirusStatistics.Domain.Users
{
    public sealed record Email
    {
        public string Value { get; }
        private Email(string value) 
        {
            Value = value;
        }
        public static Result<Email> Create(string? email)
        {
            if (string.IsNullOrEmpty(email))
                return Result.Failure<Email>(EmailErrors.Empty);
            if(email.Split('@').Length != 2)
                return Result.Failure<Email>(EmailErrors.InvalidFormat);
            return Result.Success<Email>(new Email(email));   
        }
    }
}
