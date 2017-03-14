using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DataHelper;
using CommonLibrary;
using TModel;
namespace TDAl.sqlserver
{
    public class BrandOperate:IBrandOperate
    {  
            #region 变量
            private string SelectBrand = "Select BrandID,BrandName,IsRecom,BrandMemo,BrandPic,BrandTemplate,IsHtml,BrandHtmlPath,IsRemote,BrandAddtime,BrandAdder,SortID from T_Brand where 1=1";
            private string OrderCondition1 = " order by SortID asc,BrandID desc";//排序条件
                private static string _connection = string.Empty;
                DataHelper.DbHelper dh;
            #endregion

            public BrandOperate()
            {
                _connection = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"].ToString();
                dh = new SqlHelper(_connection);
            }
      
            #region 获取所有品牌
            /// <summary>
            ///  获取所有品牌
            /// </summary>
            /// <returns></returns>
            public DataTable GetAllBrand()
            {
                dh.Open();
                DataTable dt = dh.GetDataTable(CommandType.Text, SelectBrand+OrderCondition1, null);
                dh.Close();
                return dt;
            }
            #endregion

            #region 根据ID获取品牌
            public TBrand GetBrandByID(int id)
            {
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("@BrandID",id.ToString());
                TBrand tb = new TBrand();
                dh.Open();
                using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, SelectBrand + " and BrandID=@BrandID", nvc))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        tb.BrandID = id;
                        tb.BrandName = dr["BrandName"].ToString();
                        bool IsRecom;
                        bool.TryParse(dr["IsRecom"].ToString(), out IsRecom);
                        tb.IsRecom = IsRecom;
                        tb.BrandMemo = dr["BrandMemo"].ToString().Trim();
                        tb.BrandPic = dr["BrandPic"].ToString().Trim();
                        tb.BrandTemplate = dr["BrandTemplate"].ToString().Trim();
                        bool IsHtml;
                        bool.TryParse(dr["IsHtml"].ToString(), out IsHtml);
                        tb.IsHtml = IsHtml;
                        tb.BrandHtmlPath = dr["BrandHtmlPath"].ToString().Trim();
                        bool IsRemote;
                        bool.TryParse(dr["IsRemote"].ToString(), out IsRemote);
                        tb.IsRemote = IsRemote;
                        DateTime BrandAddtime;
                        DateTime.TryParse(dr["BrandAddtime"].ToString(), out BrandAddtime);
                        tb.BrandAddtime = BrandAddtime;
                        int BrandAdder = 0;
                        Int32.TryParse(dr["BrandAdder"].ToString(), out BrandAdder);
                        tb.BrandAdder = BrandAdder;
                        int SortID = 0;
                        Int32.TryParse(dr["SortID"].ToString(), out SortID);
                        tb.SortID = SortID;
                    }
                }
                dh.Close();


                return tb;
            }

            #endregion


            #region 添加品牌
        /// <summary>
        /// 添加品牌
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
            public int AddBrand(TBrand brand)
            {
                int stat = 0;
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("@BrandName",brand.BrandName);
                nvc.Add("@IsRecom",brand.IsRecom.ToString());
                nvc.Add("@BrandMemo",brand.BrandMemo);
                nvc.Add("@BrandPic",brand.BrandPic);
                nvc.Add("@BrandTemplate",brand.BrandTemplate);
                nvc.Add("@IsHtml",brand.IsHtml.ToString());
                nvc.Add("@BrandHtmlPath",brand.BrandHtmlPath);
                nvc.Add("@IsRemote",brand.IsRemote.ToString());
                nvc.Add("@BrandAddtime",brand.BrandAddtime.ToString());
                nvc.Add("@BrandAdder",brand.BrandAdder.ToString());
                nvc.Add("@SortID",brand.SortID.ToString());
                dh.Open();
                stat = dh.ExecuteNonQuery(CommandType.Text, "Insert into T_Brand(BrandName,IsRecom,BrandMemo,BrandPic,BrandTemplate,IsHtml,BrandHtmlPath,IsRemote,BrandAddtime,BrandAdder,SortID) values(@BrandName,@IsRecom,@BrandMemo,@BrandPic,@BrandTemplate,@IsHtml,@BrandHtmlPath,@IsRemote,@BrandAddtime,@BrandAdder,@SortID)", nvc);
                dh.Close();
                return stat;
            }
            #endregion

        #region 修改品牌
            /// <summary>
            /// 修改品牌
            /// </summary>
            /// <param name="brand"></param>
            /// <param name="id"></param>
            /// <returns></returns>
            public int UpdateBrand(TBrand brand, int id)
            {
                int stat = 0;
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("@BrandName", brand.BrandName);
                nvc.Add("@IsRecom", brand.IsRecom.ToString());
                nvc.Add("@BrandMemo", brand.BrandMemo);
                nvc.Add("@BrandPic", brand.BrandPic);
                nvc.Add("@BrandTemplate", brand.BrandTemplate);
                nvc.Add("@IsHtml", brand.IsHtml.ToString());
                nvc.Add("@BrandHtmlPath", brand.BrandHtmlPath);
                nvc.Add("@IsRemote", brand.IsRemote.ToString());
                nvc.Add("@BrandAddtime", brand.BrandAddtime.ToString());
                nvc.Add("@BrandAdder", brand.BrandAdder.ToString());
                nvc.Add("@SortID", brand.SortID.ToString());
                nvc.Add("@BrandID",id.ToString());
                dh.Open();
                stat = dh.ExecuteNonQuery(CommandType.Text, "Update T_Brand set BrandName=@BrandName,IsRecom=@IsRecom,BrandMemo=@BrandMemo,BrandPic=@BrandPic,BrandTemplate=@BrandTemplate,IsHtml=@IsHtml,BrandHtmlPath=@BrandHtmlPath,IsRemote=@IsRemote,BrandAddtime=@BrandAddtime,BrandAdder=@BrandAdder,SortID=@SortID where BrandID=@BrandID", nvc);
                dh.Close();
                return stat;
            }

        #endregion


        #region 删除品牌
           /// <summary>
           /// 删除品牌
           /// </summary>
           /// <param name="id"></param>
           /// <returns></returns>
            public int DeleteBrand(int id)
            {
                int stat = 0;
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("@BrandID", id.ToString());
                dh.Open();
                stat = dh.ExecuteNonQuery(CommandType.Text, "Delete from T_Brand where BrandID=@BrandID", nvc);
                dh.Close();
                return stat;
            }
       
        #endregion

        #region 获取指定条件下品牌数量
        /// <summary>
        /// 获取指定条件下品牌数量
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <returns></returns>
            public int GetBrandNumByCondition(ArrayList FiledName, ArrayList FiledValue)
            {
                int recordcount = 0;
                string sbCondition = string.Empty;
                sbCondition = CommonLibrary.CommOperate.SelectCondition(FiledName, FiledValue);
                string seltxt = "Select count(*) from T_Brand  where 1=1 " + sbCondition;
                Object thisLock = new Object();
                lock (thisLock)
                {
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
                }
                return recordcount;
            }

            #endregion

        #region  获取指定条件下的品牌
            public DataTable GetBrandByCondition(ArrayList FiledName, ArrayList FiledValue, string OrderCondition, int startid, int endid)
            {
                string sbCondition = string.Empty;
                sbCondition = CommonLibrary.CommOperate.SelectCondition(FiledName, FiledValue);
                string seltext = string.Empty;
                if (OrderCondition.ToString().Trim() == "")
                {
                    seltext = "select * from (select BrandID,BrandName,IsRecom,BrandAddtime,a.SortID,BrandAdder ,row_number() over (order by a.SortID asc,BrandID desc) as rowno,Admin_RealName from T_Brand a left join T_Admin b  on a.BrandAdder=b.Admin_ID  where 1=1  " + sbCondition + "  ) as row  where rowno between " + startid + " and " + endid.ToString() + " order by " + OrderCondition1;
                }
                else
                {
                    seltext = "select * from (select BrandID,BrandName,IsRecom,BrandAddtime,a.SortID,BrandAdder ,row_number() over (order by a.SortID asc,BrandID desc) as rowno,Admin_RealName from T_Brand a left join  T_Admin b on a.BrandAdder=b.Admin_ID   where 1=1  " + sbCondition + "  ) as row  where rowno between " + startid + " and " + endid.ToString() + " order by " + OrderCondition;
                }
                DataTable dt;
                Object thisLock = new Object();
                lock (thisLock)
                {
                    dh.Open();
                    dt = dh.GetDataTable(CommandType.Text, seltext, null);
                    dh.Close();
                }
                return dt;

            }
        #endregion

        #region 获取最近的品牌ID
            /// <summary>
            /// 获取最近的品牌ID
            /// </summary>
            /// <returns></returns>
            public int GetLastBrandID()
            {
                int result = 0;
                dh.Open();
                using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "select IDENT_CURRENT( 'T_Brand' )", null))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        Int32.TryParse(dr[0].ToString().Trim(), out result);
                    }

                }
                return result;
            }
            #endregion

        #region 根据关键字 获取指定品牌的json
            public string GetBrandJsonByKeyWord(string keyword)
            {
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("@keyword", "%" + keyword.Trim() + "%");
                StringBuilder sb = new StringBuilder();
                dh.Open();
                DataTable dt = dh.GetDataTable(CommandType.Text, "Select top 100 BrandID from T_Brand where BrandName like @keyword  order by SortID asc,BrandID desc", nvc);
                dh.Close();
                List<TModel.json.J_brand> T_list = new List<TModel.json.J_brand>();
                TModel.json.J_brand T_List_null = new TModel.json.J_brand();
                T_List_null.BrandID = "-1";
                T_List_null.BrandName = "暂无品牌信息";
                T_list.Add(T_List_null);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int id = 0;
                    Int32.TryParse(dt.Rows[i]["BrandID"].ToString().Trim(), out id);
                    TBrand tbrand = GetBrandByID(id);
                    TModel.json.J_brand jbrand = new TModel.json.J_brand();
                    jbrand.BrandID = tbrand.BrandID.ToString();
                    jbrand.BrandName = tbrand.BrandName;
                    T_list.Add(jbrand);
                }
                dt.Dispose();

                return CommonLibrary.CommOperate.ToJson(T_list);

  
            }

        #endregion

        #region  判断品牌名否重复
        /// <summary>
            /// 判断品牌名否重复，有重复则返回为true，无重复则为false
        /// </summary>
        /// <param name="Title"></param>
        /// <returns></returns>
            public bool CheckTitle(string Title)
            {
                bool HasTitle = false;
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("@keyword", "" + Title.Trim() + "");
                dh.Open();
                using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "Select * from T_Brand where BrandName =  @keyword", nvc))
                {
                    if (dr.HasRows)
                    {
                        HasTitle = true;
                    }
                    else
                    {
                        HasTitle = false;
                    }
                }
                dh.Close();

                return HasTitle;
            }
        #endregion
    }
}
