using System;
using System.Diagnostics;

namespace VGTDataStore.Core
{
    public class VGTUser
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public VGTUser(
            Guid userId,
            string login,
            string password,
            string email)
        {
            UserId = userId;
            Login = login;
            Password = password;
            Email = email;
        }

        public VGTUser(VGTUserRestricted user)
        {
            UserId = Guid.NewGuid();
            Login = user.Login;
            Password = user.Password;
            Email = user.Email;
        }
    }
}
