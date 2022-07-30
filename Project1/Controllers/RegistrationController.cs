  using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.DAL;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    public class RegistrationController : Controller
    {

        RegistrationDAL db = new RegistrationDAL();
       
        // GET: RegistrationController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registration reg )
        {

            try
            {
                int result = db.Registration(reg);
                if (result == 1)
                    return RedirectToAction(nameof(LogIn));
                else
                    return View();
            }
            
            catch
            {
                return View();
            }
        }

        public IActionResult LogIn()
        {
            return View();
        }

        // POST: LogIn/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(Registration reg)
        {
            Registration user = db.LogIn(reg);

            if(user.Password== reg.Password)
            {
                HttpContext.Session.SetString("Name", user.EmailId.ToString());
                HttpContext.Session.SetString("Uid", user.Uid.ToString());
                if (user.RoleId ==Roles.Customer)
                    return RedirectToAction("Products", "Product");
                else if (user.RoleId ==Roles.Admin)
                    return RedirectToAction("Index", "Product");
                else
                    return View();

            }
            else
            {
                return View();
            }
            
           
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }


    }
}
