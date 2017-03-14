using System;
using System.Web;
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
    public  class ShopOperate:IShopOperate
    {
        #region 变量
        private string SelectShop = "Select ShopID,ShopTitle,ShopETitle,ShopPic,ShopMemo,ShopProvince,ShopCity,ShopArea,ShopLongitude,ShopLatitude,ShopRoute,ShopOpenTime,ShopTemplate,ShopAddtime,ShopAdder,SortID,IsRecom,IsHtml,HtmlPath,IsRemote from T_Shop where 1=1";
        private string OrderCondition1 = " order by SortID asc,ShopID desc";//排序条件
        private static string _connection = string.Empty;
        DataHelper.DbHelper dh;
        #endregion
        public ShopOperate()
        {
            _connection = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"].ToString();
            dh = new SqlHelper(_connection);
        }

        #region 获取所有商家
        /// <summary>
        ///  获取所有商家
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllShop()
        {
            dh.Open();
            DataTable dt = dh.GetDataTable(CommandType.Text, SelectShop + OrderCondition1, null);
            dh.Close();
            return dt;
        }
        #endregion

        #region 根据shopid获取商家
        /// <summary>
        /// 根据shopid获取商家
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TShop GetShopByID(int id)
        {
            NameValueCollection nvc = new NameValueCollection();
            TShop ts = new TShop();
            nvc.Add("@ShopID",id.ToString());
            dh.Open();

            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, SelectShop + " and ShopID=@ShopID", nvc))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                  
                    ts.ShopID = id;
                    ts.ShopTitle = dr["ShopTitle"].ToString();
                    ts.ShopETitle = dr["ShopETitle"].ToString();
                    ts.ShopPic = dr["ShopPic"].ToString();
                    ts.ShopMemo = dr["ShopMemo"].ToString();
                    ts.ShopProvince = dr["ShopProvince"].ToString();
                    ts.ShopCity = dr["ShopCity"].ToString();
                    ts.ShopArea = dr["ShopArea"].ToString();
                    ts.ShopLongitude = dr["ShopLongitude"].ToString();
                    ts.ShopLatitude = dr["ShopLatitude"].ToString();
                    ts.ShopRoute = dr["ShopRoute"].ToString();
                    ts.ShopOpenTime = dr["ShopOpenTime"].ToString();
                    ts.ShopTemplate = dr["ShopTemplate"].ToString();
                    DateTime Addtime;
                    DateTime.TryParse(dr["ShopAddtime"].ToString(), out Addtime);
                    ts.ShopAddtime = Addtime;
                    ts.ShopAdder = dr["ShopAdder"].ToString();
                    int SortID = 0;
                    Int32.TryParse(dr["SortID"].ToString(), out SortID);
                    ts.SortID = SortID;
                    bool IsRecom;
                    bool.TryParse(dr["IsRecom"].ToString(), out IsRecom);
                    ts.IsRecom = IsRecom;
                    bool IsHtml;
                    bool.TryParse(dr["IsHtml"].ToString(), out IsHtml);
                    ts.IsHtml = IsHtml;
                    ts.HtmlPath = dr["HtmlPath"].ToString();
                    bool IsRemote;
                    bool.TryParse(dr["IsRemote"].ToString(), out IsRemote);
                    ts.IsRemote = IsRemote;

                }
            }
            dh.Close();

            return ts;
        }
        #endregion

        #region 插入商家信息
        /// <summary>
        /// 插入商家信息
        /// </summary>
        /// <param name="Shop"></param>
        /// <returns></returns>
        public int AddShop(TShop Shop)
        {
            int stat = 0;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@ShopTitle", Shop.ShopTitle);
            nvc.Add("@ShopETitle", Shop.ShopETitle);
            nvc.Add("@ShopPic", Shop.ShopPic);
            nvc.Add("@ShopMemo", Shop.ShopMemo);
            nvc.Add("@ShopProvince", Shop.ShopProvince);
            nvc.Add("@ShopCity", Shop.ShopCity);
            nvc.Add("@ShopArea", Shop.ShopArea);
            nvc.Add("@ShopLongitude", Shop.ShopLongitude);
            nvc.Add("@ShopLatitude", Shop.ShopLatitude);
            nvc.Add("@ShopRoute", Shop.ShopRoute);
            nvc.Add("@ShopOpenTime", Shop.ShopOpenTime);
            nvc.Add("@ShopTemplate", Shop.ShopTemplate);
            nvc.Add("@ShopAddtime", Shop.ShopAddtime.ToString());
            nvc.Add("@ShopAdder", Shop.ShopAdder);
            nvc.Add("@SortID", Shop.SortID.ToString());
            nvc.Add("@IsRecom", Shop.IsRecom.ToString());
            nvc.Add("@IsHtml", Shop.IsHtml.ToString());
            nvc.Add("@HtmlPath", Shop.HtmlPath);
            nvc.Add("@IsRemote",Shop.IsRemote.ToString());
            dh.Open();
            stat = dh.ExecuteNonQuery(CommandType.Text, "Insert into T_Shop(ShopTitle,ShopETitle,ShopPic,ShopMemo,ShopProvince,ShopCity,ShopArea,ShopLongitude,ShopLatitude,ShopRoute,ShopOpenTime,ShopTemplate,ShopAddtime,ShopAdder,SortID,IsRecom,IsHtml,HtmlPath,IsRemote) values(@ShopTitle,@ShopETitle,@ShopPic,@ShopMemo,@ShopProvince,@ShopCity,@ShopArea,@ShopLongitude,@ShopLatitude,@ShopRoute,@ShopOpenTime,@ShopTemplate,@ShopAddtime,@ShopAdder,@SortID,@IsRecom,@IsHtml,@HtmlPath,@IsRemote)", nvc);
            dh.Close();
            return stat;
        }

        #endregion

        #region 更新商家信息
        /// <summary>
        /// 更新商家信息
        /// </summary>
        /// <param name="ShopID"></param>
        /// <param name="Shop"></param>
        /// <returns></returns>
        public  int UpdateShop(int ShopID, TShop Shop)
        {
            int stat = 0;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@ShopTitle",Shop.ShopTitle);
            nvc.Add("@ShopETitle",Shop.ShopETitle);
            nvc.Add("@ShopPic",Shop.ShopPic);
            nvc.Add("@ShopMemo",Shop.ShopMemo);
            nvc.Add("@ShopProvince",Shop.ShopProvince);
            nvc.Add("@ShopCity",Shop.ShopCity);
            nvc.Add("@ShopArea",Shop.ShopArea);
            nvc.Add("@ShopLongitude",Shop.ShopLongitude);
            nvc.Add("@ShopLatitude",Shop.ShopLatitude);
            nvc.Add("@ShopRoute",Shop.ShopRoute);
            nvc.Add("@ShopOpenTime",Shop.ShopOpenTime);
            nvc.Add("@ShopTemplate",Shop.ShopTemplate);
            nvc.Add("@ShopAddtime",Shop.ShopAddtime.ToString());
            nvc.Add("@ShopAdder",Shop.ShopAdder);
            nvc.Add("@SortID",Shop.SortID.ToString());
            nvc.Add("@IsRecom",Shop.IsRecom.ToString());
            nvc.Add("@IsHtml",Shop.IsHtml.ToString());
            nvc.Add("@HtmlPath",Shop.HtmlPath);
            nvc.Add("@ShopID",ShopID.ToString());
            nvc.Add("@IsRemote",Shop.IsRemote.ToString());
            dh.Open();
            stat = dh.ExecuteNonQuery(CommandType.Text, "Update T_Shop set ShopTitle=@ShopTitle,ShopETitle=@ShopETitle,ShopPic=@ShopPic,ShopMemo=@ShopMemo,ShopProvince=@ShopProvince,ShopCity=@ShopCity,ShopArea=@ShopArea,ShopLongitude=@ShopLongitude,ShopLatitude=@ShopLatitude,ShopRoute=@ShopRoute,ShopOpenTime=@ShopOpenTime,ShopTemplate=@ShopTemplate,ShopAddtime=@ShopAddtime,ShopAdder=@ShopAdder,SortID=@SortID,IsRecom=@IsRecom,IsHtml=@IsHtml,HtmlPath=@HtmlPath,IsRemote=@IsRemote where ShopID=@ShopID ", nvc);
            dh.Close();
            return stat;
        }
        #endregion

        #region 删除商家信息
        public int DeleteShop(int ShopID)
        {
            int stat = 0;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@ShopID",ShopID.ToString());
            dh.Open();
            stat = dh.ExecuteNonQuery(CommandType.Text, "Delete from T_Shop where ShopID=@ShopID", nvc);
            dh.Close();
            return stat;
        }
        #endregion

        #region 根据指定条件获取商家数量
        public int GetShopNumByCondition(ArrayList FiledName, ArrayList FiledValue)
        {
            int recordcount = 0;
            string sbCondition = string.Empty;
            sbCondition = CommOperate.SelectCondition(FiledName, FiledValue);
            string seltxt = "Select count(*) from T_Shop where 1=1 " + sbCondition;
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

        #region 通过指定条件，获取指定区间的datatalbe
        public DataTable GetShopByCondition(ArrayList FiledName, ArrayList FiledValue, string OrderCondition, int startid, int endid)
        {
            string sbCondition = string.Empty;
            //sbCondition = SelectCondition(FiledName, FiledValue);
            sbCondition = CommonLibrary.CommOperate.SelectCondition(FiledName, FiledValue);
            //string cmdtxt = "select * from (select ShopID,ShopTitle,ShopETitle,ShopPic,ShopProvince,ShopCity,ShopArea,ShopAddtime,ShopAdder,SortID,IsRecom ,row_number() over ( order by " + OrderCondition + ") as rowno from T_Shop  where 1=1 and " + sbCondition + "  ) as row  where rowno between " + startid + " and " + endid.ToString() + " order by " + OrderCondition;
            string seltext = string.Empty;
            if (OrderCondition.ToString().Trim() == "")
            {
                seltext = "select * from (select ShopID,ShopTitle,ShopETitle,ShopPic,ShopProvince,ShopCity,ShopArea,ShopAddtime,ShopAdder,a.SortID,IsRecom ,row_number() over (order by a.sortid asc,ShopID desc) as rowno,Admin_RealName from T_Shop a left join T_Admin b  on a.ShopAdder=b.Admin_ID  where 1=1  " + sbCondition + "  ) as row  where rowno between " + startid + " and " + endid.ToString() + " order by " + OrderCondition1;
            }
            else
            {
                seltext = "select * from (select ShopID,ShopTitle,ShopETitle,ShopPic,ShopProvince,ShopCity,ShopArea,ShopAddtime,ShopAdder,a.SortID,IsRecom ,row_number() over ( order by a.sortid asc,ShopID desc) as rowno,Admin_RealName from  T_Shop a  left join  T_Admin b  on a.ShopAdder=b.Admin_ID   where 1=1  " + sbCondition + "  ) as row  where rowno between " + startid + " and " + endid.ToString() + " order by " + OrderCondition;
            }


            DataTable dt;
            Object thisLock = new Object();
            lock(thisLock)
            {
            dh.Open();
            dt = dh.GetDataTable(CommandType.Text, seltext, null);
            dh.Close();
            }
            return dt;
        }
        #endregion

     

        /// <summary>
        /// 获取最近插入的 SHopID
        /// </summary>
        /// <returns></returns>
        public int GetLastShopID()
        {

            int result = 0;
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "select IDENT_CURRENT( 'T_Shop' )", null))
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


        #region  获取指定商铺的json字符串
        /// <summary>
        /// 获取指定商铺的json字符串
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public string GetShopJsonByKeyWord(string keyword)
        {   
            NameValueCollection nvc=new NameValueCollection();
            nvc.Add("@keyword","%"+keyword.Trim()+"%");
            StringBuilder sb = new StringBuilder();
            dh.Open();
            DataTable dt = dh.GetDataTable(CommandType.Text, "Select top 100 ShopID from T_Shop where ShopTitle like @keyword or ShopETitle like @keyword order by SortID asc,ShopID desc", nvc);
            dh.Close();
            List<TModel.json.J_shop> T_list = new List<TModel.json.J_shop>();
            TModel.json.J_shop jshopnull = new TModel.json.J_shop();
            jshopnull.ShopID = "-1";
            jshopnull.ShopTitle = "暂无商家";
            T_list.Add(jshopnull);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = 0;
                Int32.TryParse(dt.Rows[i]["ShopID"].ToString().Trim(), out id);
                TShop shop= GetShopByID(id);
                TModel.json.J_shop jshop = new TModel.json.J_shop();
                jshop.ShopID = shop.ShopID.ToString();
                jshop.ShopTitle = shop.ShopTitle;
                T_list.Add(jshop);

            }
            dt.Dispose();

            return CommonLibrary.CommOperate.ToJson(T_list);

        }

        #endregion

        #region 检查标题是否重复
        public bool CheckTitle(string Title)
        {
            bool HasTitle = false;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@keyword", "" + Title.Trim() + "");
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "Select * from T_Shop where ShopTitle =  @keyword", nvc))
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
