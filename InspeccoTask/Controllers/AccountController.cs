﻿using Microsoft.AspNetCore.Mvc;

namespace InspeccoTask.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View("Login");
        }
          
    }
}
