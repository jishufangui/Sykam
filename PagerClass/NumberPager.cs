using System;
using System.Collections.Generic;
using System.Text;

namespace PagerClass
{
    public partial class PageSet
    {
        //数字分页
        public String GeneratePagers()
        {
            StringBuilder result = new StringBuilder();
            int pageRoot, pageFoot;

            if ((currentPage - stepNum) < 1)
                pageRoot = 1;
            else
                pageRoot = currentPage - stepNum;

            if ((currentPage + stepNum) > pageCount)
                pageFoot = pageCount;
            else
                pageFoot = currentPage + stepNum;


            result.Append("<div style=\"line-height:30px;width:98%;text-align:left;\">");

            if (pageRoot == 1)
            {
                if (this.currentPage == 1)
                {
                    result.Append("<font color=\"#888888\" style=\"font-size:12px;\">首页</font>&nbsp;&nbsp;");
                    result.Append("<font color=\"#888888\" style=\"font-size:12px;\">上页</font>&nbsp;&nbsp;");
                }
                else
                {
                    result.Append("<a href=\"?page=1" + url + "\" title=\"首页\"><font style=\"font-size:12px;\">首页</font></a>&nbsp;&nbsp;");
                    result.Append("<a href=\"?page=" + (currentPage - 1) + "" + url + "\" title=\"上一页\"><font style=\"font-size:12px;\">上页</font></a>&nbsp;&nbsp;");
                }
            }
            else
            {
                result.Append("<a href=\"?page=1" + url + "\" title=\"首页\"><font style=\"font-size:12px;\">首页</font></a>&nbsp;&nbsp;");
                result.Append("<a href=\"?page=" + (currentPage - 1) + "" + url + "\" title=\"上一页\"><font style=\"font-size:12px;\">上页</font></a>&nbsp;&nbsp;...&nbsp;&nbsp;");
            }

            for (int i = pageRoot; i <= pageFoot; i++)
            {
                if (i == currentPage)
                    result.Append("<font color=\"red\">" + i + "</font>&nbsp;&nbsp;");
                else
                {
                    result.Append("<a href=\"?page=" + i + "" + url + "\">[&nbsp;" + i + "&nbsp;]</a>&nbsp;&nbsp;");
                }
            }

            if (pageFoot == pageCount)
            {
                if (currentPage == pageCount)
                {
                    result.Append("<font color=\"#888888\" style=\"font-size:12px;\">下页</font>&nbsp;&nbsp;");
                    result.Append("<font color=\"#888888\" style=\"font-size:12px;\">尾页</font>&nbsp;&nbsp;");
                }
                else
                {
                    result.Append("<a href=\"?page=" + (currentPage + 1) + "" + url + "\" title=\"下一页\"><font  style=\"font-size:12px;\">下页</font></a>&nbsp;&nbsp;");
                    result.Append("<a href=\"?page=" + pageCount + "" + url + "\" title=\"尾页\"><font  style=\"font-size:12px;\">尾页</font></a>&nbsp;&nbsp;");

                }
            }
            else
            {
                result.Append("...&nbsp;&nbsp;<a href=\"?page=" + (currentPage + 1) + "" + url + "\" title=\"下一页\"><font  style=\"font-size:12px;\">下页</font></a>&nbsp;&nbsp;");
                result.Append("<a href=\"?page=" + pageCount + "" + url + "\" title=\"尾页\"><font style=\"font-size:12px;\">尾页</font></a>&nbsp;&nbsp;");
            }

            result.Append("&nbsp;&nbsp;共&nbsp;<font color=\"red\">" + pageCount + "</font>&nbsp;页&nbsp;<font color=\"red\">" + recordCount + "</font>&nbsp;条&nbsp;");
            //result.Append("&nbsp;&nbsp;<select size=\"1\" onchange=\"window.location.href='?page='+this.options[this.selectedIndex].value+'" + url + "'\">");

            //for (int j = pageRoot; j <= pageFoot; j++)
            //{
            //    result.Append("<option value=\"" + j + "\"");
            //    if (currentPage == j)
            //        result.Append(" selected");
            //    result.Append(">第" + j + "页</option>");
            //}

            //result.Append("</select>");
            result.Append("</div>");

            return result.ToString();
        }
    }
}
