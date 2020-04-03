using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index(string searchVal)
        {
            List<Article> list = new List<Article>();
            try
            {
                ArticleList articleList = new ArticleList();
                list = articleList.getListManagerArticle();

                if (searchVal != null)
                {
                    list.Clear();
                    list = articleList.searchManagerArticle(searchVal);
                }

            }
            catch (Exception e)
            {
                CommonUse.WriteLogError(e);
            }

            return View(list);
        }

        public ActionResult Deleted(int id)
        {

            ArticleList articleList = new ArticleList();
            articleList.Delete(id);
            return RedirectToAction("Index", "Admin");

        }
        public ActionResult Approved(int id)
        {

            ArticleList articleList = new ArticleList();
            articleList.Approve(id);

            return RedirectToAction("Index", "Admin");

        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        
        // POST: Admin/Delete/5
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
