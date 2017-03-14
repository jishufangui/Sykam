using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using DataHelper;
using CommonLibrary;
using TModel;
namespace TDAl.sqlserver
{
    public  class AdminOperate:IAdminOperate
    {
        DataHelper.DbHelper dh;
        private static string _connection = string.Empty;

        public AdminOperate()
        {
            _connection = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"].ToString();
            dh = new SqlHelper(_connection);
        }

        #region 通过 id获取管理员
        public TAdmin GetAdmin(int id)
        {
            TAdmin ta = new TAdmin();
            string cmdtxt = "select Admin_ID,Admin_UID,Admin_PWD,Admin_Stat,Admin_RealName,Admin_RegTime,Admin_LogTimes,Admin_Flag,SortID from T_Admin where Admin_ID=@Admin_ID and IsDelete=0";
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@Admin_ID",id.ToString());
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, cmdtxt, nvc))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    int Admin_id = 0;
                    Int32.TryParse(dr["Admin_ID"].ToString().Trim(), out Admin_id);
                    ta.Admin_ID = Admin_id;
                    ta.Admin_UID = dr["Admin_UID"].ToString();
                    ta.Admin_PWD = dr["Admin_PWD"].ToString();
                    bool stat = false;
                    bool.TryParse(dr["Admin_Stat"].ToString().Trim(), out stat);
                    ta.Admin_Stat = stat;
                    ta.Admin_RealName = dr["Admin_RealName"].ToString().Trim();
                    DateTime Addtime;
                    DateTime.TryParse(dr["Admin_RegTime"].ToString().Trim(), out Addtime);
                    ta.Admin_RegTime = Addtime;
                    ta.Admin_LogTimes = Convert.ToInt32(dr["Admin_LogTimes"].ToString());
                    ta.Admin_Flag = dr["Admin_Flag"].ToString();
                    int sortid = 0;
                    Int32.TryParse(dr["SortID"].ToString(), out sortid);
                    ta.SortID = sortid;
                }
            }
            dh.Close();

            return ta;
        }

        #endregion

        #region 添加管理员
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int AddAdmin(TAdmin admin)
        {
            #region 变量
            string Admin_UID = admin.Admin_UID;

            string Admin_PWD = admin.Admin_PWD;
            bool Admin_Stat = admin.Admin_Stat;
            string Admin_RealName = admin.Admin_RealName;
            DateTime Admin_RegTime =admin.Admin_RegTime;
            int  Admin_LogTimes =admin.Admin_LogTimes;
            string Admin_Flag = admin.Admin_Flag;
            int sortid = admin.SortID;
            #endregion
            string cmdtxt = "Insert into T_Admin(Admin_UID,Admin_PWD,Admin_Stat,Admin_RealName,Admin_RegTime,Admin_LogTimes,Admin_Flag,SortID,IsDelete) values (@Admin_UID,@Admin_PWD,@Admin_Stat,@Admin_RealName,@Admin_RegTime,@Admin_LogTimes,@Admin_Flag,@SortID,0)";
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@Admin_UID",Admin_UID);
            nvc.Add("@Admin_PWD",Admin_PWD);
            nvc.Add("@Admin_Stat",Admin_Stat.ToString());
            nvc.Add("@Admin_RealName", Admin_RealName);
            nvc.Add("@Admin_RegTime",Admin_RegTime.ToString());
            nvc.Add("@Admin_LogTimes",Admin_LogTimes.ToString());
            nvc.Add("@Admin_Flag",Admin_Flag);
            nvc.Add("@SortID",sortid.ToString());
            dh.Open();
            int stat = dh.ExecuteNonQuery(CommandType.Text, cmdtxt, nvc);
            dh.Close();
            return stat;
        }

        #endregion


        #region 更新管理员
        /// <summary>
        /// 修改admin信息
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateAdmin(TAdmin admin, int id)
        {   

            #region 变量
            string Admin_UID = admin.Admin_UID;
            string Admin_PWD = admin.Admin_PWD;
            bool Admin_Stat = admin.Admin_Stat;
            string Admin_RealName = admin.Admin_RealName;
            DateTime Admin_RegTime = admin.Admin_RegTime;
            int Admin_LogTimes = admin.Admin_LogTimes;
            string Admin_Flag = admin.Admin_Flag;
            int sortid = admin.SortID;
            #endregion
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@Admin_UID",Admin_UID);
            nvc.Add("@Admin_Stat",Admin_Stat.ToString());
            nvc.Add("@Admin_RealName",Admin_RealName);
            nvc.Add("@Admin_RegTime",Admin_RegTime.ToString());
            nvc.Add("@Admin_LogTimes",Admin_LogTimes.ToString());
            nvc.Add("@SortID",sortid.ToString());
            nvc.Add("@ModifyTime", admin.ModifyTime.HasValue ? admin.ModifyTime.Value.ToString("yyy-MM-dd hh:mm:ss") : DateTime.Now.ToString("yyy-MM-dd hh:mm:ss"));
            nvc.Add("@ModifyBy",admin.ModifyBy.ToString());
            nvc.Add("@Admin_ID",id.ToString());
            string cmdtxt = "Update T_Admin set Admin_UID=@Admin_UID,Admin_Stat=@Admin_Stat,Admin_RealName=@Admin_RealName,Admin_RegTime=@Admin_RegTime,Admin_LogTimes=@Admin_LogTimes,SortID=@SortID,ModifyTime=@ModifyTime,ModifyBy=@ModifyBy where  Admin_ID=@Admin_ID";
            dh.Open();
            int stat = dh.ExecuteNonQuery(CommandType.Text, cmdtxt, nvc);
            dh.Close();
            return stat;
        }
        #endregion


        #region  删除管理员
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public int DeleteAdmin(int id)
        //{   
        //    NameValueCollection nvc=new NameValueCollection();
        //    nvc.Add("@Admin_ID",id.ToString());
        //    dh.Open();
        //    int stat=dh.ExecuteNonQuery(CommandType.Text, "Delete from T_Admin where Admin_ID=@Admin_ID", nvc);
        //    dh.Close();
        //    return stat;
        //}


        public int LoginDeletAdmin(int id, int userid)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@ModifyBy", userid.ToString());
            nvc.Add("@Admin_ID", id.ToString());
            dh.Open();
            int stat = dh.ExecuteNonQuery(CommandType.Text, "update  T_Admin set IsDelete=1,ModifyBy=@ModifyBy,ModifyTime=getdate() where Admin_ID=@Admin_ID", nvc);
            dh.Close();
            return stat;

        }

        #endregion

        #region  获取最近更新ID
        public int GetLastAdminID()
        {
            int result = 0;
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "select IDENT_CURRENT( 'T_Admin' )", null))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    Int32.TryParse(dr[0].ToString().Trim(), out result);
                }

            }
            dh.Close();
            return result;
        }
        #endregion



        #region  获取管理员数量
        /// <summary>
        ///获取管理员数量
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <returns></returns>
        public int GetAdminNumByCondition(ArrayList FiledName, ArrayList FiledValue)
        {
            int recordcount = 0;
            string sbCondition = string.Empty;
            sbCondition = CommOperate.SelectCondition(FiledName, FiledValue);
            string cmdtxt = "Select count(*) from T_Admin where 1=1  "+sbCondition.ToString();

            dh.Open();
            dh.BeginTrans();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, cmdtxt, null))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    Int32.TryParse(dr[0].ToString(), out recordcount);
                }
            }
            dh.CommitTrans();
            dh.Close();
            
            return recordcount;


        }
        #endregion


        #region 获取指定区间的管理员
        /// <summary>
        /// 获取管理员的datatable
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <param name="startid"></param>
        /// <param name="endid"></param>
        /// <returns></returns>
        public DataTable GetAdminByCondition(ArrayList FiledName, ArrayList FiledValue, int startid, int endid)
        {
            string sbCondition = string.Empty;
            sbCondition = CommOperate.SelectCondition(FiledName, FiledValue);
            string cmdtxt = string.Empty;
            string orderbystring = " order by SortID asc,Admin_ID desc ";//排序字符串

            cmdtxt = "select * from (select Admin_ID,Admin_UID,Admin_Stat,Admin_RealName,Admin_RegTime,Admin_LogTimes,Admin_Flag,SortID,row_number() over (" + orderbystring + ") as rowno from T_Admin where 1=1 and IsDelete=0   " + sbCondition + "  ) as row  where rowno between " + startid + " and " + endid.ToString() + orderbystring;
            dh.Open();
            dh.BeginTrans();
            DataTable dt = dh.GetDataTable(CommandType.Text, cmdtxt, null);
            dh.CommitTrans();
            dh.Close();
            return dt;


        }

        #endregion

        #region 修改密码
        public int ChangePWd(string password, int id)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@Admin_PWD",password);
            nvc.Add("@Admin_ID",id.ToString());
            string cmdtxt = "Update T_Admin set Admin_PWD=@Admin_PWD where Admin_ID=@Admin_ID";
            dh.Open();
            int stat=dh.ExecuteNonQuery(CommandType.Text, cmdtxt, nvc);
            dh.Close();
            return stat;
        }
        #endregion


        #region  更新权限
        public int UpdateCompetence(string Flag, int id)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@Admin_Flag",Flag);
            nvc.Add("@Admin_ID",id.ToString());
            string cmdtxt = "Update T_Admin set Admin_Flag=@Admin_Flag where Admin_ID=@Admin_ID";
            dh.Open();
            int stat = dh.ExecuteNonQuery(CommandType.Text, cmdtxt, nvc);
            dh.Close();
            return stat;
        }
        #endregion


        #region 获取权限
        /// <summary>
        /// 获取网站权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetCompetence(int id)
        {
            string Flag = string.Empty;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@Admin_ID", id.ToString());
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "Select Admin_Flag from T_Admin where Admin_ID=@Admin_ID", nvc))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    Flag = dr[0].ToString();
                }
            }
            dh.Close();
            return Flag;
        }
        #endregion

        #region 验证用户名密码是否正确
        public int CheckUserNameAndPassWord(string UserID, string PassWord)
        {
            int Admin_ID = 0;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@Admin_UID", UserID);
            nvc.Add("@Admin_PWD", PassWord);
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "Select Admin_ID from T_Admin where Admin_UID=@Admin_UID and Admin_PWD=@Admin_PWD and IsDelete=0 ", nvc))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    Int32.TryParse(dr[0].ToString().Trim(), out Admin_ID);
                }
            }
            dh.Close();
            return Admin_ID;
        }
        #endregion
    }
}
