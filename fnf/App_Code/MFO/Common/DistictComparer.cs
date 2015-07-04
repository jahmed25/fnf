using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Class1
/// </summary>
///

namespace MFO.Common
{
    public class DistictComparer : IEqualityComparer<DataRow>
    {
        // Size are equal if their names and product numbers are equal. 
        public string colName;
        public DistictComparer(string col)
        {
            this.colName = col;
        }
        public bool Equals(DataRow x, DataRow y)
        {

            //Check whether the compared objects reference the same data. 
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null. 
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the Size' properties are equal. 
            return x[colName] == y[colName] || x[colName].Equals(y[colName]);
        }
        public int GetHashCode(DataRow x)
        {
            //Check whether the object is null 
            if (Object.ReferenceEquals(x, null)) return 0;

            //Get hash code for the Name field if it is not null. 
            int hashProductName = x[colName] == null ? 0 : x[colName].GetHashCode();

            //Get hash code for the Code field. 
            int hashProductCode = x[colName].GetHashCode();

            //Calculate the hash code for the product. 
            return hashProductName ^ hashProductCode;
        }

    }
}