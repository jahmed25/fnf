using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MFO.Common;

/// <summary>
/// Summary description for CompareService
/// </summary>
/// \\
/// 
namespace SFloor.Services
{
    public static class CompareService
    {
        public static DataTable getDTBySKUs(string sku0, string sku1, string sku2, string sku3)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUCode")==sku0
                || dr.Field<String>("SKUCode") == sku1
                || dr.Field<String>("SKUCode") == sku2
                || dr.Field<String>("SKUCode") == sku3
                select dr;
            return query.CopyToDataTable();
        }


        public static DataTable getSizeDTBySKUs(string sku)
        {
            try
            {
                DataTable dt = GenericService.getVewImageNewMasterDT();
                IEnumerable<DataRow> query =
                    from dr in dt.AsEnumerable()
                    where dr.Field<String>("StyleCode") == sku
                    select dr;
                return query.Distinct(new DistictComparer("Size")).CopyToDataTable();
            }
            catch { }
            return new DataTable();
        }
        public static DataTable getColorsDTBySKUs(string sku)
        {
            try
            {
                DataTable dt = GenericService.getVewImageNewMasterDT();
                IEnumerable<DataRow> query =
                    from dr in dt.AsEnumerable()
                    where dr.Field<String>("StyleCode") == sku
                    select dr;
                return query.Distinct(new DistictComparer("Color")).CopyToDataTable();
            }
            catch { }
            return new DataTable();
        }
    }
}