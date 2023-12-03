using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusStatistics.Domain.Common;

namespace VirusStatistics.Domain.Users
{
    public sealed class User : Entity
    {
        #region Properties
        public string Username { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; }
        #endregion
        #region Constructor
        private User(Guid id, string userName, Email email, string password) : base(id)
        {
            Username = userName;
            Email = email;
            Password = password;
        }
        #endregion
        #region Methods
        public static User Create(string userName, Email email, string password)
        { 
            User user = new User(Guid.NewGuid(), userName, email, password);
            user.Raise(new UserCreatedDomainEvent(user.Id));
            return user;
        }
        #endregion
    }
}
