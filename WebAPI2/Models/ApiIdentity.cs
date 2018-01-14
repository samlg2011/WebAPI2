using System;
using System.Security.Principal;

namespace WebAPI2.Models
{
    /// <summary>
    /// Override http context user identity, using user model instead.
    /// We may put more useful user properties in context header for further usage.
    /// </summary>
    public class ApiIdentity : IIdentity
    {
        public ApiUser User { get; private set; }
        public ApiIdentity(ApiUser user)
        {
            if (user == null) throw new ArgumentException("ApiUser");
            this.User = user;
        }
        public string Name { get { return User.LogonName; } }
        public string Company { get { return User.Company; } }
        public string AuthenticationType { get { return User.AuthenticationType.ToString(); } }
        public bool IsAuthenticated { get { return true; } }
    }
}