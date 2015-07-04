using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MFO.Loggers;
using System.Data;
using MFO.Commom;
using MFO.Constants;
using MFO.DTO;
using MFO.DAO;

/// <summary>
/// Summary description for GenericService
/// </summary>
/// 
namespace MFO.Common
{
    public static class GenericService
    {
        private static MenuUserDAO muDAO = new MenuUserDAO();

        public static DataTable getVewImageNewMasterDT()
        {
            Logger.Info("START Categories.getVewImageNewMasterDT()");
            try
            {
				if ("true".Equals(MFO.Utils.ConfigUtil.getValue("cacheEnable").ToString().ToLower()))
				{
					return (DataTable)HttpContext.Current.Application[Constant.Table.VIEW_IMAGE_NEW_MASTER];
				}else{
					MFO.Loggers.Logger.Info("Caching is not Enable");
					return muDAO.getViewImageNewMaster();
				}
               /* if (CommonUtil.isCached(Constant.Table.VIEW_IMAGE_NEW_MASTER))
                {
                    Logger.Info("Fetching DT " + Constant.Table.VIEW_IMAGE_NEW_MASTER + " from Application cache");
                    return ((DataCacheDTO)HttpContext.Current.Application[Constant.Table.VIEW_IMAGE_NEW_MASTER]).Dt;
                }
                else
                {
                    Logger.Info("Fetching DT " + Constant.Table.VIEW_IMAGE_NEW_MASTER + " from DB");
                    DataTable dt = muDAO.getViewImageNewMaster();
                    CommonUtil.DtNullCheck(dt);
                    DataCacheDTO cache = new DataCacheDTO();
                    cache.CacheTime = DateTime.Now;
                    cache.Dt = dt;
                    HttpContext.Current.Application[Constant.Table.VIEW_IMAGE_NEW_MASTER] = cache;
                    Logger.Info("END Categories.getVewImageNewMasterDT()");
                    return dt;
                }*/
            }
            catch (Exception e)
            {
                Logger.Error("Error occur Categories.getVewImageNewMasterDT() ", e);
            }
            Logger.Info("END Categories.getVewImageNewMasterDT()");

            return null;
        }
    }
}