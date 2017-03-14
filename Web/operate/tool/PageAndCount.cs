using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Web.operate.tool
{
    public class PageAndCount
    {

        #region 获取当前页数

        /// <summary>
        /// 获取当前页数
        /// </summary>
        /// <param name="recordCount"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static int GetCurrent(int recordCount,int pageSize)
        {

           int currentPage=0;
           int pageCount;
           Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("page"), out currentPage);
           if (currentPage == 0)
               currentPage = 1;
           if (recordCount > 0)
           {
               if ((recordCount % pageSize) == 0)
                   pageCount = recordCount / pageSize;
               else
                   pageCount = (int)Math.Ceiling((decimal)(recordCount / pageSize)) + 1;
           }
           else
               pageCount = 1;

           if (pageCount == 0)
               pageCount = 1;

           if (pageCount < currentPage)
               currentPage = pageCount;

           if (currentPage < 1)
               currentPage = 1;

           return currentPage;
        }

        #endregion


        #region 获取记录开始数
        /// <summary>
        /// 获取记录开始数
        /// </summary>
        /// <param name="currentPage">当前页</param>
        /// <param name="pageSize">每页容量</param>
        /// <returns></returns>
        public static int StartID(int currentPage,int pageSize)
        {
            int i = 0;
            if (currentPage > 1)
                i = (currentPage - 1) * pageSize;
            int startid = (currentPage - 1) * pageSize + 1;

            return startid;
        }
        #endregion

        #region 获取结束记录数
        /// <summary>
        /// 获取结束记录数
        /// </summary>
        /// <param name="currentPage">当前页</param>
        /// <param name="pageSize">每页容量</param>
        /// <returns></returns>
        public static int EndID(int currentPage, int pageSize)
        {
            int endid = 0;
            endid = (currentPage) * pageSize;
            return endid; 
        }
        #endregion
    }
}