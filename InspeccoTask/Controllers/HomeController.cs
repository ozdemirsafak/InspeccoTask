using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InspeccoTask.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Homepage()
        {
            return View();
        }  

       
    }
}