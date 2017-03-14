using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace DataHelper
{
    public  class SqlHelper : DbHelper
    {
        private SqlConnection conn;
        private SqlTransaction trans;
        private bool inTransaction = false; //指示当前是否正处于事务中

        /// <summary>
        /// 获取IDbConnection
        /// </summary>
        public override IDbConnection Connection
        {
            get { return this.conn; }
        }

        /// <summary>
        /// 构造函数，初始SqlConnection对象
        /// </summary>
        /// <param name="StrConnection"></param>
        public SqlHelper(string StrConnection)
        {
            this.conn = new SqlConnection(StrConnection);
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public override void Open()
        {
            if (conn.State != ConnectionState.Open)
            {
                this.conn.Open();
            }
        }

        /// <summary>
        /// 关闭数据库连接，释放资源
        /// </summary>
        public override void Close()
        {
            if (this.trans != null)
            {
                this.trans.Dispose();
            }

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }


          
        }

        /// <summary>
        /// 开始事务
        /// </summary>
        public override void BeginTrans()
        {
            trans = conn.BeginTransaction();
            inTransaction = true;
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        public override void CommitTrans()
        {
            trans.Commit();
            inTransaction = false;
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public override void RollBackTrans()
        {
            trans.Rollback();
            inTransaction = false;
        }


        /// <summary>
        /// 参数准备
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        public void PrepareCommand(SqlCommand cmd, CommandType cmdType, string cmdText, NameValueCollection pars)
        {
            if (this.trans != null)
            {
                cmd.Transaction = this.trans;
            }
            cmd.Connection = conn;
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;

            if (pars != null && pars.Count > 0)
            {
                string[] keys = pars.AllKeys;
                for (int i = 0; i < pars.Count; i++)
                {
                    cmd.Parameters.AddWithValue(keys[i], pars[i]);
                }
            }
        }

        /// <summary>
        /// 执行sql命令，返回受影响行数
        /// </summary>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令</param>
        /// <param name="pars">参数组</param>
        /// <returns>受影响行数</returns>
        public override int ExecuteNonQuery(CommandType cmdType, string cmdText, NameValueCollection pars)
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                this.PrepareCommand(cmd, cmdType, cmdText, pars);

                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// 执行sql命令，返回DbDataReader
        /// </summary>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令</param>
        /// <param name="pars">参数组</param>
        /// <returns>DbDataReader</returns>
        public override DbDataReader ExecuteReader(CommandType cmdType, string cmdText, NameValueCollection pars)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                this.PrepareCommand(cmd, cmdType, cmdText, pars);
                DbDataReader dr = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return dr;
            }
        }

        /// <summary>
        /// 执行sql语句，返回第一行第一列
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public override object ExecuteScalar(CommandType cmdType, string cmdText, NameValueCollection pars)
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                this.PrepareCommand(cmd, cmdType, cmdText, pars);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 执行sql语句，返回DataTable
        /// </summary>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令</param>
        /// <param name="pars">参数组</param>
        /// <returns></returns>
        public override DataTable GetDataTable(CommandType cmdType, string cmdText, NameValueCollection pars)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                DataTable dt = new DataTable();
                this.PrepareCommand(cmd, cmdType, cmdText, pars);

                using (DbDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    cmd.Parameters.Clear();
                    return dt;
                }

            }

        }

    }
}
