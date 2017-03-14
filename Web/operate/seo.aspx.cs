using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
namespace Web.operate
{
    public partial class seo :BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                tbx_title.Text = GetXmlTitle();
                tbx_Tel.Text = GetXmlTel();
                tbx_ServerTel.Text = GetServerTel();
                tbx_ipc.Text = GetXmlIPC();
                tbx_href.Text = Gethref();
                tbx_Keywords.Text = GetKeywords();
                tbx_Desc.Text = GetDescription();
            }
        }

        #region 获取Title
        protected string GetXmlTitle()
        {
            string Address = string.Empty;
            try
            {


                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("/SetConfig.xml"));


                XmlNode xn = xd.SelectSingleNode("//Title");

                XmlAttribute xa = xn.Attributes["value"];

                Address = xa.Value;
                xd = null;
            }
            catch (Exception e)
            {
                Address = e.Message;
            }
            return Address;
        }
        #endregion


        #region 通过xml获取公司电话
        /// <summary>
        /// 获得公司电话
        /// </summary>
        /// <returns></returns>
        protected string GetXmlTel()
        {
            string Tel = string.Empty;
            try
            {

                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("/SetConfig.xml"));

                XmlNode xn = xd.SelectSingleNode("//Tel");
                XmlAttribute xa = xn.Attributes["value"];
                Tel = xa.Value;
                xd = null;
            }
            catch (Exception e)
            {
                Tel = e.Message;
            }


            return Tel;
        }

        #endregion

        #region 通过xml获取公司IPC号
        protected string GetXmlIPC()
        {
            string IPC = string.Empty;
            string href = string.Empty;
            string result = string.Empty;
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("/SetConfig.xml"));

                XmlNode xn = xd.SelectSingleNode("//IPCNum");
                XmlAttribute xa = xn.Attributes["value"];

                IPC = xa.Value;

                xd = null;
                result = IPC;

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }


            return result;


        }

        #endregion


        #region 通过xml获取客服电话
        protected string GetServerTel()
        {
            string Tel = string.Empty;
            try
            {

                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("/SetConfig.xml"));

                XmlNode xn = xd.SelectSingleNode("//ServerTel");
                XmlAttribute xa = xn.Attributes["value"];
                Tel = xa.Value;
                xd = null;
            }
            catch (Exception e)
            {
                Tel = e.Message;
            }


            return Tel;

        }
        #endregion

        #region 通过xml获得 IPC链接


        protected string Gethref()
        {
            string href = string.Empty;
            try
            {

                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("/SetConfig.xml"));

                XmlNode xn = xd.SelectSingleNode("//IPCNum");
                XmlAttribute xa = xn.Attributes["href"];
                href = xa.Value;
                xd = null;
            }
            catch (Exception e)
            {
                href = e.Message;
            }


            return href;

        }

        #endregion

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



        #region Title写入xml

        protected void WriteXmlTitle(string title)
        {
            try
            {

                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("/SetConfig.xml"));


                XmlNode xn = xd.SelectSingleNode("//Title");

                XmlAttribute xa = xn.Attributes["value"];

                xa.InnerText = title;
                xd.Save(Server.MapPath("/SetConfig.xml"));
            }
            catch (Exception e)
            {
                return;
            }

        }

        #endregion


        #region 公司电话写入xml
        protected void WriteXmlTel(string CompanyTel)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("/SetConfig.xml"));
                XmlNode xn = xd.SelectSingleNode("//Tel");
                XmlAttribute xa = xn.Attributes["value"];
                xa.InnerText = CompanyTel;
                xd.Save(Server.MapPath("/SetConfig.xml"));

            }
            catch (Exception ex)
            {
                return;
            }
        }

        #endregion


        #region 客服电话写入xml
        protected void WriteServerTel(string ServerTel)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("/SetConfig.xml"));
                XmlNode xn = xd.SelectSingleNode("//ServerTel");
                XmlAttribute xa = xn.Attributes["value"];
                xa.InnerText = ServerTel;
                xd.Save(Server.MapPath("/SetConfig.xml"));
            }
            catch (Exception ex)
            {
                return;
            }

        }

        #endregion

        #region  icp 信息写入

        protected void WriteIcp(string icp, string href)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("/SetConfig.xml"));
                XmlNode xn = xd.SelectSingleNode("//IPCNum");
                XmlAttribute xa = xn.Attributes["value"];
                XmlAttribute xh = xn.Attributes["href"];
                xa.InnerText = icp;
                xh.InnerText = href;
                xd.Save(Server.MapPath("/SetConfig.xml"));
            }
            catch (Exception ex)
            {
                return;
            }
        }

        #endregion


        #region  关键字写入xml
        protected void WriteKeyWords(string keyword)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("/SetConfig.xml"));
                XmlNode xn = xd.SelectSingleNode("//Keyword");
                XmlAttribute xa = xn.Attributes["value"];
                xa.InnerText = keyword;
                xd.Save(Server.MapPath("/SetConfig.xml"));

            }
            catch (Exception ex)
            {
                return;
            }
        }

        #endregion


        #region 网站描述写入xml

        protected void WriteDescription(string Description)
        {

            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("/SetConfig.xml"));
                XmlNode xn = xd.SelectSingleNode("//Description");
                XmlAttribute xa = xn.Attributes["value"];
                xa.InnerText = Description;
                xd.Save(Server.MapPath("/SetConfig.xml"));

            }
            catch (Exception ex)
            {
                return;
            }
        }

        #endregion

        protected void button1_Click(object sender, EventArgs e)
        {

            WriteXmlTitle(tbx_title.Text);
            WriteXmlTel(tbx_Tel.Text);
            WriteServerTel(tbx_ServerTel.Text);
            WriteIcp(tbx_ipc.Text, tbx_href.Text);
            WriteKeyWords(tbx_Keywords.Text);
            WriteDescription(tbx_Desc.Text);

            CommonLibrary.RunJs.AlertAndRedirect("网站配置信息修改成功", "seo.aspx");
        }
    }
}
