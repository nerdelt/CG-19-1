using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSignup.Models;
using Microsoft.AspNetCore.Mvc;
using UserSignup.ViewModels;

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {
            List<User> users = UserData.GetAll();
            return View(users);
        }

        //[HttpPost]
        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        [Route("User/Add")]
        public IActionResult Add(AddUserViewModel addUserViewModel, string verify)
        {
            addUserViewModel.Verify = verify;

            if (addUserViewModel.Password != addUserViewModel.Verify)
            {
                return View(addUserViewModel);
            }

            if (ModelState.IsValid)
            {
                addUserViewModel.JoinTime = DateTime.Now;

                UserData.Add(addUserViewModel.CreateUser(
                    addUserViewModel.UserName,
                    addUserViewModel.Email,
                    addUserViewModel.Password,
                    addUserViewModel.Verify,
                    addUserViewModel.JoinTime
                ));

                return Redirect("/User/Index");
            }

                return View();          
        }


        public IActionResult Details(int userId)
        {
            User user = UserData.GetById(userId);
            return View(user);
        }
    }

}