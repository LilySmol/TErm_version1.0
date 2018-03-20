using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TErm.Helpers.Clustering
{
    public class IterationClustering
    {        
        private ClusterCenter clusterCenter;
        private List<ClusterObject> clusterObject;
        private ClusterObject estimateTime;

        public ClusterCenter ClusterCenter
        {
            get { return clusterCenter; }
            set { clusterCenter = value; }
        }
        public List<ClusterObject> ClusterObject
        {
            get { return clusterObject; }
            set { clusterObject = value; }
        }
        public ClusterObject EstimateTime
        {
            get { return estimateTime; }
            set { estimateTime = value; }
        }

        public IterationClustering(ClusterCenter clusterCenter, List<ClusterObject> clusterObject, ClusterObject estimateTime)
        {
            this.clusterCenter = clusterCenter;
            this.clusterObject = clusterObject;
            this.estimateTime = estimateTime;
        }
    }
}