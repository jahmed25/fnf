using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MenuDTO
/// </summary>
/// 
namespace SFloor.DTO
{
    public class MenuDTO
    {
        private String heading;
        private String url;
        private List<MenuDTO> contents = new List<MenuDTO>();

        public String Url
        {
            get { return url; }
            set { url = value; }
        }

        public String Heading
        {
            get { return heading; }
            set { heading = value; }
        }
        public List<MenuDTO> Contents
        {
            get { return contents; }
            set { contents = value; }
        }
        public void addContent(MenuDTO content)
        {
            contents.Add(content);
        }



        private string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
}