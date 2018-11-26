using System;
using System.ComponentModel.DataAnnotations;
using UserSignup.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserSignup.ViewModels
{
    public class AddUserViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Must be at least 5 letters")]
        [MaxLength(15, ErrorMessage = "Must be 15 letters or less")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please use letters only")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Email format is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter a password")]
        [MinLength(6, ErrorMessage = "Must have at least 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Verify Password")]
        [Required(ErrorMessage = "You must enter a password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Verify { get; set; }

        public int UserId { get; set; }

        public DateTime JoinTime { get; set; }


        public User CreateUser(string username, string email, string password, string verify, DateTime joinTime)
        {
            User newUser = new User
            {
                UserName = username,
                Email = email,
                Password = password,
                JoinTime = joinTime
            };

            Verify = verify;

            return newUser;
        }
    }
}
