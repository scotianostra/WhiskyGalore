﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhiskyGalore.Models;


namespace WhiskyGalore.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login
        public ActionResult Login()
        {
            return View(new User());
        }


        //
        // POST: /Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {

                if (user.loginUser(user))
                {
                    return RedirectToAction("Index", "Home");
                }

                else
                {

                    ModelState.AddModelError("", "The user name or password provided is incorrect." );
                    return View(user);
                }
            }else
            {
                
                return View(user);
            }

           
        }

    }
}

