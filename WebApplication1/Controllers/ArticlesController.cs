﻿using System;
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
    public class ArticlesController : Controller
    {
        private ArticleDBContext db = new ArticleDBContext();

        // GET: Articles
        //View all article/search
        public ActionResult Index(string searchVal)
        {
            List<Article> list = new List<Article>() ;
            try
            {
                ArticleList articleList = new ArticleList();
                list = articleList.getListActiveArticle();

                if (searchVal != null)
                {
                    list.Clear();
                    if(Session["ROLE"] != null)
                    {
                        if (Session["ROLE"].ToString().Equals("Admin"))
                        {
                            return RedirectToAction("Index", "Admin", new {searchVal});
                        }
                        else
                        {
                            list = articleList.searchActiveArticle(searchVal);
                        }
                    }
                    else
                    {
                        list = articleList.searchActiveArticle(searchVal);
                    }
                }

            }catch(Exception e)
            {
                CommonUse.WriteLogError(e);
            }
            

            return View(list);
        }


        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            ViewModelResult model = new ViewModelResult();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                CommentList cmtList = new CommentList();
                var comments = cmtList.getListComment(id);
                ArticleList art = new ArticleList();
                var details = art.getDetailArticle(id);
                model = new ViewModelResult { articleDetail = details, listComment = comments };
            }

            catch(Exception e)
            {
                CommonUse.WriteLogError(e);
            }
            

            return View(model);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            try
            {
                object username = Session["USER_NAME"];
                if (username == null)
                {
                    Session["Redirect_to_PostArticle"] = "You need Login to Post article";

                    return RedirectToAction("Login", "Accounts");
                }
            }
            catch(Exception e)
            {
                CommonUse.WriteLogError(e);
            }
            
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    article.ArtPostTime = DateTime.Now;
                    article.ArtStatus = "New";


                    ListAccount accountManager = new ListAccount();
                    bool isAdmin = accountManager.getRole(article.ArtUsername);
                    if (isAdmin)
                    {
                        article.ArtStatus = "Active";

                        db.Articles.Add(article);
                        db.SaveChanges();
                        return RedirectToAction("Index","Admin");
                    }
                    
                    db.Articles.Add(article);
                    db.SaveChanges();
                    return RedirectToAction("Profile", "Accounts");
                }
                catch(Exception e)
                {
                    CommonUse.WriteLogError(e);
                }
            }

            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            Article article = null;
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                article = db.Articles.Find(id);
                if (article == null)
                {
                    return HttpNotFound();
                }
            }
            catch(Exception e)
            {
                CommonUse.WriteLogError(e);
            }
            
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtID,ArtTittle,ArtContent,ArtPostTime,ArtAuthor,ArtStatus,ViewCount,LikeCount")] Article article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(article).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception e)
                {
                    CommonUse.WriteLogError(e);
                }
                
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Article article = db.Articles.Find(id);
                db.Articles.Remove(article);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                CommonUse.WriteLogError(e);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}
