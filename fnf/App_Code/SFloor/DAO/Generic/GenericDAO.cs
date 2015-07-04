using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Text;
using MFO.Loggers;
using MFO.Utils;

/// <summary>
/// Summary description for Database
/// </summary>
/// 
namespace SFloor.DAO.Generic
{
    public static class GenericDAO
    {
        private static string conString = ConfigUtil.DbConnectionString;
        private static SqlConnection con = null;
        private static SqlCommand cmd = null;
        private static SqlDataReader reader = null;

        static GenericDAO()
        {
            Logger.Info("START Database Database property");
            con = new SqlConnection(conString);
            Logger.Info("Connectinon String " + conString);
            cmd = new SqlCommand();
            cmd.Connection = con;
            Logger.Info("END Database Database property");
        }

        public static DataTable getDataTable(string query)
        {
            try
            {
                Logger.Info("START getDataTable() query = " + query);
                if (null != query && !"".Equals(query.Trim()))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable td = new DataTable();
                        da.Fill(td);
                        Logger.Info("Recived Rows = " + td.Rows.Count);
                        return td;

                    }
                }
                else
                {
                    Logger.Warning("query is empty ");
                }
            }
            catch (Exception e)
            {
                Logger.Error("Exception Occuer While Excecuting the query " + query, e);
            }
            finally
            {
                con.Close();
                cmd.Parameters.Clear();
                Logger.Info("END getDataTable()");
            }
            return null;

        }
        public static DataTable getDataTableByTableName(string query)
        {
            return getDataTable("select * from " + query);

        }

        public static Object scalarQuery(String query)
        {
            Object value = null;
            try
            {
                Logger.Info("START excecuteScalar() query = " + query);
                if (null != query && !"".Equals(query.Trim()))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    value = cmd.ExecuteScalar();
                    if (null != value)
                    {
                        Logger.Info(value + " record(s) recived ");
                    }
                    else
                    {
                        Logger.Warning("zero record recived ");
                    }
                }
                else
                {
                    Logger.Warning(" excecuteScalar() query is empty ");
                }
            }
            catch (Exception e)
            {
                Logger.Error("Exception Occuer While Excecuting the query " + query, e);
            }
            finally
            {
                con.Close();
                cmd.Parameters.Clear();
                Logger.Info("END excecuteScalar()");
            }

            return value;

        }
        public static int? deleteQuery(string query)
        {
            Logger.Info("executing deleteQuery will call update query");
            return updateQuery(query);
        }
        public static int? updateQuery(String query)
        {
            int? count = null;
            try
            {
                Logger.Info("START updateTable() query = " + query);
                if (null != query && !"".Equals(query.Trim()))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    count = cmd.ExecuteNonQuery();
                    Logger.Info(count + " record(s) update ");
                }
                else
                {
                    Logger.Warning(" updateTable() query is empty ");
                }
            }
            catch (Exception e)
            {
                Logger.Error("Exception Occuer While Excecuting the query " + query, e);
            }
            finally
            {
                con.Close();
                cmd.Parameters.Clear();
                Logger.Info("END updateTable()");
            }
            return count;

        }
        public static int insertQuery(string query)
        {
            int value = 0;
            try
            {
                Logger.Info("START insert() query = " + query);
                if (null != query && !"".Equals(query.Trim()))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    value = cmd.ExecuteNonQuery();
                    Logger.Debug(value + " record(s) inserted ");
                }
                else
                {
                    Logger.Warning(" insert() query is empty ");
                }
            }
            catch (Exception e)
            {
                Logger.Error("Exception Occuer While Excecuting the query " + query, e);
            }
            finally
            {
                con.Close();
                cmd.Parameters.Clear();
                Logger.Info("END insert()");
            }

            return value;

        }

        public static int insertQuery(string query, IDictionary<String, String> colDic)
        {
                int value = 0;
            try
            {
                Logger.Info("START insert() query = " + query);
                if (null != query && !"".Equals(query.Trim()))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    addParmInCMD(cmd,colDic);
                    value = cmd.ExecuteNonQuery();
                    Logger.Debug(value + " record(s) inserted ");
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT @@IDENTITY";

                    // Get the last inserted id.
                    value = Convert.ToInt32(cmd.ExecuteScalar());
                    
                }
                else
                {
                    Logger.Warning(" insert() query is empty ");
                }
            }
            catch (Exception e)
            {
                Logger.Error("Exception Occuer While Excecuting the query " + query, e);
            }
            finally
            {
                con.Close();
                cmd.Parameters.Clear();
                Logger.Info("END insert()");
            }
            return value;
        }
        public static int? updateQuery(String query, IDictionary<String, String> colDic)
        {
            int? count = null;
            try
            {
                Logger.Info("START updateTable() query = " + query);
                if (null != query && !"".Equals(query.Trim()))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    addParmInCMD(cmd, colDic);
                    count = cmd.ExecuteNonQuery();
                    Logger.Info(count + " record(s) update ");
                }
                else
                {
                    Logger.Warning(" updateTable() query is empty ");
                }
            }
            catch (Exception e)
            {
                Logger.Error("Exception Occuer While Excecuting the query " + query, e);
            }
            finally
            {
                con.Close();
                cmd.Parameters.Clear();
                Logger.Info("END updateTable()");
            }
            return count;


        }

        public static DataTable getDataTableByAndClause(String table, IDictionary<String, String> colDic)
        {
            String query = "";
            try
            {
                Logger.Info("START getDataTableByAndClause()  ");
                if (null == table || "".Equals(table.Trim()))
                    return null;

                query = createQuery(table, colDic, "AND");
                if (null != query && !"".Equals(query.Trim()))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable td = new DataTable();
                        da.Fill(td);
                        Logger.Info("Recived Rows = " + td.Rows.Count);
                        return td;

                    }
                }
                else
                {
                    Logger.Warning("query is empty ");
                }
            }
            catch (Exception e)
            {
                Logger.Error("Exception Occuer While Excecuting the query " + query, e);
            }
            finally
            {
                con.Close();
                cmd.Parameters.Clear();
                Logger.Info("END getDataTableByAndClause()");
            }
            return null;

        }

        public static DataTable getDataTableByORClause(String table, IDictionary<String, String> colDic)
        {
            String query = "";
            try
            {
                Logger.Info("START getDataTableByORClause()  ");
                if (null == table || "".Equals(table.Trim()))
                    return null;

                query = createQuery(table, colDic, "OR");
                if (null != query && !"".Equals(query.Trim()))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable td = new DataTable();
                        da.Fill(td);
                        Logger.Info("Recived Rows = " + td.Rows.Count);
                        return td;

                    }
                }
                else
                {
                    Logger.Warning("query is empty ");
                }
            }
            catch (Exception e)
            {
                Logger.Error("Exception Occuer While Excecuting the query " + query, e);
            }
            finally
            {

                con.Close();
                cmd.Parameters.Clear();
                Logger.Info("END getDataTableByORClause()");
            }
            return null;

        }
        private static String createQuery(String table, IDictionary<String, String> colDic, String opr)
        {
            StringBuilder query = new StringBuilder(100000);
            query.Append("SELECT * FROM " + table);
            if (null != colDic && colDic.Count > 0)
            {
                query.Append(" WHERE ");
                foreach (String colName in colDic.Keys)
                {
                    query.Append(" " + colName + " = '" + colDic[colName] + "' " + opr);
                }

            }
            String q = query.ToString().TrimEnd(opr.ToCharArray());
            Logger.Info("Query is " + q);
            return q;
        }
        public static DataTable getTableByProcedure(string procName, Dictionary<string, string> paramDic)
        {
            DataTable dt = new DataTable();
            try
            {
                Logger.Info("START getTableByProcedure()  procName :" + procName);
                if (null != procName && !"".Equals(procName.Trim()))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procName;
                    addParmInCMD(cmd, paramDic);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    Logger.Debug(dt.Rows.Count + " record(s) inserted ");
                }

            }
            catch (Exception e)
            {
                Logger.Error("Exception Occuer While Excecuting the procedure,ProcedureName " + procName, e);
            }
            finally
            {
                con.Close();
                cmd.Parameters.Clear();
                Logger.Info("END getTableByProcedure()");
            }

            return dt;

        }
        public static int? executeProcedure(String procName, IDictionary<string, string> param)
        {
            int value = 0;
            try
            {
                Logger.Info("START executeProcedure() ProcName : " + procName);
                if (null != procName && !"".Equals(procName.Trim()))
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procName;
                    addParmInCMD(cmd, param);
                    value = cmd.ExecuteNonQuery();
                    Logger.Debug(value + " record(s) inserted ");
                }

            }
            catch (Exception e)
            {
                Logger.Error("Exception Occuer While Excecuting the procedure,ProcedureName " + procName, e);
            }
            finally
            {
                con.Close();
                cmd.Parameters.Clear();
                Logger.Info("END executeProcedure()");
            }

            return value;
        }

        private static void addParmInCMD(SqlCommand cmd, IDictionary<string, string> param)
        {
            if (param != null)
            {
                foreach (String colName in param.Keys)
                {
                    cmd.Parameters.AddWithValue(colName, param[colName]);
                }
            }
        }

        public static DataTable getDataTableByParam(String query, IDictionary<String, String> colDic)
        {
            try
            {
                Logger.Info("START getDataTableByParam()  ");
                if (null == query || "".Equals(query.Trim()))
                    return null;

                if (null != query && !"".Equals(query.Trim()))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    addParmInCMD(cmd, colDic);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable td = new DataTable();
                        da.Fill(td);
                        Logger.Info("Recived Rows = " + td.Rows.Count);
                        return td;

                    }
                }
                else
                {
                    Logger.Warning("query is empty ");
                }
            }
            catch (Exception e)
            {
                Logger.Error("Exception Occuer While Excecuting the query " + query, e);
            }
            finally
            {
                con.Close();
                cmd.Parameters.Clear();
                Logger.Info("END getDataTableByAndClause()");
            }
            return null;

        }




    }
}