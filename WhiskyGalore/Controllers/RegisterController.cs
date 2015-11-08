using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhiskyGalore.Models;

namespace WhiskyGalore.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/

        public ActionResult Register()
        {
            return View(new User());
        }

        

        // POST: /Register/NewUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewUser(User user)
        {
            
            user.registerUser(user);

            return View();
        }

    }
}
