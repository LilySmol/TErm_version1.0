using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TErm.Helpers.Clustering
{
    public class ClusterCenter
    {
        private string clusterCenterName;
        private double[] attributeArray;
        private int estimateTime;

        public string ClusterName
        {
            get { return clusterCenterName; }
            set { clusterCenterName = value; }
        }
        public double[] AttributeArray
        {
            get { return attributeArray; }
            set { attributeArray = value; }
        }
        public int EstimateTime
        {
            get { return estimateTime; }
            set { estimateTime = value; }
        }

        public ClusterCenter(string clusterName, double[] attributeArray, int estimateTime)
        {
            this.clusterCenterName = clusterName;
            this.attributeArray = attributeArray;
            this.estimateTime = estimateTime;
        }
    }
}