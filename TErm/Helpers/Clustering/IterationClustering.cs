using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TErm.Helpers.Clustering
{
    public class IterationClustering
    {
        private int numberIteration;
        private ClusterCenter clusterCenter;
        private ClusterObject clusterObject;

        public int NumberIteration { get; set; }
        public ClusterCenter ClusterCenter { get; set; }
        public ClusterObject ClusterObject { get; set; }

        public IterationClustering(int numberIteration, ClusterCenter clusterCenter, ClusterObject clusterObject)
        {
            this.numberIteration = numberIteration;
            this.clusterCenter = clusterCenter;
            this.clusterObject = clusterObject;
        }
    }
}