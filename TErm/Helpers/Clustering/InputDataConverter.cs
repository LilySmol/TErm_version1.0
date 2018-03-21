using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TErm.Models;

namespace TErm.Helpers.Clustering
{
    public class InputDataConverter
    {
        private static List<string> DICTIONARY = new List<string>() {"авторизация", "логину", "паролю", "токену",
                        "добавление", "бд", "пользователя", "строк", "номеру", "покупок"};
        private static int COUNTWORDS = DICTIONARY.Count;

        public List<ClusterObject> convertToClusterObject(List<IssuesModel> issuesModel)
        {
            List<ClusterObject> clusterObject = new List<ClusterObject>();
            foreach (IssuesModel issue in issuesModel)
            {
                double[] issueArray = new double[COUNTWORDS];
                string[] issueWordsArray = String.Concat(issue.title.ToLower(), " ", issue.description.ToLower()).Split(' ');                
                for (int i = 0; i < COUNTWORDS; i++)
                {
                    if (issueWordsArray.Contains(DICTIONARY[i]))
                    {
                        issueArray[i] = 1;
                    }
                    else
                    {
                        issueArray[i] = 0;
                    }
                }
                clusterObject.Add(new ClusterObject("d" + issue.iid, issueArray, issue.time_stats.total_time_spent));
            }
            return clusterObject;
        }
    }
}