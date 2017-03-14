using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Specialized;
using DataHelper;
using CommonLibrary;
using TModel;
namespace TDAl.sqlserver
{
    class SqlNodeOperate : INodeOperate
    {

        
        #region 变量
        private string SelectNodes = "Select NodeID,NodeName,NodeIdentifier,ParentID,NodePath,NodeMemo,NodePic,SortID,IsRecom,IsHtml,HtmlPath,NodeTemplate,Meta_Description,Meta_KeyWords from T_NodeList where 1=1 ";//查询主体
        private string OrderCondition1 = " Order by SortID asc,NodeID desc";//排序条件
        private string WhereStringByParentID = " and ParentID=@ParentID";
        private string WhereStringByNodeID = " and NodeID=@NodeID";
        private static string _connection = string.Empty;
        DataHelper.DbHelper  dh ;
        #endregion
        public SqlNodeOperate()
        {
            _connection = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"].ToString();
            dh = new SqlHelper(_connection);
        }

        #region 获取所有节点
        /// <summary>
        /// 获取所有节点
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllNode()
        {
          
           dh.Open();
           DataTable dt = dh.GetDataTable(CommandType.Text, SelectNodes + OrderCondition1, null); 
           dh.Close();

           return  dt;
        }
        #endregion

        #region 获取指定父类别下的子节点
        public DataTable GetChildNode(int pid)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@ParentID",pid.ToString());
            dh.Open();
            DataTable dt = dh.GetDataTable(CommandType.Text, SelectNodes + WhereStringByParentID + OrderCondition1, null);
            dh.Close();
            return dt;
        }
        #endregion

        #region  获取指定ID的节点
        /// <summary>
        ///  获取指定ID的节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TNode GetNode(int id)
        {
            TNode Node = new TNode();
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@NodeID",id.ToString());
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, SelectNodes + WhereStringByNodeID, nvc))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    int nodeid = 0;
                    int sortid = 0;
                    int pid = 0;
                    Int32.TryParse(dr[0].ToString().Trim(), out nodeid);
                    Int32.TryParse(dr[3].ToString().Trim(), out pid);
                    Int32.TryParse(dr[7].ToString().Trim(), out sortid);

                    bool IsRecom;
                    bool IsHtml;
                    bool.TryParse(dr[8].ToString().Trim(), out IsRecom);
                    bool.TryParse(dr[9].ToString().Trim(), out IsHtml);

                   // Node.NodeID = nodeid;
                    Node.NodeName = dr[1].ToString().Trim();
                    Node.NodeIdentifier = dr[2].ToString().Trim();
                    Node.ParentID = pid;
                    Node.NodePath = dr[4].ToString();
                    Node.NodeMemo = dr[5].ToString().Trim();
                    Node.NodePic = dr[6].ToString().Trim();
                    Node.SortID = sortid;
                    Node.IsRecom = IsRecom;
                    Node.IsHtml = IsHtml;
                    Node.HtmlPath = dr[10].ToString().Trim();
                    Node.NodeTemplate = dr[11].ToString();
                    Node.Meta_Description = dr[12].ToString().Trim();
                    Node.Meta_KeyWords = dr[13].ToString().Trim();


                }
            }
            dh.Close();
            return Node;
        }

        #endregion

        #region 添加节点
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="NodeName"></param>
        /// <param name="NodeIdentifier"></param>
        /// <param name="ParentID"></param>
        /// <param name="NodeMemo"></param>
        /// <param name="NodePic"></param>
        /// <param name="SortID"></param>
        /// <param name="IsRecom"></param>
        /// <param name="IsHtml"></param>
        /// <param name="HtmlPath"></param>
        /// <param name="NodeTemplate"></param>
        /// <param name="Meta_Description"></param>
        /// <param name="Meta_KeyWords"></param>
        /// <returns></returns>
        public int  AddNode(TNode Node)
        {
            int stat=0;
            string Nodepath=string.Empty;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@NodeName", Node.NodeName);
            nvc.Add("@NodeIdentifier", Node.NodeIdentifier);
            nvc.Add("@NodePath", Node.NodePath);
            nvc.Add("@NodeMemo", Node.NodeMemo);
            nvc.Add("@NodePic", Node.NodePic);
            nvc.Add("@SortID", Node.SortID.ToString());
            nvc.Add("@IsRecom", Node.IsRecom.ToString());
            nvc.Add("@IsHtml", Node.IsHtml.ToString());
            nvc.Add("@HtmlPath", Node.HtmlPath.ToString().Trim());
            nvc.Add("@NodeTemplate", Node.NodeTemplate.Trim());
            nvc.Add("@Meta_Description", Node.Meta_Description.Trim());
            nvc.Add("@Meta_KeyWords", Node.Meta_KeyWords.Trim());
            
            dh.Open();
            stat = dh.ExecuteNonQuery(CommandType.Text, "Insert into T_NodeList(NodeName,NodeIdentifier,NodePath,NodeMemo,NodePic,SortID,IsRecom,IsHtml,HtmlPath,NodeTemplate,Meta_Description,Meta_KeyWords) Values (@NodeName,@NodeIdentifier,@NodePath,@NodeMemo,@NodePic,@SortID,@IsRecom,@IsHtml,@HtmlPath,@NodeTemplate,@Meta_Description,@Meta_KeyWords)", nvc);
            dh.Close();

            UpdateNodePath(Node.ParentID, "",null);
            return stat;
        }

        #endregion

        #region 修改节点
        /// <summary>
        /// 修改节点
        /// </summary>
        /// <param name="NodeID"></param>
        /// <param name="Node"></param>
        /// <returns></returns>
        public int UpdateNode(int NodeID,TNode Node)
        {   
            int stat = 0;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@NodeName",Node.NodeName.Trim());
            nvc.Add("@NodeIdentifier",Node.NodeIdentifier.Trim());
            nvc.Add("@NodePath",Node.NodePath);
            nvc.Add("@NodeMemo", Node.NodeMemo.Trim());
            nvc.Add("@NodePic", Node.NodePic.Trim());
            nvc.Add("@SortID", Node.SortID.ToString());
            nvc.Add("@IsRecom", Node.IsRecom.ToString());
            nvc.Add("@IsHtml", Node.IsHtml.ToString());
            nvc.Add("@HtmlPath", Node.HtmlPath.Trim());
            nvc.Add("@NodeTemplate", Node.NodeTemplate.Trim());
            nvc.Add("@Meta_Description", Node.Meta_Description);
            nvc.Add("@Meta_KeyWords", Node.Meta_KeyWords);
            nvc.Add("@NodeID", Node.NodeID.ToString());

            dh.Open();
            stat = dh.ExecuteNonQuery(CommandType.Text, "Update T_NodeList set NodeName=@NodeName,NodeIdentifier=@NodeIdentifier,NodePath=@NodePath,NodeMemo=@NodeMemo,NodePic=@NodePic,SortID=@SortID,IsRecom=@IsRecom,IsHtml=@IsHtml,HtmlPath=@HtmlPath,NodeTemplate=@NodeTemplate,Meta_Description=@Meta_Description,Meta_KeyWords=@Meta_KeyWords where NodeID=@NodeID", nvc);
            dh.Close();

            UpdateNodePath(Node.ParentID, Node.NodePath,NodeID);
            return stat;
        }

        #endregion

        #region  删除节点
        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int DeleteNode(TNode node)
        {
            int stat = 0;
            int id = 0;
            string CatePic = node.NodePic;
            CommonLibrary.CommOperate.DeleteFile(CatePic);//删除图片文件
            id = node.NodeID;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@NodeID",id.ToString());
            stat = dh.ExecuteNonQuery(CommandType.Text, "Delete from T_NodeList where NodeID=@NodeID", nvc);
            return stat;
        }
        #endregion

        #region  通过指定条件获取节点，并通过指定条件对节点排序
        /// <summary>
        /// 通过指定条件获取节点，并通过指定条件对节点排序
        /// </summary>
        /// <param name="FiledName">条件字段</param>
        /// <param name="FiledValue">条件值</param>
        /// <param name="OrderCondition">排序条件</param>
        /// <param name="startid">起始ID</param>
        /// <param name="endid">结束ID</param>
        /// <returns></returns>
        public DataTable GetNodeByCondition(ArrayList FiledName, ArrayList FiledValue, string  OrderCondition,int startid,int  endid)
        {
            string sbCondition = string.Empty;
            sbCondition = SelectCondition(FiledName, FiledValue);

            string cmdtxt = "select * from (select NodeID,NodeName,NodeIdentifier,ParentID,NodePath,NodeMemo,NodePic,SortID,IsRecom,IsHtml,HtmlPath,NodeTemplate,Meta_Description,Meta_KeyWords ,row_number() over (" + OrderCondition + ") as rowno from T_NodeList " + sbCondition + "  ) as row  where rowno between " + startid + " and " + endid.ToString() + " order by " + OrderCondition;


            string seltext =string.Empty;
            if (OrderCondition==null)
            {
                seltext = SelectNodes + sbCondition.ToString();
            }
            else if (OrderCondition.ToString().Trim() == "")
            {
                seltext = SelectNodes + sbCondition.ToString();
            }
            else
            {
                seltext = SelectNodes + sbCondition.ToString() + "  order by  " + OrderCondition;
            }
            dh.Open();
            DataTable dt = dh.GetDataTable(CommandType.Text, seltext, null);
            dh.Close();
            return dt;
        }


        #endregion

        #region 根据条件获取记录数
        /// <summary>
        /// 根据条件获取记录数
        /// </summary>
        /// <param name="FiledName">字段</param>
        /// <param name="FiledValue">值</param>
        /// <returns></returns>
        public int GetNodeNumByCondition(ArrayList FiledName, ArrayList FiledValue)
        {
            int recordcount = 0;
            string sbCondition = string.Empty;
            sbCondition = SelectCondition(FiledName, FiledValue);
            string seltxt = "Select count(*) from T_NodeList where 1=1 " + sbCondition;
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, seltxt, null))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    Int32.TryParse(dr[0].ToString(), out recordcount);
                }
                else
                {
                    recordcount = 0;
                }
            }
            dh.Close();
            return recordcount;
        }

        #endregion

        #region  修改nodepath
        /// <summary>
        /// 修改nodepath和parentid
        /// </summary>
        /// <param name="toid">新的parentid</param>
        /// <param name="path">当前path，没有可为空</param>
        /// <param name="currentid">当前节点ID，没有则自动获取最新插入ID作为当前ID</param>
        /// <returns></returns>
        public int UpdateNodePath(int toid, string path,int? currentid)
        {
            int stat = 0;
            string CurrentId = string.Empty; ;//当前节点ID
            dh.Open();
            if (currentid.HasValue==false)
            {

                using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "select IDENT_CURRENT('T_NodeList')", null))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        CurrentId = dr[0].ToString().Trim();
                    }
                    else
                    {
                        CurrentId = "0";
                    }
                }
            }
            else
            {
                CurrentId = currentid.ToString() ;
            }
 
         


            NameValueCollection nvc = new NameValueCollection();
           
            string NewPath = string.Empty;
   
            if (toid == 0)//移动到一级栏目
            {
                NewPath = "0," + CurrentId + ",";

            }
            else //如果不是一级栏目
            {
                string pid = toid.ToString();

                nvc.Add("@NodeID", pid);
                using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "Select NodePath from T_NodeList where NodeID=@NodeID", nvc))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        string ToPath = dr[0].ToString().Trim();
                        NewPath = ToPath + CurrentId + ",";


                        if (path.Contains(ToPath + CurrentId) && toid!= 0)
                        {
                            dh.Close();
                            CommonLibrary.RunJs.AlertAndBack("要移动的路径与当前路径相同!");
                        }


                        if ((ToPath).Contains(path)&&path.Trim()!="")
                        {
                            dh.Close();
                            CommonLibrary.RunJs.AlertAndBack("要移动的路径不能是当前类别的子节点");
                        }


                    }
                    else
                    {
                        dh.Close();
                        CommonLibrary.RunJs.AlertAndBack("不存在父节点，请检查");
                    }
                }



            }

            nvc.Clear();
            nvc.Add("@NodePath",NewPath);
            nvc.Add("@ParentID",toid.ToString());
            nvc.Add("@NodeID", CurrentId);

            string UpdateNode = "Update T_NodeList Set NodePath=@NodePath,ParentID=@ParentID where NodeID=@NodeID";
                     
            dh.BeginTrans();
            dh.ExecuteNonQuery(CommandType.Text, UpdateNode, nvc);
            if (path.Trim()!= "")
            {

                #region 更新子节点path,sql版

                string UpdateChildNodes = "Update T_NodeList Set NodePath= Replace(NodePath,'" + path + "','" + NewPath + "')  where CHARINDEX('" + path + "',NodePath)>0   ";

                #endregion
                dh.ExecuteNonQuery(CommandType.Text, UpdateChildNodes, null);
            }
            dh.CommitTrans();
            dh.Close();

            return stat;
        }

        #endregion

        #region  根据arraylist生成查询条件
        /// <summary>
        /// 根据arraylist 生成查询条件
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <returns></returns>
        public string SelectCondition(ArrayList FiledName, ArrayList FiledValue)
        {
            StringBuilder sbCondition = new StringBuilder();//查询条件
            if (FiledName != null && FiledValue != null)
            {
                for (int i = 0; i < FiledName.Count; i++)
                {
                    if (FiledValue[i].ToString().Trim() != "")
                    {
                        string type = FiledValue[i].GetType().ToString().ToLower();
                        if (FiledValue[i].GetType().ToString().ToLower().Equals("system.string"))
                        {
                            sbCondition.Append(" and  " + FiledName[i].ToString() + "  like  '" + FiledValue[i].ToString() + "'");
                        }
                        else
                        {
                            sbCondition.Append(" and  " + FiledName[i].ToString() + "  =  " + FiledValue[i].ToString());
                        }
                    }
                }
            }
            else
            {
                sbCondition.Length = 0;
            }


            return sbCondition.ToString();


        }
        #endregion
    }
}
