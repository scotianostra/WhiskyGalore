﻿using System;
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
        // GET: /Register

        public ActionResult Register()
        {
            return View(new User());
        }

        

        // POST: /Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.registerUser(user);
            }
            else
            {
                return View(user);
            }

            return View();
        }

    }
}
