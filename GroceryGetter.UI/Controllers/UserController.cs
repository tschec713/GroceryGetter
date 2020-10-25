﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroceryGetter.BL;
using GroceryGetter.BL.Models;
using GroceryGetter.UI.Models;
using GroceryGetter.UI.ViewModels;
using WebMatrix.WebData;


namespace GroceryGetter.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Authenticate.IsAuthenticated())
            {
                List<User> users = UserManager.Load();
                ViewBag.Message = ViewBag.Message;
                return View(users);
            }
            else
            {
                //Need to authenticate
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }

        }

        // GET
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET User/Login
        public ActionResult Login(string returnurl)
        {
            User user = new User();
            ViewBag.ReturnUrl = returnurl;
            return View(user);
        }

        //POST User/Login
        [HttpPost]
        public ActionResult Login(User user, string returnurl)
        {
            try
            {
                if (UserManager.Login(user))
                {
                    // Login worked. Save User to session
                    Session["user"] = user;
                    if (user.GroceryList.Length == 1)
                    {
                        user.GroceryListObj = ProductHelper.GetSomeDummyData();  // to add default data (temp fix)
                    }
                    else
                    {
                        user.GroceryListObj = ProductHelper.JsonToOjects(user.GroceryList);
                    }

                    if (!String.IsNullOrEmpty(returnurl))
                        return Redirect(returnurl);
                    else

                        //return RedirectToAction("Index", "User");
                        return RedirectToAction("Index", "UserProduct"); 
                    //return RedirectToAction("Index", "Account");
                }
                ViewBag.Message = "Login could not be completed.";
                return View(user);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return View();
        }

        public ActionResult ForgotPassword()
        {
            
            ViewBag.Title = "Forgot Password";
            return View();
            
        }

        [HttpPost]
        public ActionResult ForgotPassword(string Email)
        {
            try
            {
                WebSecurity.InitializeDatabaseConnection(, );

                if (ModelState.IsValid)
                {

                    if (WebSecurity.UserExists(Email))
                    {
                        string To = Email, UserID, Password, SMTPPort, Host;
                        string token = WebSecurity.GeneratePasswordResetToken(Email);
                        if (token == null)
                        {
                            // If user does not exist or is not confirmed.  

                            return View("Index");

                        }
                        else
                        {
                            //Create URL with above token  

                            var lnkHref = "<a href='" + Url.Action("ResetPassword", "Account", new { email = Email, code = token }, "http") + "'>Reset Password</a>";


                            //HTML Template for Send email  

                            string subject = "Your changed password";

                            string body = "<b>Please find the Password Reset Link. </b><br/>" + lnkHref;


                            //Get and set the AppSettings using configuration manager.  

                            EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);


                            //Call send email methods.  

                            EmailManager.SendEmail(UserID, subject, body, To, UserID, Password, SMTPPort, Host);

                        }

                    }

                }
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public ActionResult EmailSent()
        {
            ViewBag.Title = "Email Sent";
            return View();
        }
        

        // GET: User/Create
        public ActionResult Create()
        {
            User user = new User();
            ViewBag.Title = "Create User";
            return View(user);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                UserManager.Insert(user);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET
        public ActionResult Edit(Guid id)
        {
            // Might work
            User user = UserManager.LoadById(id); 
            return View(user);
        }

        // POST
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here


                //UserManager.Update(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
