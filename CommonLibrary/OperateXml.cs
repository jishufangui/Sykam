using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace CommonLibrary
{
    public class OperateXml
    {
        private   XmlDocument xmlDoc;
        public OperateXml()
        {
        }

        /// <summary>
        /// 加载xml文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="node_root"></param>
        public  void LoadXml(string path, string node_root)
        {
            xmlDoc = new XmlDocument();
            path = System.Web.HttpContext.Current.Server.MapPath(path);
        
            //判断xml是否存在
            if (!System.IO.File.Exists(path))
            {   

          
                //创建xml声明节点
             
                XmlNode xmlnode = xmlDoc.CreateNode(XmlNodeType.Element, node_root,"");
           
                //添加上述创建和生命节点
                xmlDoc.AppendChild(xmlnode);
                //创建xml dbGuest 元素(根节点)
                // XmlElement xmlelem = xmlDoc.CreateElement("", node_root, "");
                // xmlDoc.AppendChild(xmlelem);
                try
                {
                    xmlDoc.Save(path);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                xmlDoc.Load(path);
            }
        }


        /// <summary>
        /// 选择xml子节点
        /// </summary>
        /// <param name="path">xml文件路径</param>
        /// <param name="parentNode">父节点</param>
        /// <returns></returns>
        public XmlNodeList SelectNodes(string path, string parentNode)
        {
            LoadXml(path, parentNode);
            return xmlDoc.SelectSingleNode(parentNode).ChildNodes;
        }
        /// <summary>
        /// 添加xml子节点
        /// </summary>
        /// <param name="path">xml文件物理路径</param>
        /// <param name="node_root">根节点名称</param>
        /// <param name="node_name">添加子节点名称</param>
        /// <param name="node_text">子节点文本</param>
        /// <param name="att_name">节点属性名称</param>
        /// <param name="att_value">节点属性值</param>
        public void AddElement(string path, string node_root, string node_name, string att_name, string att_value)
        {
            LoadXml(path, node_root);
            path = System.Web.HttpContext.Current.Server.MapPath(path);
            //获取该xml下所有子节点
            //XmlNodeList nodeList = xmlDoc.SelectSingleNode(node_root).ChildNodes;
            XmlNodeList nodeList = xmlDoc.SelectSingleNode(node_root).ChildNodes;
            //判断是否有节点,有节点就遍历所有子节点,看看有没有重复节点,没节点就添加一个新节点 
            if (nodeList.Count > 0)
            {
                foreach (XmlNode xn in nodeList)
                {
                    XmlElement xe = (XmlElement)xn;
                    if (xe.GetAttribute(att_name) != att_value)
                    {
                        //选中根节点
                        XmlNode xmldocSelect = xmlDoc.SelectSingleNode(node_root);
                        //添加子节点
                        XmlElement son_node = xmlDoc.CreateElement(node_name);
                        //设置节点属性
                        son_node.SetAttribute(att_name, att_value);
             
                        //添加子节点
                        xmldocSelect.AppendChild(son_node);
                        xmlDoc.Save(path);
                        break;
                    }
                }
            }
            else
            {
                //选中根节点
                XmlNode xmldocSelect = xmlDoc.SelectSingleNode(node_root);
                //添加子节点
                XmlElement son_node = xmlDoc.CreateElement(node_name);
                //设置子节点属性
                son_node.SetAttribute(att_name, att_value);
           
                //将子节点添加到选中的xml中
                xmldocSelect.AppendChild(son_node);
                //保存xml 
                xmlDoc.Save(path);
            }
        }

        /// <summary> 
        /// 修改节点的属性值
        /// </summary> 
        /// <param name="path">xml文件的物理路径 </param> 
        /// <param name="node_root">根节点名称 </param> 
        /// <param name="new_text">节点的新内容 </param> 
        /// <param name="att_name">节点的属性名 </param> 
        /// <param name="att_value">节点的属性值 </param> 
        public void UpdateElement(string path, string node_root, string att_name, string att_value)
        {
            LoadXml(path, node_root);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode(node_root).ChildNodes;//获取bookstore节点的所有子节点 
            foreach (XmlNode xn in nodeList)//遍历所有子节点 
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 
                if (xe.GetAttribute(att_name) == att_value)
                {
                    xmlDoc.Save(path);//保存 
                    break;
                }


            }

        }


        /// <summary> 
        /// 删除节点 
        /// </summary> 
        /// <param name="path">xml文件的物理路径 </param> 
        /// <param name="node_root">根节点名称 </param> 
        /// <param name="att_name">节点的属性名 </param> 
        /// <param name="att_value">节点的属性值 </param> 
        public void DeleteNode(string path, string node_root, string att_name, string att_value)
        {

            LoadXml(path, node_root);

            XmlNodeList nodeList = xmlDoc.SelectSingleNode(node_root).ChildNodes;
            XmlNode root = xmlDoc.SelectSingleNode(node_root);

            foreach (XmlNode xn in nodeList)
            {
                XmlElement xe = (XmlElement)xn;

                if (xe.GetAttribute(att_name) == att_value)
                {
                    xe.RemoveAll();//删除该节点的全部内容 
                    root.RemoveChild(xe);
                    xmlDoc.Save(path);//保存 
                    break;
                }

            }
        } 


    }
}
