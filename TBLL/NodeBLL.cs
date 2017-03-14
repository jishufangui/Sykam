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
    public class NodeBLL
    {
       
        INodeOperate NodeOperate=null;
        public NodeBLL()
        {   TDAl.DatabaseProvider DataProvider = null;
            DataProvider =new DatabaseProvider();
            NodeOperate= DataProvider.GetNodeOperate();

        }


        #region 获取子类别
        /// <summary>
        /// 获取子类别
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public DataTable GetChildNode(int pid)
        {
           return NodeOperate.GetChildNode(pid);
        }

        #endregion


        #region  获取指定ID节点
        /// <summary>
        /// 获取指定ID节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TNode GetNode(int id)
        {
            return NodeOperate.GetNode(id);
        }

        #endregion


        #region  添加节点 
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="Node"></param>
        /// <returns></returns>
        public int AddNode(TNode Node)
        {
            int stat = 0;
            stat= NodeOperate.AddNode(Node);
            return stat;
        }

        #endregion

        #region 修改节点
        /// <summary>
        /// 修改节点
        /// </summary>
        /// <param name="NodeID"></param>
        /// <param name="Node"></param>
        /// <returns></returns>
        public int UpdateNode(int NodeID, TNode Node)
        {
            int stat = 0;
            stat = NodeOperate.UpdateNode(NodeID, Node);
            return stat;
        }
        #endregion

        #region 删除节点
        public int DeleteNode(int  NodeID)
        {
            int stat = 0;
            stat = NodeOperate.DeleteNode(NodeID);
            return stat;
        }
        #endregion

        #region  获取记录数
        public int GetNodeCounts(ArrayList FiledName, ArrayList FiledValue)
        {
            int counts = 0;
            counts= NodeOperate.GetNodeNumByCondition(FiledName,FiledValue);
            return counts;
        }

        #endregion


        #region 获取所有节点
        /// <summary>
        /// 获取记录下所有节点
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllNode()
        {
            return NodeOperate.GetAllNode();
        }

        #endregion

        #region 获取最近更新的nodeid
        public int GetLastNodeID()
        {
            int NodeID = 0;
            NodeID = NodeOperate.GetLastNodeID();
            return NodeID;
        }
        #endregion
       
        #region  分页
        /// <summary>
        /// 获取指定条件下的程序集
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <param name="OrderCondition"></param>
        /// <param name="startid"></param>
        /// <param name="endid"></param>
        /// <returns></returns>
        public DataTable GetNodeByCondition(ArrayList FiledName, ArrayList FiledValue, string  OrderCondition,int startid,int  endid)
        {
            DataTable dt = NodeOperate.GetNodeByCondition(FiledName, FiledValue, OrderCondition, startid, endid);
            return dt;
        }


        #endregion

    }
}
