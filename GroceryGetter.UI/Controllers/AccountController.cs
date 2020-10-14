﻿using GroceryGetter.BL;
using GroceryGetter.BL.Models;
using GroceryGetter.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryGetter.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index(User user)
        {
            if (Authenticate.IsAuthenticated())
            {
                //List<User> users = UserManager.Load();
                //return View(users);

                Session["user"] = user;
                var userInfoList = UserManager.LoadById(user.Id);
                return View(userInfoList);

            }
            else
            {
                //Need to authenticate
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        public ActionResult Settings()
        {
            User user = new User();
            ViewBag.Title = "Account Settings";
            return View(user);
        }

        // POST: User/Settings
        [HttpPost]
        public ActionResult Settings(User user)
        {
            try
            {
                UserManager.Insert(user);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}