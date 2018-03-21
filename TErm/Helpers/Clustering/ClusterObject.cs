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
        private int spentTime;

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
        public int SpentTime
        {
            get { return spentTime; }
            set { spentTime = value; }
        }

        public ClusterObject() { }

        public ClusterObject(string objectName, double[] attributeArray, int spentTime)
        {
            this.objectName = objectName;
            this.attributeArray = attributeArray;
            this.spentTime = spentTime;
        }
    }
}