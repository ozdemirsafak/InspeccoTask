using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using InspeccoTask.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Utilities.Response;

namespace InspeccoTask.Controllers
{  
    public class UserController : Controller
    {
        private readonly IUserService _um;

        public UserController(IUserService um)
        {
            _um = um;
        }

        public IActionResult List()
        {
            Result<User> result = _um.Get(Convert.ToInt32(HttpContext.Request.Cookies["UserId"]));
            var values = _um.GetAllActiveUserAndRoles();
            return View(values);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Update(int Id)
        {
            UpdateUserViewModel model = new UpdateUserViewModel();
            Result<User> result = _um.Get(Id);
            if (result.IsSuccess)
                model.User = result.Data;

            return View(model);
        }
    }
}
