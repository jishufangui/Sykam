using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;
using TBLL;
using TDAl;
using TModel;
namespace Web.operate
{
    public partial class Competence_Mod : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   
                int AdminID = 0;
                String roles = String.Empty;
                Int32.TryParse( CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"),out AdminID);
                AdminBLL adminbll = new AdminBLL();
                TAdmin tadmin = adminbll.GetAdmin(AdminID);
                Literal1.Text = "<a href='Admin_Mod.aspx?id="+AdminID.ToString()+"'>" + tadmin.Admin_UID + "</a>";
                roles = adminbll.GetCompetence(AdminID);  
              
              
                StringBuilder sb = new StringBuilder();
                CommonLibrary.OperateXml opeXml = new CommonLibrary.OperateXml();
                XmlNodeList nodes = opeXml.SelectNodes("SetUp.xml", "root");
                sb.Append("<table cellpadding=\"3\" cellspacing=\"1\" border=\"0\" width=\"94%\" align=\"left\" bgcolor=\"#DDDDDD\">");

                int i = 0;
                foreach (XmlNode node in nodes)
                {
                    i = i + 1;
                    XmlElement xe = (XmlElement)node;

                    if (i % 2 == 0)
                    {
                        sb.Append("<tr style=\"font-weight:400;\"  bgcolor=\"#EEEEEE\"   align=\"center\">");
                    }
                    else
                    {
                        sb.Append("<tr  bgcolor=\"#FFFFFF\"  style='border-bottom-color:#CCCCCC; border-bottom-style:solid; border-bottom-width:1px;'  align=\"center\">");
                    }
                    sb.Append("<td  align=\"center\" style=\"width:140px;\" class='td4'><input type=\"checkbox\" id=\"" + xe.GetAttribute("id") + "\" " + SetCheckBoxState(roles, xe.GetAttribute("id")) + " onclick=\"SelectSubItems(" + xe.GetAttribute("id") + ",this);\" name=\"chkInput\" value=\"" + xe.GetAttribute("id") + "\" /> <label for=\"" + xe.GetAttribute("id") + "\" >" + xe.GetAttribute("title") + "</label></td>");
                    sb.Append("<td align=\"left\" class='td5'>");

                    XmlNodeList childNodes = node.ChildNodes;
                    sb.Append("<ul style=\"width:100%;padding:0;margin:0;\" id=\"ul_" + xe.GetAttribute("id") + "\">");
                    foreach (XmlNode nod in childNodes)
                    {
                        XmlElement xe1 = (XmlElement)nod;
                        sb.Append("<li style=\"width:140px;list-style:none;float:left;margin-top:4px;\">");
                        sb.Append("<input type=\"checkbox\" id=\"" + xe1.GetAttribute("id") + "\" " + SetCheckBoxState(roles, xe1.GetAttribute("id")) + " onclick=\"CheckSubItems(" + xe1.GetAttribute("parentId") + ");\" name=\"chkInput\" value=\"" + xe1.GetAttribute("id") + "\" /> <label for=\"" + xe1.GetAttribute("id") + "\" style=\"color:#555;\">" + xe1.GetAttribute("title") + "</label>");
                        sb.Append("</li>");
                    }
                    sb.Append("</ul>");

                    sb.Append("</td>");
                    sb.Append("</tr>");
                }

                sb.Append("</table>");
                L_panel.Text = sb.ToString();


            }
        }

        /// <summary>
        /// 通过roles来设置checkbox的选中情况
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private string SetCheckBoxState(string roles, string id)
        {
            string result = String.Empty;
            if (roles.Equals("all") || roles.Contains("all"))
                result = "checked=\"true\"";
            else if (roles.Contains(id.Trim()))
                result = "checked=\"true\"";
            return result;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string roles = CommonLibrary.CommOperate.GetStrFromRequestForm("chkInput");
            int id = 0;
            Int32.TryParse( CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"),out id);
            AdminBLL adminbll = new AdminBLL();
            adminbll.UpdateCompetence(roles, id);
            CommonLibrary.RunJs.PageReplace("Admin_UpdateManage.aspx?LastID=" + id.ToString());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int id = 0;
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"), out id);
            CommonLibrary.RunJs.PageReplace("Admin_Mod.aspx?LastID=" + id.ToString());
        }

    }
}
