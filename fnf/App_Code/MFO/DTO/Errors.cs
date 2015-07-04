using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Error
/// </summary>
/// 
namespace SFloor.DTO
{
    public class Errors
    {
        public Dictionary<String, String> errors = new Dictionary<String, String>();
        public void addError(string key, string value)
        {
            errors.Add(key, value);
        }
    }
}