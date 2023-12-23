using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusStatistics.Application.Abstractions.Messaging;

namespace VirusStatistics.Application.Users.Commands
{
    public sealed class CreateUserCommand: ICommand<Guid>
    {
        public string Email { get; } 
        public string Name { get; }
        public string Password { get; }
        public CreateUserCommand(string email, string name, string password)
        {
            Email = email;
            Name = name;
            Password = password;
        }

    }
}
