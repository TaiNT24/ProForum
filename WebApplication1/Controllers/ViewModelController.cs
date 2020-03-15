using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ViewModelController : Controller
    {
        // GET: ViewCode
        public ActionResult Result() 
        {
            CommentList cmtList = new CommentList();
            var comments = cmtList.getListComment(6);
            ArticleList art = new ArticleList();
            var details = art.getDetailArticle(null);
            var model = new ViewModelResult { articleDetail = details, listComment = comments };
            return View(model);
        }

        // GET: ViewCode/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ViewCode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViewCode/Create
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

        // GET: ViewCode/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ViewCode/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ViewCode/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ViewCode/Delete/5
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
