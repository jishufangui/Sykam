using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Collections.Specialized;

namespace DataHelper
{
    public abstract class DbHelper
    {
        /// <summary>
        /// 得到数据库链接
        /// </summary>
        public abstract IDbConnection Connection { get; }
        /// <summary>
        /// 打开数据库连接;  
        /// </summary>
        public abstract void Open();
        /// <summary>
        /// 关闭数据库链接;
        /// </summary>
        public abstract void Close();
        /// <summary>
        /// 开始一个事务;
        /// </summary>
        public abstract void BeginTrans();
        /// <summary>
        /// 提交一个事务;
        /// </summary>
        public abstract void CommitTrans();
        /// <summary>
        /// 回滚一个事务;
        /// </summary>
        public abstract void RollBackTrans();
        /// <summary>
        /// 执行sql语句,返回受影响集合数
        /// </summary>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令字符串</param>
        /// <param name="commandParameters">命令参数</param>
        /// <returns></returns>
        public abstract int ExecuteNonQuery(CommandType cmdType, string cmdText, NameValueCollection pars);
        /// <summary>
        /// 执行sql语句,返回IDataReader
        /// </summary>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令字符串</param>
        /// <param name="commandParameters">命令参数</param>
        /// <returns></returns>
        public abstract DbDataReader ExecuteReader(CommandType cmdType, string cmdText, NameValueCollection pars);
        /// <summary>
        /// 执行sql语句，返回结构的第一行，第一列的值
        /// </summary>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令字符串</param>
        /// <param name="commandParameters">命令参数</param>
        /// <returns></returns>
        public abstract object ExecuteScalar(CommandType cmdType, string cmdText, NameValueCollection pars);
        /// <summary>
        /// 执行sql语句，获得datatable
        /// </summary>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令字符串</param>
        /// <param name="commandParameters">命令参数</param>
        /// <returns></returns>
        public abstract DataTable GetDataTable(CommandType cmdType, string cmdText, NameValueCollection pars);
    }
}
