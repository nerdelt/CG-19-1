using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSignup.Models;
using Microsoft.AspNetCore.Mvc;

namespace UserSignup.Models
{
    public class UserData
    {
        public static List<User> Users = new List<User>();

        public static List<User> GetAll()
        {
            return Users;
        }

        public static void Add(User newUser)
        {
            Users.Add(newUser);
        }

        public static User GetById(int id)
        {
            return Users.Single(x => x.UserId == id);
        }

      }
}

