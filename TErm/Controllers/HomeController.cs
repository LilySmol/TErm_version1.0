using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TErm.Models;
using System.Resources;
using System.Reflection;
using TErm.Helpers.Integration;
using TErm.Helpers.Clustering;

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
            List<ProjectModel> projectList = gitP.getProjectsListByPrivateToken("GG8RjMH3TyguYqP6FBxu", "LilySmol");
            InputDataConverter inputDataConverter = new InputDataConverter();
            Clustering clustering = new Clustering(inputDataConverter.convertToClusterObject(projectList[0].issuesList), 9);
            clustering.initializationClusterCenters();
            clustering.clustering();  
            return View();
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