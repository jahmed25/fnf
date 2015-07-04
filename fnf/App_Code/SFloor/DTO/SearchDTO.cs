using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SearchDTO
/// </summary>
/// 
namespace SFloor.DTO
{
    public class SearchDTO
    {
        private string name;
        private string src;
        private string searchVal;
        private  string type;

        private string pid;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string PID
        {
            get { return pid; }
            set { pid = value; }
        }
        public string Src
        {
            get { return src; }
            set { src = value; }
        }
        public string SearchVal
        {
            get { return searchVal; }
            set { searchVal = value; }
        }

        public string Type {
            get
            {
                return type;
            }
            set { type =value;} 
        }
    }
}