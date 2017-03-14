using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TModel;
namespace TDAl
{
    public  interface IAdminOperate
    {   

        /// <summary>
        /// 根据id获取管理员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        TAdmin GetAdmin(int id);

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        int AddAdmin(TAdmin admin);

        /// <summary>
        /// 修改管理员
        /// </summary>
        /// <param name="admind"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateAdmin(TAdmin admind, int id);

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //int DeleteAdmin(int id);
        int LoginDeletAdmin(int id, int userid);

        /// <summary>
        /// 获取最近插入的管理员ID
        /// </summary>
        /// <returns></returns>
        int GetLastAdminID();

        /// <summary>
        /// 指定条件下获取管理员数量
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <returns></returns>
        int GetAdminNumByCondition(ArrayList FiledName, ArrayList FiledValue);

        /// <summary>
        /// 指定条件下获取指定记录
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <param name="OrderCondition"></param>
        /// <param name="startid"></param>
        /// <param name="endid"></param>
        /// <returns></returns>
        DataTable GetAdminByCondition(ArrayList FiledName, ArrayList FiledValue, int startid, int endid);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int ChangePWd(string password,int id);

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetCompetence(int id);

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="Flag"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateCompetence(string Flag, int id);

        /// <summary>
        /// 检测用户名密码是否正确
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        int  CheckUserNameAndPassWord(string UserID, string PassWord);
    }
}
