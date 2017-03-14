using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using TDAl;
using TModel;
namespace TBLL
{
    public class BrandBLL
    {
        IBrandOperate BrandOperate = null;
        public BrandBLL()
        {
            TDAl.DatabaseProvider DataProvider = null;
            DataProvider = new DatabaseProvider();
            BrandOperate = DataProvider.GetBrandOperate();
        }

        #region  根据品牌ID获取品牌
        /// <summary>
        /// 根据品牌ID获取品牌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TBrand GetBrandByID(int id)
        {
            return BrandOperate.GetBrandByID(id);
        }
        #endregion


        #region 插入品牌
        /// <summary>
        /// 插入品牌
        /// </summary>
        /// <param name="tbrand"></param>
        /// <returns></returns>
        public int AddBrand(TBrand tbrand)
        {
            return BrandOperate.AddBrand(tbrand);
        }
        #endregion

        #region 更新品牌
        /// <summary>
        /// 更新品牌
        /// </summary>
        /// <param name="tbrand"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateBrand(TBrand tbrand, int id)
        {
            return BrandOperate.UpdateBrand(tbrand, id);
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
            return BrandOperate.DeleteBrand(id);
        }
        #endregion

        #region 获取指定条件下品牌数量
        /// <summary>
        /// 获取指定条件下品牌数量
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="FieldValue"></param>
        /// <returns></returns>
        public int GetBrandNum(ArrayList FieldName, ArrayList FieldValue)
        {
            return BrandOperate.GetBrandNumByCondition(FieldName, FieldValue);
        }
        #endregion

        #region 获取指定条件下的品牌
        /// <summary>
        /// 获取指定条件下的品牌
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <param name="OrderCondition"></param>
        /// <param name="startid"></param>
        /// <param name="endid"></param>
        /// <returns></returns>
        public DataTable GetBrand(ArrayList FiledName, ArrayList FiledValue, string OrderCondition, int startid, int endid)
        {
            return BrandOperate.GetBrandByCondition(FiledName, FiledValue, OrderCondition, startid, endid);
        }
        #endregion

        #region  获取最新插入ID
        /// <summary>
        /// 获取最新插入ID
        /// </summary>
        /// <returns></returns>
        public int GetLastID()
        {  
            return BrandOperate.GetLastBrandID();
        }

        #endregion

        #region  品牌的json字符串
         
        /// <summary>
        /// 获取品牌的json
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public string GetBrandJson(string keyword)
        {
            return BrandOperate.GetBrandJsonByKeyWord(keyword);
        }
        #endregion

        #region  检查标题是否重复
        public bool CheckTitle(string Keyword)
        {
            return BrandOperate.CheckTitle(Keyword);
        }
        #endregion
    }
}
