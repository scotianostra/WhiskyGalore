using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhiskyGalore.Models;

namespace WhiskyGalore.Controllers
{
    public class DetailsController : Controller
    {

        // GET: /Details/Complete
        public ActionResult Register()
        {
            return View(new User());
        }
        
        // POST: /Details/Complete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Complete(User user)
        {
            if (ModelState.IsValid)
            {
                user.completeUser(user);
            }
            else
            {

                return View(user);
            }
            return RedirectToAction("Complete");
        }
    }
}