using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
namespace DataHelper
{
   public class OledbHelper : DbHelper
    {
        private OleDbConnection conn;
        private OleDbTransaction trans;

        private bool inTransaction = false; //指示当前是否正处于事务中

        /// <summary>
        /// 构造函数，初始OledbConnection对象
        /// </summary>
        /// <param name="StrConnection"></param>
        public OledbHelper(string StrConnection)
        {
            this.conn = new OleDbConnection(StrConnection);
        }

        /// <summary>
        /// 获取Conneciton
        /// </summary>
        public override IDbConnection Connection
        {
            get { return this.conn; }
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

        public override void BeginTrans()
        {
            trans = conn.BeginTransaction();
            inTransaction = true;
        }
        public override void CommitTrans()
        {
            trans.Commit();
            inTransaction = false;
        }

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
        public void PrepareCommand(OleDbCommand cmd, CommandType cmdType, string cmdText, NameValueCollection pars)
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



        public override int ExecuteNonQuery(CommandType cmdType, string cmdText, NameValueCollection pars)
        {

            using (OleDbCommand cmd = new OleDbCommand())
            {
                this.PrepareCommand(cmd, cmdType, cmdText, pars);

                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }

        }

        public override DbDataReader ExecuteReader(CommandType cmdType, string cmdText, NameValueCollection pars)
        {
            using (OleDbCommand cmd = new OleDbCommand())
            {
                this.PrepareCommand(cmd, cmdType, cmdText, pars);
                DbDataReader dr = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return dr;
            }

        }

        public override object ExecuteScalar(CommandType cmdType, string cmdText, NameValueCollection pars)
        {

            using (OleDbCommand cmd = new OleDbCommand())
            {
                this.PrepareCommand(cmd, cmdType, cmdText, pars);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public override DataTable GetDataTable(CommandType cmdType, string cmdText, NameValueCollection pars)
        {
            using (OleDbCommand cmd = new OleDbCommand())
            {
                DataTable dt = new DataTable();
                this.PrepareCommand(cmd, cmdType, cmdText, pars);

                using (DbDataAdapter da = new OleDbDataAdapter())
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
