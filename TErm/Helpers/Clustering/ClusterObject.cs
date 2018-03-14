using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TErm.Helpers.Clustering
{
    public class ClusterObject
    {
        private string objectName;
        private double[] attributeArray;

        public string ObjectName { get; set; }
        public double[] AttributeArray { get; set; }

        public ClusterObject(string objectName, double[] attributeArray)
        {
            this.objectName = objectName;
            this.attributeArray = attributeArray;
        }
    }
}