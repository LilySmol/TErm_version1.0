using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TErm.Models;
using System.Resources;
using System.Reflection;

namespace TErm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GitLabParser gitP = new GitLabParser();
            ResourceManager rm = new ResourceManager("TErm.Resource", Assembly.GetExecutingAssembly());
            string url = rm.GetString("baseUrl");
            gitP.baseUrl = url;
            List<ProjectModel> list = gitP.getProjectsListByPrivateToken("GG8RjMH3TyguYqP6FBxu", "LilySmol");            
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
            return View();
        }
    }
}