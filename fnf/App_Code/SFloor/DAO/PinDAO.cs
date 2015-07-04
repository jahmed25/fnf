using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SFloor.DAO.Generic;
using System.Data;

/// <summary>
/// Summary description for PinDAO
/// </summary>
/// 
namespace SFloor.DAO
{
    public static class PinDAO
    {
        public static DataTable getPinDT() {
            return GenericDAO.getDataTable("SELECT [PinCodeLocation_PinCode],[PinCodeLocation_State],[PinCodeLocation_City],[PinCodeLocation_Mode],[PinCodeLocation_CreationDate],[PinCodeLocation_CreatedName],[PinCodeLocation_RecordStatus]FROM [PinCodeLocation_Master] where PinCodeLocation_RecordStatus='1'");
        }
    }
}