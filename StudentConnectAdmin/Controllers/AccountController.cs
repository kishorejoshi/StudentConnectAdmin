﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using StudentConnectAdmin.Utils;
using StudentConnectAdmin.Azure;

namespace StudentConnectAdmin.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Logout");
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var password = collection["password"];
            var returnUrl = collection["returnUrl"];
            var username = collection["username"];
            var helper = ServiceProvider.Resolve<StorageHelper>();

            //string username = helper.StandardUsername;

            //if (helper.AdminPassword.Equals(password)) username = helper.AdminUsername;

            var validated = Membership.ValidateUser(username, password);
            if (validated)
            {

                // implement 'Remember Me' feature
                var remember = true;
                //if (collection["rememberme"] != null) remember = true;
                FormsAuthentication.SetAuthCookie(username, remember);

               // var schooldata = helper.Schools.FirstOrDefault(q => q.Passcode == passcode);
                //if (schooldata != null) Session["_ActiveSchool"] = schooldata;

                //TODO: Reimplement this!
                // redirect to the returnUrl if it exists
                //if (!string.IsNullOrWhiteSpace(returnUrl))
                //{
                //    return Redirect(returnUrl);
                //}
                // otherwise go to Home.

                return RedirectToAction("Index", "Home");
            }
            ViewBag.AuthError = "Invalid username or password";
            return View();
        }

        public ActionResult Passthru(string id)
        {
            //var helper = ServiceProvider.Resolve<StorageHelper>();

            //string username = helper.StandardUsername;

            //if (helper.AdminPassword.Equals(id)) username = helper.AdminUsername;

            //var validated = Membership.ValidateUser(username, id);
            //if (validated)
            //{

            //    // implement 'Remember Me' feature
            //    var remember = true;
            //    FormsAuthentication.SetAuthCookie(username, remember);

            //    var schooldata = helper.Schools.FirstOrDefault(q => q.Passcode == id);
            //    if (schooldata != null) Session["_ActiveSchool"] = schooldata;

            //    //TODO: Reimplement this!
            //    // redirect to the returnUrl if it exists
            //    //if (!string.IsNullOrWhiteSpace(returnUrl))
            //    //{
            //    //    return Redirect(returnUrl);
            //    //}
            //    // otherwise go to Home.

            //    return RedirectToAction("Index", "Home");
            //}
            //ViewBag.AuthError = "Invalid Passcode";
            return View("Login");
        }

    }
}
