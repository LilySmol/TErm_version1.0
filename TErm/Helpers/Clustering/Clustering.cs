using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TErm.Helpers.Clustering
{
    public class Clustering
    {
        private List<ClusterCenter> centersList;
        private List<ClusterObject> objectsList;
        private List<IterationClustering> oneIterationList;
        private int countClusters; 

        /// <summary>
        /// Осуществляется инициализация списка объектов кластеризации и количества кластеров.
        /// </summary>
        public Clustering(List<ClusterObject> objectsList, int countClusters)
        {
            this.objectsList = objectsList;
            this.countClusters = countClusters;
        }

        /// <summary>
        /// Осуществляется начальная инициализация списка центров кластеров.
        /// </summary>
        public void initializationClusterCenters()
        {
            for (int i = 0; i < countClusters; i++)
            {
                centersList.Add(new ClusterCenter("center" + (i + 1), objectsList[i].AttributeArray, 0));
            }
        }

        /// <summary>
        /// Расчитывает евклидово расстояние между объектом и центром.
        /// </summary>
        public double getDistance(ClusterObject clusterObject, ClusterCenter clusterCenter)
        {
            double distance = 0;
            for (int i = 0; i < clusterObject.AttributeArray.Count(); i++)
            {
                distance += Math.Pow(clusterObject.AttributeArray[i] - clusterCenter.AttributeArray[i], 2);
            }
            return Math.Sqrt(distance);
        }

        /// <summary>
        /// Перерасчет вектора признаков центра. Возвращает новый центр.
        /// </summary>
        public ClusterCenter recalculationCenter(ClusterObject clusterObject, ClusterCenter clusterCenter)
        {
            double[] newAttributeArray = new double[clusterCenter.AttributeArray.Count()];
            for (int i = 0; i < clusterCenter.AttributeArray.Count(); i++)
            {
                newAttributeArray[i] = (clusterObject.AttributeArray[i] + clusterCenter.AttributeArray[i]) / 2;
            }
            for (int j = 0; j < clusterCenter.AttributeArray.Count(); j++)
            {
                clusterCenter.AttributeArray[j] = newAttributeArray[j];
            }
            return clusterCenter;
        }

        /// <summary>
        /// Возвращает номер ближайшего к объекту центра
        /// </summary>
        public int getNumberNearestCenter(ClusterObject clusterObject)
        {
            double distance = getDistance(clusterObject, centersList[0]);
            double newDistance = 0;
            int numberCenter = 0;
            for (int i = 0; i < centersList.Count; i++)
            {
                newDistance = getDistance(clusterObject, centersList[i]);
                if (newDistance < distance)
                {
                    distance = newDistance;
                    numberCenter = i;
                }
            }
            return numberCenter;
        }

        /// <summary>
        /// Уточнение центров
        /// </summary>
        public void clarifyCenters()
        {
            foreach (ClusterObject clusterObject in objectsList)
            {
                int numberCenter = getNumberNearestCenter(clusterObject);
                centersList[numberCenter] = recalculationCenter(clusterObject, centersList[numberCenter]);
            }
        }

        /// <summary>
        /// Кластеризация
        /// </summary>
        public void clustering()
        {
            int numberIteration = 0;
            List<string> changeList = new List<string>();
            string stringChange = "";
            bool flag = true;
            while (flag)
            {
                clarifyCenters();
                foreach (ClusterObject clusterObject in objectsList)
                {
                    oneIterationList.Add(new IterationClustering(numberIteration, centersList[getNumberNearestCenter(clusterObject)], clusterObject));
                    stringChange += centersList[getNumberNearestCenter(clusterObject)].ClusterName;
                }
                changeList.Add(stringChange);
                if (numberIteration > 0)
                {
                    if (changeList[numberIteration] == changeList[numberIteration - 1])
                    {
                        flag = false;
                    }
                }
                numberIteration++;
            }
        }
    }
}