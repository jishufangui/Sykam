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
    public  class InfoBLL
    {
        IInfoOperate InfoOperate = null;
        public InfoBLL()
        {
            TDAl.DatabaseProvider DataProvider = null;
            DataProvider = new DatabaseProvider();
            InfoOperate = DataProvider.GetInfoOperate();
        }
        
        #region  根据信息ID获取信息
        /// <summary>
        /// 根据信息ID获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TInformation GetInfo(int id)
        {
            return InfoOperate.GetInfo(id);
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
            return   InfoOperate.AddInfo(info);
        }
        #endregion

        #region 修改信息
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateInfo(TInformation info, int id)
        {
             return InfoOperate.UpdateInfo(info, id);
        }
        #endregion


        #region 删除信息
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteInfo(int id,int userid)
        {
            return InfoOperate.LogicDeleteInfo(id,userid);
        }
        #endregion


        #region  通过NodeID获取记录数，并选择是否包括子类别新闻
        public int GetInfoCountsByNode(int NodeID,ArrayList FiledName, ArrayList FiledValue,int includechild)
        {
            int counts = 0;
            counts = InfoOperate.GetInfoNumByNode(NodeID, FiledName, FiledValue, includechild);
            return counts;
        }

        #endregion

        #region  获取指定区间的新闻
        public DataTable GetInfoByNode(int NodeID, ArrayList filedName, ArrayList FiledValue, int incluedchild,int startid, int endid)
        {
            return InfoOperate.GetInfoByNode(NodeID, filedName, FiledValue, incluedchild, "", startid, endid);
        }
        #endregion

        #region 获取最新插入id
        public int GetLastID()
        {
            return InfoOperate.GetLastInfoID();
        }
        #endregion

        #region 获取最新新闻
        public List<TInformation>  GetLastNews()
        {
            List<TInformation> Newslist = new List<TInformation>();

            return Newslist;
        }
        #endregion


    }
}
