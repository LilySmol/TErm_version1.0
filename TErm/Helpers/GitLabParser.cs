﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using TErm.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Json;
using TErm.Helpers;

namespace TErm.Controllers
{
    public class GitLabParser: Requests, IParsing
    {
        /// <summary>
        /// Возвращает список проектов по privateToken и имени пользователя.
        /// </summary>
        public List<ProjectModel> getProjectsListByPrivateToken(string privateToken, string userName)
        {
            string response = get(privateToken, "https://gitlab.com/api/v4/users/" + userName + "/projects");
            List<ProjectModel> projectList = JsonConvert.DeserializeObject<List<ProjectModel>>(response);
            foreach (ProjectModel project in projectList)
            {
                project.issuesList = getIssuesListByPrivateToken(privateToken, project._links.issues);
            }
            return projectList;
        }

        /// <summary>
        /// Возвращает список задач по privateToken и ссылке на задачи проекта.
        /// </summary>
        public List<IssuesModel> getIssuesListByPrivateToken(string privateToken, string linkIssues)
        {
            string response = get(privateToken, linkIssues);
            List<IssuesModel> issuesList = JsonConvert.DeserializeObject<List<IssuesModel>>(response);
            //dynamic obj = JsonConvert.DeserializeObject(issuesContent);
            //var project_id = (string)obj.First.project_id;
            return issuesList;
        }
    }
}