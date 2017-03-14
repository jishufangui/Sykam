using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TModel;

namespace TDAl
{
    public interface IUserMemberOperate
    {
         /// <summary>
        /// 获取指定ID成员
        /// </summary>
        /// <param name="id"></param>
         TUserMember GetUserMember(string  id);

        /// <summary>
        /// 添加成员
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int AddUserMember(TUserMember info);


        /// <summary>
        /// 修改指定成员
        /// </summary>
        /// <param name="info"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateUserMember(TUserMember info, string id);


        /// <summary>
        /// 删除指定ID成员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteInfo(string  id);


        /// <summary>
        /// 逻辑删除指定ID成员
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        int LogicDeleteInfo(string id, int userid);



        /// <summary>
        /// 根据指定条件获取用户数量
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <returns></returns>
        int GetUserMemberNum(ArrayList FiledName, ArrayList FiledValue);


        DataTable GetInfoByNode(ArrayList FiledName, ArrayList FiledValue);

    }
}
