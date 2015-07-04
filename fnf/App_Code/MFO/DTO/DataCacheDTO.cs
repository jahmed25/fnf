using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MFO.DTO
{
    class DataCacheDTO
    {
        private DateTime cacheTime;
        private DataTable dt;
        private Object data;

        public DateTime CacheTime
        {
            get { return cacheTime; }
            set { cacheTime = value; }
        }
        public DataTable Dt
        {
            get { return dt; }
            set { dt = value; }
        }
        public Object Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}