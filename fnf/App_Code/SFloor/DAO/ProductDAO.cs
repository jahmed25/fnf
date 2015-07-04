using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SFloor.DAO.Generic;
using System.Data;

/// <summary>
/// Summary description for ProductDAO
/// </summary>
/// 
namespace SFloor.DAO
{
    public static class ProductDAO
    {
        public static int getInventory(string sku) {
            try
            {
                string invStr = GenericDAO.getDataTable("select Inventory from PRODUCTS where SKUCode ='" + sku + "'").Rows[0][0].ToString();
                return (int)float.Parse(invStr);
            }
            catch {
                return 0;
            }
        }

        public static void updateInventory(DataTable carDT)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataRow row in carDT.Rows)
            {
                string query = "update  PRODUCTS set Inventory=(Inventory-"+row["QTY"]+") where SKUCode=@SKU";
                dic.Add("@SKU", row["SKU"] + "");
                GenericDAO.updateQuery(query, dic);
                dic.Clear();                                   
            }
        }
    }
}