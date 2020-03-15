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
    public class MultilController : Controller
    {
        // GET: Multil
        public ActionResult Index()
        {
            
            return View();
        }
        public PartialViewResult RenderTeacher()
        {
            return PartialView();
        }
    }
}