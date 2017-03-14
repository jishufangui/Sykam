using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Xml;
namespace Web
{
    public class BaseWeb :System.Web.UI.Page
    {


        public static string Page_Title = string.Empty;
        public static string Page_Keyword = string.Empty;
        public static string Page_Description = string.Empty;


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page_Title = GetTitle();
            Page_Keyword = GetKeywords();
            Page_Description = GetDescription();
            
        }


        #region  通过xml获得keywords
        protected string GetKeywords()
        {

            string keywords = string.Empty;
            try
            {

                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("/SetConfig.xml"));

                XmlNode xn = xd.SelectSingleNode("//Keyword");
                XmlAttribute xa = xn.Attributes["value"];
                keywords = xa.Value;
                xd = null;
            }
            catch (Exception e)
            {
                keywords = e.Message;
            }

            return keywords;
        }

        #endregion

        #region 通过xml获得Description
        protected string GetDescription()
        {
            string Description = string.Empty;
            try
            {

                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("/SetConfig.xml"));

                XmlNode xn = xd.SelectSingleNode("//Description");
                XmlAttribute xa = xn.Attributes["value"];
                Description = xa.Value;
                xd = null;
            }
            catch (Exception e)
            {
                Description = e.Message;
            }
            return Description;

        }

        #endregion


        #region 通过xml获得 Title
        protected string GetTitle()
        {
            string Title = string.Empty;
            try
            {

                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("/SetConfig.xml"));

                XmlNode xn = xd.SelectSingleNode("//Title");
                XmlAttribute xa = xn.Attributes["value"];
                Title = xa.Value;
                xd = null;
            }
            catch (Exception e)
            {
                Title = e.Message;
            }
            return Title;

        }

        #endregion


    }
}
