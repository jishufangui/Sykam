using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TModel;
namespace TDAl
{
    public interface IBrandOperate
    {

        /// <summary>
        /// 获取所有品牌
        /// </summary>
        /// <returns></returns>
        DataTable GetAllBrand();

        /// <summary>
        /// 根据id获取品牌信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TBrand GetBrandByID(int id);

        /// <summary>
        /// 添加品牌
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        int AddBrand(TBrand brand);

        /// <summary>
        ///根据id更新品牌
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateBrand(TBrand brand, int id);

        /// <summary>
        /// 删除品牌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteBrand(int id);

        /// <summary>
        /// 根据条件获取品牌数量
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <returns></returns>
        int GetBrandNumByCondition(ArrayList FiledName, ArrayList FiledValue);

        /// <summary>
        /// 根据条件获取品牌的datatable
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <param name="OrderCondition"></param>
        /// <param name="startid"></param>
        /// <param name="endid"></param>
        /// <returns></returns>
        DataTable GetBrandByCondition(ArrayList FiledName, ArrayList FiledValue, string OrderCondition, int startid, int endid);

        /// <summary>
        /// 获取最近插入的品牌ID
        /// </summary>
        /// <returns></returns>
        int GetLastBrandID();

        /// <summary>
        /// 根据关键字获取品牌json
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        string GetBrandJsonByKeyWord(string keyword);
        
        
        /// <summary>
        /// 检查品牌名称是否重复
        /// </summary>
        /// <param name="Title"></param>
        /// <returns></returns>
        bool CheckTitle(string Title);

    }
}
