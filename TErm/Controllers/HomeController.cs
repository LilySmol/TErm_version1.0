using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TErm.Models;

namespace TErm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<ProjectModel> list = Parser.getProjectsListByPrivateToken("GG8RjMH3TyguYqP6FBxu", "LilySmol");
            //List<IssuesModel> model = Parser.getIssuesListByPrivateToken("GG8RjMH3TyguYqP6FBxu");
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult IssuesTable()
        {
            //List<IssuesModel> model = Parser.getIssuesListByPrivateToken("GG8RjMH3TyguYqP6FBxu");   
            return View();
        }
    }
}