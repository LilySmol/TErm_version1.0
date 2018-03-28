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
            List<string> str = new List<string>();
            str.Add("c");
            str.Add("g");
            str.Add("c");
            int count = str.Count(w => w == "c");
            str.RemoveAll(l => l == "c");
            GitLabParser gitP = new GitLabParser();
            ResourceManager rm = new ResourceManager("TErm.Resource", Assembly.GetExecutingAssembly());
            string url = rm.GetString("baseUrl");
            gitP.baseUrl = url;
            List<ProjectModel> projectList = gitP.getProjectsListByPrivateToken("GG8RjMH3TyguYqP6FBxu", "LilySmol");
            //List<ClusterObject> objectsList = new List<ClusterObject>();
            //objectsList.Add(new ClusterObject("d1", new double[] { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 }));
            //objectsList.Add(new ClusterObject("d2", new double[] { 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 }));
            //objectsList.Add(new ClusterObject("d3", new double[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
            //objectsList.Add(new ClusterObject("d4", new double[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0 }));
            //objectsList.Add(new ClusterObject("d5", new double[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1 }));
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