using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TModel;
namespace TDAl
{
   public  interface IInfoOperate
    {
        /// <summary>
        /// 获取指定ID的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TInformation GetInfo(int id);

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int AddInfo(TInformation info);

        /// <summary>
        /// 修改指定ID信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateInfo(TInformation info, int id);

        /// <summary>
        /// 删除指定ID信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteInfo(int id);

        /// <summary>
        /// 逻辑删
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int LogicDeleteInfo(int id,int userid);

        /// <summary>
        /// 获取最近插入的信息ID
        /// </summary>
        /// <returns></returns>
        int GetLastInfoID();

    
        /// <summary>
        /// 根据指定nodeid获取信息数量
        /// </summary>
        /// <param name="NodeID"></param>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <param name="includechild"></param>
        /// <returns></returns>
        int GetInfoNumByNode(int NodeID,ArrayList FiledName, ArrayList FiledValue,int includechild);

        /// <summary>
        /// 根据指定nodeid获取指定信息
        /// </summary>
        /// <param name="NodeID">指定节点</param>
        /// <param name="FiledName"></param>
        /// <param name="FiledValues"></param>
        /// <param name="includechild"></param>
        /// <param name="OrderCondition">排序方式</param>
        /// <param name="startid">起始id</param>
        /// <param name="endid">结束id</param>
        /// <returns></returns>
        DataTable GetInfoByNode(int NodeID, ArrayList FiledName, ArrayList FiledValues, int includechild, string  OrderCondition,int startid, int endid);

        
       /// <summary>
       /// 根据指定的ID，和数量获取最新的新闻
       /// </summary>
       /// <param name="Num">取多少条新闻</param>
       /// <param name="CateID">指定类别</param>
       /// <param name="CateID">是否包含子类别</param>
       /// <param name="CateID">最新信息还是最热信息</param>
       /// <returns></returns>
        //DataTable GetLastInfo(int Num, int CateID, int IncludeChild,int NewOrHot);
 
    }
}
