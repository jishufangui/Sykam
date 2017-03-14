using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TModel;
namespace TDAl
{
    public interface INodeOperate
    {
        /// <summary>
        /// 获取所有节点
        /// </summary>
        /// <returns></returns>
        DataTable GetAllNode();

        /// <summary>
        /// 获取指定父类别下的子节点
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        DataTable GetChildNode(int pid);

        /// <summary>
        /// 获取指定ID的节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TNode GetNode(int id);

        /// <summary>
        ///  添加节点
        /// </summary>
        /// <param name="NodeID"></param>
        /// <param name="NodeName"></param>
        /// <param name="NodeIdentifier"></param>
        /// <param name="ParentID"></param>
        /// <param name="NodeMemo"></param>
        /// <param name="NodePic"></param>
        /// <param name="SortID"></param>
        /// <param name="IsRecom"></param>
        /// <param name="IsHtml"></param>
        /// <param name="HtmlPath"></param>
        /// <param name="NodeTemplate"></param>
        /// <param name="Meta_Description"></param>
        /// <param name="Meta_KeyWords"></param>
        /// <returns></returns>
        int AddNode(TNode Node);

        /// <summary>
        /// 修改节点
        /// </summary>
        /// <param name="NodeID">节点ID</param>
        /// <param name="NodeName">节点名称</param>
        /// <param name="NodeIdentifier">节点标识符</param>
        /// <param name="ParentID">父节点名称</param>
        /// <param name="NodeMemo">节点描述</param>
        /// <param name="NodePic">节点图片</param>
        /// <param name="SortID">节点排序号</param>
        /// <param name="IsRecom">是否推荐</param>
        /// <param name="IsHtml">是否生成html</param>
        /// <param name="HtmlPath">HTML路ing</param>
        /// <param name="NodeTemplate">节点模板</param>
        /// <param name="Meta_Description">Meta_描述</param>
        /// <param name="Meta_KeyWords">Meta_关键字</param>
        /// <returns></returns>
        int UpdateNode(int NodeID, TNode Node);

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></rstreturns>
        int DeleteNode(int NodeID);

        /// <summary>
        /// 获取最近插入NodeID
        /// </summary>
        /// <returns></returns>
        int GetLastNodeID();
        
        /// <summary>
        /// 更新PATH
        /// </summary>
        /// <param name="toid">父节点ID</param>
        /// <param name="path">当前路径</param>
        /// <returns></returns>
        int UpdateNodePath(int toid, string path, int? currentid);

        /// <summary>
        /// 根据条件获取记录数
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <returns></returns>
        int GetNodeNumByCondition(ArrayList FiledName, ArrayList FiledValue);

        ArrayList GetAllChildNode(int pid);

        /// <summary>
        /// 通过指定条件，获取指定区间的datatalbe
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <param name="OrderCondition"></param>
        /// <param name="startid"></param>
        /// <param name="endid"></param>
        /// <returns></returns>
        DataTable GetNodeByCondition(ArrayList FiledName, ArrayList FiledValue, string OrderCondition, int startid, int endid);

   
    }
}
