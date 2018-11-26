using System;
using System.ComponentModel.DataAnnotations;

namespace UserSignup.Models
{
    public class User
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int UserId { get; set; }

        private static int nextId = 1;

        public DateTime JoinTime { get; set; }

        public User (string username, string email, string password)
        {
            UserName = username;
            Email = email;
            Password = password;
        }

        public User()
        {
            UserId = nextId;
            nextId++;
        }

    }
}
