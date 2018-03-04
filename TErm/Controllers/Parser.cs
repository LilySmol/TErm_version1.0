using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using TErm.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Json;

namespace TErm.Controllers
{
    public class Parser
    {
        /// <summary>
        /// Возвращает список задач по privateToken и ссылке на задачи проекта.
        /// </summary>
        public static List<IssuesModel> getIssuesListByPrivateToken(string privateToken, string linkIssues)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(linkIssues);            
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";
            request.Headers["Private-Token"] = privateToken;
            //request.PreAuthenticate = true;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string issuesContent = string.Empty;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
                {
                    issuesContent = sr.ReadToEnd();
                }
            }
            List<IssuesModel> issuesList = JsonConvert.DeserializeObject<List<IssuesModel>>(issuesContent);
            //dynamic obj = JsonConvert.DeserializeObject(issuesContent);
            //var project_id = (string)obj.First.project_id;
            return issuesList;
        }

        /// <summary>
        /// Возвращает список проектов по privateToken и имени пользователя.
        /// </summary>
        public static List<ProjectModel> getProjectsListByPrivateToken(string privateToken, string userName)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://gitlab.com/api/v4/users/" + userName + "/projects");
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";
            request.Headers["Private-Token"] = privateToken;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string projectContent = string.Empty;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
                {
                    projectContent = sr.ReadToEnd();
                }
            }
            List<ProjectModel> projectList = JsonConvert.DeserializeObject<List<ProjectModel>>(projectContent);

            foreach (ProjectModel project in projectList)
            {
                project.issuesList = getIssuesListByPrivateToken(privateToken, project._links.issues);
            }

            return projectList;
        }
    }
}