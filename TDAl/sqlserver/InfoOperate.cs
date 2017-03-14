using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DataHelper;
using CommonLibrary;
using TModel;
namespace TDAl.sqlserver
{
    public  class InfoOperate:IInfoOperate
    {
        DataHelper.DbHelper dh;
        private static string _connection = string.Empty;
        public InfoOperate()
        {
            _connection = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"].ToString();
            dh = new SqlHelper(_connection);
        }

        #region 通过指定id获取信息
        /// <summary>
        /// 通过指定id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TInformation GetInfo(int id)
        {
            TInformation tinfo = new TInformation();
            string cmdtxt = "Select InfoTitle,InfoSubMemo,InfoMemo,BrandID,InfoPic,InfoType,ShopID,InfoStartTime,InfoEndTime,InfoFrom,InfoAddTime,InfoAdder,InfoClicks,IsRecom,SortID,IsHtml,HtmlPath,IsRemote,IsCheck,InfoCateID,InfoETitle,InfoTag from T_InfoList where InfoID=@InfoID";
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@InfoID",id.ToString());
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, cmdtxt, nvc))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    #region 变量赋值
                    tinfo.InfoID = id;
                    tinfo.InfoTitle = dr["InfoTitle"].ToString();
                    tinfo.InfoSubMemo = dr["InfoSubMemo"].ToString();
                    tinfo.InfoMemo = dr["InfoMemo"].ToString();
                    int BrandID = 0;
                    Int32.TryParse(dr["BrandID"].ToString(), out BrandID);
                    tinfo.BrandID = BrandID;
                    tinfo.InfoPic = dr["InfoPic"].ToString().Trim();
                    int infotype = 0;
                    Int32.TryParse(dr["InfoType"].ToString(), out infotype);
                    tinfo.InfoType = infotype;
                    int ShopID = 0;
                    Int32.TryParse(dr["ShopID"].ToString(), out ShopID);
                    tinfo.ShopID = ShopID;
                    tinfo.InfoStartTime = dr["InfoStartTime"].ToString();
                    tinfo.InfoEndTime = dr["InfoEndTime"].ToString();
                    tinfo.InfoFrom = dr["InfoFrom"].ToString();
                    DateTime addtime;
                    DateTime.TryParse(dr["InfoAddTime"].ToString(), out addtime);
                    tinfo.InfoAddTime = addtime;
                    tinfo.InfoAdder = dr["InfoAdder"].ToString();
                    int InfoClicks = 0;
                    Int32.TryParse(dr["InfoClicks"].ToString(), out InfoClicks);
                    bool IsRecom = false;
                    bool.TryParse(dr["IsRecom"].ToString(), out IsRecom);
                    tinfo.IsRecom = IsRecom;
                    int SortID = 0;
                    Int32.TryParse(dr["SortID"].ToString(), out SortID);
                    tinfo.SortID = SortID;
                    bool IsHtml = false;
                    bool.TryParse(dr["IsHtml"].ToString(), out IsHtml);
                    tinfo.IsHtml = IsHtml;
                    tinfo.HtmlPath = dr["HtmlPath"].ToString();
                    bool IsRemote = false;
                    bool.TryParse(dr["IsRemote"].ToString(), out IsRemote);
                    tinfo.IsRemote = IsRemote;
                    bool IsCheck = false;
                    bool.TryParse(dr["IsCheck"].ToString(), out IsCheck);
                    tinfo.IsCheck = IsCheck;
                    int InfoCateID = 0;
                    Int32.TryParse(dr["InfoCateID"].ToString(), out InfoCateID);
                    tinfo.InfoCateID = InfoCateID;
                    tinfo.InfoETitle = dr["InfoETitle"].ToString();
                    tinfo.InfoTag = dr["InfoTag"].ToString();
                    #endregion
                }
            }
            dh.Close();
            return tinfo;
        }
        #endregion

        #region 添加信息
        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int AddInfo(TInformation info)
        {
            #region  变量
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@InfoTitle",info.InfoTitle);
            nvc.Add("@InfoSubMemo",info.InfoSubMemo);
            nvc.Add("@InfoMemo",info.InfoMemo);
            nvc.Add("@InfoPic",info.InfoPic);
            nvc.Add("@InfoType",info.InfoType.ToString());
            nvc.Add("@BrandID", info.BrandID.ToString());
            nvc.Add("@ShopID",info.ShopID.ToString());
            nvc.Add("@InfoStartTime",info.InfoStartTime);
            nvc.Add("@InfoEndTime",info.InfoEndTime);
            nvc.Add("@InfoFrom",info.InfoFrom);
            nvc.Add("@InfoAddTime",info.InfoAddTime.ToString());
            nvc.Add("@InfoAdder",info.InfoAdder);
            nvc.Add("@InfoClicks",info.InfoClicks.ToString());
            nvc.Add("@IsRecom",info.IsRecom.ToString());
            nvc.Add("@SortID",info.SortID.ToString());
            nvc.Add("@IsHtml",false.ToString());//默认没有生成html
            nvc.Add("@HtmlPath",info.HtmlPath);
            nvc.Add("@IsRemote",info.IsRemote.ToString());
            nvc.Add("@IsCheck",info.IsCheck.ToString());
            nvc.Add("@InfoCateID",info.InfoCateID.ToString());
            nvc.Add("@InfoETitle",info.InfoETitle);
            nvc.Add("@InfoTag",info.InfoTag);

           #endregion

            string cmdtxt = @"Insert into T_InfoList (InfoTitle,InfoSubMemo,InfoMemo,InfoPic,InfoType,BrandID,ShopID,InfoStartTime,InfoEndTime,InfoFrom,InfoAddTime,InfoAdder,InfoClicks,IsRecom,SortID,IsHtml,HtmlPath,IsRemote,IsCheck,InfoCateID,InfoETitle,InfoTag,IsDelete)
                            values
                            (@InfoTitle,@InfoSubMemo,@InfoMemo,@InfoPic,@InfoType,@BrandID,@ShopID,@InfoStartTime,@InfoEndTime,@InfoFrom,@InfoAddTime,@InfoAdder,@InfoClicks,@IsRecom,@SortID,@IsHtml,@HtmlPath,@IsRemote,@IsCheck,@InfoCateID,@InfoETitle,@InfoTag,0);
                           ";
            dh.Open();
            int stat = dh.ExecuteNonQuery(CommandType.Text, cmdtxt, nvc);
            dh.Close();

            return stat;
        }
        #endregion

        #region  修改信息
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateInfo(TInformation info, int id)
        {
            #region  变量
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@InfoTitle", info.InfoTitle);
            nvc.Add("@InfoSubMemo", info.InfoSubMemo);
            nvc.Add("@InfoMemo", info.InfoMemo);
            nvc.Add("@InfoPic", info.InfoPic);
            nvc.Add("@InfoType", info.InfoType.ToString());
            nvc.Add("@BrandID", info.BrandID.ToString());
            nvc.Add("@ShopID", info.ShopID.ToString());
            nvc.Add("@InfoStartTime", info.InfoStartTime);
            nvc.Add("@InfoEndTime", info.InfoEndTime);
            nvc.Add("@InfoFrom", info.InfoFrom);
            nvc.Add("@InfoAddTime", info.InfoAddTime.ToString("yyyy-MM-dd hh:mm:ss"));
            nvc.Add("@InfoAdder", info.InfoAdder);
            nvc.Add("@InfoClicks", info.InfoClicks.ToString());
            nvc.Add("@IsRecom", info.IsRecom.ToString());
            nvc.Add("@SortID", info.SortID.ToString());
            nvc.Add("@IsHtml", false.ToString());//默认没有生成html
            nvc.Add("@HtmlPath", info.HtmlPath);
            nvc.Add("@IsRemote", info.IsRemote.ToString());
            nvc.Add("@IsCheck", info.IsCheck.ToString());
            nvc.Add("@InfoCateID", info.InfoCateID.ToString());
            nvc.Add("@InfoETitle", info.InfoETitle);
            nvc.Add("@InfoTag",info.InfoTag);
            nvc.Add("@ModifyBy",info.ModifyBy.ToString());
            nvc.Add("@ModifyTime",info.ModifyTime.ToString("yyyy-MM-dd hh:mm:ss"));
            nvc.Add("@InfoID",id.ToString());
            #endregion

            string cmdtxt = @"update  T_InfoList set
                                   InfoTitle=@InfoTitle,
                                   InfoSubMemo=@InfoSubMemo,
                                   InfoMemo=@InfoMemo,
                                   InfoPic=@InfoPic,
                                   InfoType=@InfoType,
                                   BrandID=@BrandID,
                                   ShopID=@ShopID,
                                   InfoStartTime=@InfoStartTime,
                                   InfoEndTime=@InfoEndTime,
                                   InfoFrom=@InfoFrom,
                                   InfoAddTime=@InfoAddTime,
                                   InfoAdder=@InfoAdder,
                                   InfoClicks=@InfoClicks,
                                   IsRecom=@IsRecom,
                                   SortID=@SortID,  
                                   IsHtml=@IsHtml,
                                   HtmlPath=@HtmlPath,
                                   IsRemote=@IsRemote,
                                   IsCheck=@IsCheck,
                                   InfoCateID=@InfoCateID,
                                   InfoETitle=@InfoETitle,
                                   InfoTag=@InfoTag,
                                    ModifyBy=@ModifyBy,
                                    ModifyTime=@ModifyTime

                                   where InfoID=@InfoID
                           ";

            dh.Open();
            int stat = dh.ExecuteNonQuery(CommandType.Text, cmdtxt, nvc);
            dh.Close();
            return stat;
        }
        #endregion

        #region 删除信息

        public int DeleteInfo(int id)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@InfoID",id.ToString());
            string cmdtxt = "Delete from T_InfoList where InfoID=@InfoID";
            dh.Open();
            int stat = dh.ExecuteNonQuery(CommandType.Text, cmdtxt, nvc);
            dh.Close();
            return stat;
        }



        public int LogicDeleteInfo(int id,int userid)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@ModifyBy", userid.ToString());
            nvc.Add("@InfoID", id.ToString());
            string cmdtxt = "Update T_InfoList set IsDelete=1 ,ModifyBy=@ModifyBy,ModifyTime=getdate() where InfoID=@InfoID";
            dh.Open();
            int stat = dh.ExecuteNonQuery(CommandType.Text, cmdtxt, nvc);
            dh.Close();
            return stat;
        }
        #endregion

        #region 获取最近插入的信息ID
        /// <summary>
        /// 获取最近插入的信息ID
        /// </summary>
        /// <returns></returns>
        public int GetLastInfoID()
        {
            int result = 0;
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "select IDENT_CURRENT( 'T_InfoList' )", null))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    Int32.TryParse(dr[0].ToString().Trim(), out result);
                }

            }
            dh.Close();
            return result;
        }
        #endregion
        
        #region  根据指定nodeid获取信息数量
        /// <summary>
        ///根据nodeid 和条件列表，获取所有新闻，includechild为0则不包括子节点的信息，不为0时则包括所有子节点信息（影响性能） 
        /// </summary>
        /// <param name="NodeID"></param>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <param name="includechild"></param>
        /// <returns></returns>
        public int  GetInfoNumByNode(int NodeID,ArrayList FiledName, ArrayList FiledValue,int includechild)
        {
            int recordcount = 0;
            string sbCondition = string.Empty;
            sbCondition = CommOperate.SelectCondition(FiledName, FiledValue);
            string cmdtxt = string.Empty;

            if (NodeID == 0)
            {
                cmdtxt = "Select count(*) from T_InfoList where 1=1  and IsDelete=0  " + sbCondition.ToString();
            }
            else
            {
                if (includechild != 0) //包含子节点
                {
                    NodeOperate nop = new NodeOperate();
                    ArrayList childlist = nop.GetAllChildNode(NodeID);
                    string childstring = string.Empty;//子节点列表
                    for (int i = 0; i < childlist.Count; i++)
                    {
                        childstring += childlist[i].ToString() + ",";
                    }

                    childstring = childstring.Substring(0, childstring.Length - 1);//截取最后一个"," ,组成类似1,2,3形式
                    cmdtxt = "Select count(*) from T_InfoList where IsDelete=0 and  InfoCateID in(" + childstring.Trim() + ")  " + sbCondition.ToString();
                }
                else
                {
                    cmdtxt = "Select count(*) from T_InfoList where  IsDelete=0 and  InfoCateID= " + NodeID + "  " + sbCondition.ToString();
                }
            }

           // System.Web.HttpContext.Current.Response.Write(cmdtxt);
            //System.Web.HttpContext.Current.Response.End();
 
                dh.Open();
                dh.BeginTrans();
                using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, cmdtxt, null))
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
                dh.CommitTrans();
                dh.Close();
          

            return recordcount;
        }

        #endregion

        #region 根据指定nodeid获取指定信息
        public DataTable GetInfoByNode(int NodeID, ArrayList FiledName, ArrayList FiledValues, int includechild, string  OrderCondition,int startid, int endid)
        {
            string sbCondition = string.Empty;
            sbCondition = CommOperate.SelectCondition(FiledName, FiledValues);
 
            string cmdtxt = string.Empty;
            string orderbystring = string.Empty;//排序字符串
            if (OrderCondition == "")
            {
                orderbystring = " order by a.SortID desc,InfoID desc ";
            }
            else
            {
                orderbystring = " order by "+OrderCondition+ "  ";
            }
            if (NodeID == 0)
            {
                cmdtxt = "select * from (select InfoID,InfoTitle,InfoSubMemo,InfoMemo,InfoPic, InfoType,a.SortID,IsRecom,InfoCateID,InfoAdder,InfoAddTime,IsCheck,row_number() over (" + orderbystring + ") as rowno,Admin_RealName  from  T_InfoList a left join T_Admin b  on a.InfoAdder=b.Admin_ID   where   1=1 and  a.IsDelete=0    " + sbCondition + "  ) as row  where rowno between " + startid + " and " + endid.ToString() + " order by SortID desc,InfoID desc ";
            }
            else
            {
                if (includechild !=0)//包含子节点
                {
                    NodeOperate nop = new NodeOperate();
                    ArrayList childlist = nop.GetAllChildNode(NodeID);
                    string childstring = string.Empty;//子节点列表
                    for (int i = 0; i < childlist.Count; i++)
                    {
                        childstring += childlist[i].ToString() + ",";
                    }
                    childstring = childstring.Substring(0, childstring.Length - 1);
                    cmdtxt = "select * from (select InfoID,InfoTitle,InfoSubMemo,InfoMemo,InfoPic, InfoType,a.SortID,IsRecom,InfoCateID,InfoAdder,InfoAddTime,IsCheck,row_number() over (" + orderbystring + ") as rowno ,Admin_RealName from T_InfoList a left join T_Admin b  on a.InfoAdder=b.Admin_ID  where 1=1 and  a.IsDelete=0 and InfoCateID in (" + childstring + ")  " + sbCondition + "  ) as row  where rowno between " + startid + " and " + endid.ToString() + " order by SortID desc,InfoID desc ";

                }
                else
                {
                    cmdtxt = "select * from (select InfoID,InfoTitle,InfoSubMemo,InfoMemo,InfoPic, InfoType,a.SortID,IsRecom,InfoCateID,InfoAdder,InfoAddTime,IsCheck,row_number() over (" + orderbystring + ") as rowno,Admin_RealName from T_InfoList a left join T_Admin b  on a.InfoAdder=b.Admin_ID where 1=1 and a.IsDelete=0 and InfoCateID = " + NodeID.ToString() + "   " + sbCondition + "  ) as row  where rowno between " + startid + " and " + endid.ToString() + " order by SortID asc,InfoID desc ";
                }
            }
             DataTable dt;
         

            dh.Open();
            dh.BeginTrans();
            dt= dh.GetDataTable(CommandType.Text, cmdtxt, null);
            dh.CommitTrans();
            dh.Close();
    
            return dt;
        }
        #endregion


        #region 获取最新新闻
       /// <summary>
       /// 获取指定ID，指定数量的信息，按照权重，序号倒叙排列。
       /// </summary>
       /// <param name="Num">信息数量</param>
       /// <param name="NodeID">类别ID</param>
       /// <param name="IncludeChild">是否包含子节点信息</param>
       /// <param name="NewOrHot">最新或是为最热:1为最新信息，2为最热信息</param>
       /// <param name="isRecom">是否为推荐信息</param>
       /// <param name="InfoType">信息种类，为0时候不区分信息种类，1为打折资讯，2为一般信息</param>
       /// <param name="IsExpired ">是否为将要过期信息</param>
       /// <returns></returns>
        public  DataTable GetLastInfo(int Num, int NodeID, int IncludeChild,int NewOrHot, bool IsRecom,int InfoType,bool IsExpired ) 
        {
            string cmdtxt = string.Empty;
            string OrderString = string.Empty;
            cmdtxt = @"select a.InfoID,a.InfoTitle,a.InfoSubMemo,a.InfoMemo,a.InfoPic, a.InfoType,a.SortID,a.IsRecom
                      ,a.InfoCateID,a.InfoAddTime,InfoTag ,a.InfoClicks,a.IsRecom,b.NodeName 
                      ,c.ShopID,c.ShopTitle
                        from T_InfoList a inner join T_NodeList b on a.InfoCateID=b.NodeId 
                             left join T_Shop c on a.ShopID =c.ShopID
                             where 1=1 and a.IsDelete=0 ";

            DataTable NewsList = new DataTable();
            if (NodeID == 0)
            {
               
            }
            else
            {
                if (IncludeChild != 0)//包含子节点
                {
                    NodeOperate nop = new NodeOperate();
                    ArrayList childlist = nop.GetAllChildNode(NodeID);
                    string childstring = string.Empty;//子节点列表
                    for (int i = 0; i < childlist.Count; i++)
                    {
                        childstring += childlist[i].ToString() + ",";
                        childstring = childstring.Substring(0, childstring.Length - 1);
                        cmdtxt = cmdtxt + "   and InfoCateID in (" + childstring + ")    ";
                    }
                }
                else
                {
                    cmdtxt = cmdtxt + "   and InfoCateID ="+NodeID.ToString() +"  ";
                }
            }
            //最新信息
            if (NewOrHot == 1)
            {
                OrderString = "Order by a.SortID desc, a.InfoID desc";
            }
            //最热信息
            else if(NewOrHot==2)
            {
                OrderString = "Order by a.SortID desc, a.InfoClicks desc,a.InfoID desc";
            }

            if (IsRecom == true)
            {
                cmdtxt = cmdtxt + "  and a.IsRecom=1  " ;
            }

            if (InfoType == 1)
            {
                cmdtxt=cmdtxt+" and InfoType=1  ";
            }
            else if (InfoType == 2)
            {
                cmdtxt = cmdtxt + " and InfoType=2   ";
            }

            if (IsExpired == true)
            {
                cmdtxt = cmdtxt + "  and InfoEndTime is not null and rtrim(ltrim(InfoEndTime)) <> '' and  InfoEndTime < '"+DateTime.Now+"'  ";
            }

            cmdtxt = cmdtxt + "  " + OrderString;

            dh.Open();
            dh.BeginTrans();
            NewsList = dh.GetDataTable(CommandType.Text, cmdtxt, null);
            dh.CommitTrans();
            dh.Close();
            return NewsList;
        }
        #endregion

    }
}
