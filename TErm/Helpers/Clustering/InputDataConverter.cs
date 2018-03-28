using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TErm.Models;

namespace TErm.Helpers.Clustering
{
    public class InputDataConverter
    {
        private static List<string> DICTIONARY = new List<string>();
        private static int COUNTWORDS = 0;

        /// <summary>
        /// Преобразует объекты списка IssuesModel в список ClusterObject
        /// </summary>
        public List<ClusterObject> convertToClusterObject(List<IssuesModel> issuesModel)
        {
            DICTIONARY = dictionaryInitialize(issuesModel);
            COUNTWORDS = DICTIONARY.Count();
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
                clusterObject.Add(new ClusterObject(issue.iid.ToString(), issueArray, issue.title, issue.time_stats.total_time_spent, issue.time_stats.time_estimate));
            }
            return clusterObject;
        }

        /// <summary>
        /// Возвращает список словаря
        /// </summary>
        private List<string> dictionaryInitialize(List<IssuesModel> issuesModel)
        {
            List<string> totalWordsList = new List<string>();
            List<string> dictionary = new List<string>();
            foreach (IssuesModel issue in issuesModel)
            {
                List<string> issueWordsList = String.Concat(issue.title.ToLower(), " ", issue.description.ToLower()).Split(' ').ToList();
                issueWordsList.RemoveAll(l => l.Length < 4 && l != "бд");
                totalWordsList.AddRange(issueWordsList);
            }
            foreach (string word in totalWordsList)
            {
                if (totalWordsList.Count(l => l == word) > 1)
                {
                    dictionary.Add(word);
                }
            }
            return dictionary.Distinct().ToList();
        }
    }
}