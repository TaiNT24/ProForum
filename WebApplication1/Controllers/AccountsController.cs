using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            if (Session["Msg_reg_succ"] != null)
            {
                ViewBag.Msg = Session["Msg_reg_succ"].ToString();
                Session.Remove("Msg_reg_succ");
            }
            if (Session["Redirect_to_PostArticle"] != null)
            {
                ViewBag.Message = Session["Redirect_to_PostArticle"].ToString();
                Session.Remove("Redirect_to_PostArticle");
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
        public ActionResult Login(Account account)
        {
            if (ModelState.IsValid)
            {
                ListAccount Accounts = new ListAccount();
                string fullname = Accounts.checkLogin(account.Username, account.Password,account.Role);
                if (fullname != null)
                {
                    account.FullName = fullname;

                    Session["FULL_NAME"] = account.FullName;
                    Session["USER_NAME"] = account.Username;

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
        //        string username1 = Accounts.checkLogin(username, password);

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
        public ActionResult Register(Account account)
        {
            bool isInsert = false;
            try
            {
                // TODO: Add insert logic here
                ListAccount listAccount = new ListAccount();

                isInsert = listAccount.RegisterNewAccount(account);

                if (isInsert)
                {
                    Session["Msg_reg_succ"] = "Register Success";
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
