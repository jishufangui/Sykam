using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDAl;
using TModel;
namespace TBLL
{
  public   class ShopBLL
    {
        IShopOperate ShopOperate = null;
        public ShopBLL()
        {
            TDAl.DatabaseProvider DataProvider = null;
            DataProvider = new DatabaseProvider();
            ShopOperate = DataProvider.GetShopOperate();
        }

        #region 根据ShopID获取指定商铺
        public TShop GetShop(int id)
        {
            return ShopOperate.GetShopByID(id);
        }
        #endregion

        #region 添加商铺信息
        public int AddShop(TShop shop)
        {
            return ShopOperate.AddShop(shop);

        }
        #endregion

        #region  删除商铺信息
        public int DeleteShop(int id)
        {
            return ShopOperate.DeleteShop(id);
        }
        #endregion



        #region  获取记录数
        public int GetShopCounts(ArrayList FiledName, ArrayList FiledValue)
        {
            int counts = 0;
            counts=  ShopOperate.GetShopNumByCondition(FiledName, FiledValue);
            return counts;
        }

        #endregion

        #region  通过指定条件，获取指定区间的商家信息
        /// <summary>
        /// 获取指定条件下的商家信息
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <param name="OrderCondition"></param>
        /// <param name="startid"></param>
        /// <param name="endid"></param>
        /// <returns></returns>
        public DataTable GetNodeByCondition(ArrayList FiledName, ArrayList FiledValue, string OrderCondition, int startid, int endid)
        {
            DataTable dt = ShopOperate.GetShopByCondition(FiledName, FiledValue, OrderCondition, startid, endid);
            return dt;
        }
        #endregion

        #region 返回最新添加的shopid
        public int GetLastShopID()
        {
            return ShopOperate.GetLastShopID();
        }
        #endregion

        public int UpdateShop(TShop sp, int id)
        {
            return ShopOperate.UpdateShop(id, sp);
        }

        public string  GetShopJson(string keyword)
        {  
            return ShopOperate.GetShopJsonByKeyWord(keyword.Trim());
        }


        #region  检测标题是否重复
        public bool CheckTitle(string Keyword)
        {
            return ShopOperate.CheckTitle(Keyword);
        }
        #endregion
    }
}
