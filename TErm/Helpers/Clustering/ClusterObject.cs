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

        public string ObjectName
        {
            get { return objectName; }
            set { objectName = value; }
        }
        public double[] AttributeArray
        {
            get { return attributeArray; }
            set { attributeArray = value; }
        }

        public ClusterObject() { }

        public ClusterObject(string objectName, double[] attributeArray)
        {
            this.objectName = objectName;
            this.attributeArray = attributeArray;
        }
    }
}