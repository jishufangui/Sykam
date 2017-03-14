using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TModel;
namespace TDAl
{
    public  interface IShopOperate
    {   
        /// <summary>
        /// 获取所有商家
        /// </summary>
        /// <returns></returns>
        DataTable GetAllShop();

        /// <summary>
        /// 通过ID获取商家
        /// </summary>
        /// <returns></returns>
        TShop GetShopByID(int id);
        
        /// <summary>
        /// 添加商家
        /// </summary>
        /// <returns></returns>
        int AddShop(TShop Shop);

        /// <summary>
        /// 修改商家
        /// </summary>
        /// <param name="ShopID"></param>
        /// <param name="Shop"></param>
        /// <returns></returns>
        int UpdateShop(int ShopID, TShop Shop);

        /// <summary>
        /// 删除商家
        /// </summary>
        /// <param name="ShopID"></param>
        /// <returns></returns>
        int DeleteShop(int ShopID);

        /// <summary>
        /// 根据指定条件获取商家数量
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <returns></returns>
        int GetShopNumByCondition(ArrayList FiledName, ArrayList FiledValue);

        /// <summary>
        /// 通过指定条件，获取指定区间的datatalbe
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <param name="OrderCondition"></param>
        /// <param name="startid"></param>
        /// <param name="endid"></param>
        /// <returns></returns>
        DataTable GetShopByCondition(ArrayList FiledName, ArrayList FiledValue, string OrderCondition, int startid, int endid);

        /// <summary>
        /// 获取最近插入ShopID
        /// </summary>
        /// <returns></returns>
        int GetLastShopID();
        
        /// <summary>
        /// 通过关键字获取指定商铺的json
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        string GetShopJsonByKeyWord(string keyword);

        /// <summary>
        /// 检查标题是否重复
        /// </summary>
        /// <param name="Title"></param>
        /// <returns></returns>
        bool CheckTitle(string Title);



    }
}
