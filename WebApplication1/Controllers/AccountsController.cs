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
            try
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
            }
            catch (Exception e)
            {
                CommonUse.WriteLogError(e);
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
            try
            {
                if (ModelState.IsValid)
                {
                    ListAccount Accounts = new ListAccount();
                    string fullname = Accounts.checkLogin(account.Username, account.Password, account.Role);
                    if (fullname != null)
                    {
                        account.FullName = fullname;

                        Session["FULL_NAME"] = account.FullName.ToUpper();
                        Session["USER_NAME"] = account.Username;
                        Session["ROLE"] = account.Role;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Invalid username or password";
                    }
                }
            }
            catch (Exception e)
            {
                CommonUse.WriteLogError(e);
            }

            return View();
        }


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
            catch (Exception e)
            {
                ViewBag.Message = "This Username has been exist! Please choose another one";
                CommonUse.WriteLogError(e);
            }
            return View();
        }


        public ActionResult Profile()
        {
            String username = Session["USER_NAME"].ToString();



            if (username == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                String fullname = Session["FULL_NAME"].ToString();
                ViewBag.Author = fullname;
                ArticleList articleList = new ArticleList();

                List<Article> listArticle = articleList.getListArticleOfUser(username);

                return View(listArticle);

            }
        }


        public ActionResult Index()
        {
            List<Account> list = new List<Account>();
            try
            {
                ListAccount accountList = new ListAccount();
                list = accountList.getListAccount();
    

            }
            catch (Exception e)
            {
                CommonUse.WriteLogError(e);
            }


            return View(list);
        }
        public ActionResult Block(string username)
        {

            ListAccount account = new ListAccount();
            account.BlockAccount(username);
            return RedirectToAction("Index", "Accounts");

        }
    }

}
