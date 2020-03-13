using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            if (Session["Msg_reg_succ"] != null)
            {
                ViewBag.Msg = Session["Msg_reg_succ"].ToString();
                Session.Remove("Msg_reg_succ");
            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //
        [HttpPost]
        public ActionResult Login(UserAccount formCollection)
        {
            if (ModelState.IsValid)
            {
                ListAccount Accounts = new ListAccount();
                string username = Accounts.checkUserLogin(formCollection.Username, formCollection.Password);
                if (username != null)
                {
                    Session["USER_NAME"] = username;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Invalid username or password";
                }
            }

            
            return View();
        }

        //
        //[HttpPost]
        //public ActionResult Login(string username, string password)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ListAccount Accounts = new ListAccount();
        //        string username1 = Accounts.checkUserLogin(username, password);

        //        if (username1 != null)
        //        {
        //            Session["USER_NAME"] = username1;
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }

        //    return View();
        //}

        // POST: Account/Create
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            bool isInsert = false;
            try
            {
                // TODO: Add insert logic here
                ListAccount listAccount = new ListAccount();

                isInsert = listAccount.RegisterNewAccount(account);
                
                if (isInsert)
                {
                    Session["Msg_reg_succ"]= "Register Success";
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Message = "This Username has been exist! Please choose another one";
                }
                
            }
            catch
            {
                ViewBag.Message = "This Username has been exist! Please choose another one";
            }
             return View();
        }


    }
}
