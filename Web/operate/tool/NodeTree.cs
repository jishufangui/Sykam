using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using TBLL;
using TDAl;
using TModel;
namespace Web.operate.tool
{
    public  class NodeTree
    {


        #region 生成频道类别树
        /// <summary>
        /// 生成频道类别树
        /// </summary>
        /// <param name="dt">类别datatable<</param>
        /// <param name="pid">父类ID</param>
        /// <param name="layer">当前层级，默认为0即可<</param>
        /// <returns></returns>
        public static string GetNodeTree(DataTable dt, int pid, int layer)
        {
            string nbsp = string.Empty;//类别前空格
            StringBuilder sbtree = new StringBuilder();
            string seltex = "ParentID="+pid;
            DataRow[] dr = dt.Select(seltex);

            if (layer == 0)
            {
            }
            else
            {
                for (int n = 0; n < layer; n++)
                {
                    nbsp = nbsp + "&nbsp;&nbsp;";
                }
            }
            layer++;
            for (int i = 0; i < dr.Length; i++)
            {
                sbtree.Append("<option value='" + dr[i]["NodeId"] + "'>" + nbsp + "|-" + dr[i]["NodeName"] + "</option>");
                sbtree.Append(GetNodeTree(dt, (int)dr[i]["NodeId"], layer));
            }


            return sbtree.ToString();
        }


        /// <summary>
        /// 生成频道类别树，带默认选中节点
        /// </summary>
        /// <param name="dt">类别datatable</param>
        /// <param name="pid">父类ID</param>
        /// <param name="layer">当前层级，默认为0即可</param>
        /// <param name="currentid">当前频道ID</param>
        /// <returns></returns>
        public static string GetNodeTree(DataTable dt, int pid, int layer, int currentid)
        {
            string nbsp = string.Empty;//类别前空格
            StringBuilder sbtree = new StringBuilder();
            string seltex = "ParentID=" + pid;
            DataRow[] dr = dt.Select(seltex);

            if (layer == 0)
            {
            }
            else
            {
                for (int n = 0; n < layer; n++)
                {
                    nbsp = nbsp + "&nbsp;&nbsp;";
                }
            }
            layer++;
            for (int i = 0; i < dr.Length; i++)
            {
                if (dr[i]["NodeId"].Equals(currentid))
                {
                    sbtree.Append("<option value='" + dr[i]["NodeId"] + "' selected='selected'>" + nbsp + "|-" + dr[i]["NodeName"] + "</option>");
                }
                else
                {
                    sbtree.Append("<option value='" + dr[i]["NodeId"] + "'>" + nbsp + "|-" + dr[i]["NodeName"] + "</option>");
                }
                sbtree.Append(GetNodeTree(dt, (int)dr[i]["NodeId"], layer, currentid));
            }

           
            return sbtree.ToString();

        }

        /// <summary>
        /// 将所有信息类生成类别树（jquery树）
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="pid"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static string GetJqueryNodeTree(DataTable dt, int pid)
        {
            string nbsp = string.Empty;//类别前空格
            StringBuilder sbtree = new StringBuilder();
            string seltex = "ParentID=" + pid;
            DataRow[] dr = dt.Select(seltex);
            for (int i = 0; i < dr.Length; i++)
            {
              
                if (dt.Select("ParentID=" + (int)dr[i]["NodeId"]).Count() > 0)
                {
                    sbtree.Append("<li><span class=\"folder\"><a href='Info_List.aspx?cid=" + dr[i]["NodeId"] + "' target='_parent'>" + dr[i]["NodeName"] + "</a></span>");
                    sbtree.Append("<ul>");
                    sbtree.Append(GetJqueryNodeTree(dt, (int)dr[i]["NodeId"]));
                    sbtree.Append("</ul>");
                }
                else
                {
                    sbtree.Append("<li><span class=\"file\"><a href='Info_List.aspx?cid=" + dr[i]["NodeId"] + "' target='_parent'>" + dr[i]["NodeName"] + "</a></span>");
                }
                sbtree.Append("</li>");
            }

            return sbtree.ToString();
        }
        #endregion


        #region  根据类别树 生成类别路径
        /// <summary>
        /// 根据类别树 生成类别路径
        /// </summary>
        /// <param name="Path">类别树</param>
        /// <returns></returns>
        public static string GetNodePath(string Path)
        {
            StringBuilder sb = new StringBuilder();
            if (Path.Trim() == "")
                sb.Append("根频道");
            else
            {
                string[] PathArray = Path.Split(',');

                if (PathArray.Length > 0)
                {
                    foreach (string cateid in PathArray)
                    {
                        if (cateid.Trim() != "")
                        {
                            int nodeid = 0;
                            Int32.TryParse(cateid, out nodeid);
                            if (nodeid == 0)
                            {
                                sb.Append("<a href='InfoCate_List.aspx'>根频道</a>");
                            }
                            sb.Append("<a href='InfoCate_List.aspx?pid=" + cateid + "'>");
                            TBLL.NodeBLL NodeOperate = new NodeBLL();
                            sb.Append("<span>" + NodeOperate.GetNode(nodeid).NodeName + "</span>");
                            sb.Append("</a> >> ");
                        }
                    }
                }
            }

            return sb.ToString();

        }
        #endregion
    }
}
