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
        /// ����xml�ļ�
        /// </summary>
        /// <param name="path"></param>
        /// <param name="node_root"></param>
        public  void LoadXml(string path, string node_root)
        {
            xmlDoc = new XmlDocument();
            path = System.Web.HttpContext.Current.Server.MapPath(path);
        
            //�ж�xml�Ƿ����
            if (!System.IO.File.Exists(path))
            {   

          
                //����xml�����ڵ�
             
                XmlNode xmlnode = xmlDoc.CreateNode(XmlNodeType.Element, node_root,"");
           
                //������������������ڵ�
                xmlDoc.AppendChild(xmlnode);
                //����xml dbGuest Ԫ��(���ڵ�)
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
        /// ѡ��xml�ӽڵ�
        /// </summary>
        /// <param name="path">xml�ļ�·��</param>
        /// <param name="parentNode">���ڵ�</param>
        /// <returns></returns>
        public XmlNodeList SelectNodes(string path, string parentNode)
        {
            LoadXml(path, parentNode);
            return xmlDoc.SelectSingleNode(parentNode).ChildNodes;
        }
        /// <summary>
        /// ���xml�ӽڵ�
        /// </summary>
        /// <param name="path">xml�ļ�����·��</param>
        /// <param name="node_root">���ڵ�����</param>
        /// <param name="node_name">����ӽڵ�����</param>
        /// <param name="node_text">�ӽڵ��ı�</param>
        /// <param name="att_name">�ڵ���������</param>
        /// <param name="att_value">�ڵ�����ֵ</param>
        public void AddElement(string path, string node_root, string node_name, string att_name, string att_value)
        {
            LoadXml(path, node_root);
            path = System.Web.HttpContext.Current.Server.MapPath(path);
            //��ȡ��xml�������ӽڵ�
            //XmlNodeList nodeList = xmlDoc.SelectSingleNode(node_root).ChildNodes;
            XmlNodeList nodeList = xmlDoc.SelectSingleNode(node_root).ChildNodes;
            //�ж��Ƿ��нڵ�,�нڵ�ͱ��������ӽڵ�,������û���ظ��ڵ�,û�ڵ�����һ���½ڵ� 
            if (nodeList.Count > 0)
            {
                foreach (XmlNode xn in nodeList)
                {
                    XmlElement xe = (XmlElement)xn;
                    if (xe.GetAttribute(att_name) != att_value)
                    {
                        //ѡ�и��ڵ�
                        XmlNode xmldocSelect = xmlDoc.SelectSingleNode(node_root);
                        //����ӽڵ�
                        XmlElement son_node = xmlDoc.CreateElement(node_name);
                        //���ýڵ�����
                        son_node.SetAttribute(att_name, att_value);
             
                        //����ӽڵ�
                        xmldocSelect.AppendChild(son_node);
                        xmlDoc.Save(path);
                        break;
                    }
                }
            }
            else
            {
                //ѡ�и��ڵ�
                XmlNode xmldocSelect = xmlDoc.SelectSingleNode(node_root);
                //����ӽڵ�
                XmlElement son_node = xmlDoc.CreateElement(node_name);
                //�����ӽڵ�����
                son_node.SetAttribute(att_name, att_value);
           
                //���ӽڵ���ӵ�ѡ�е�xml��
                xmldocSelect.AppendChild(son_node);
                //����xml 
                xmlDoc.Save(path);
            }
        }

        /// <summary> 
        /// �޸Ľڵ������ֵ
        /// </summary> 
        /// <param name="path">xml�ļ�������·�� </param> 
        /// <param name="node_root">���ڵ����� </param> 
        /// <param name="new_text">�ڵ�������� </param> 
        /// <param name="att_name">�ڵ�������� </param> 
        /// <param name="att_value">�ڵ������ֵ </param> 
        public void UpdateElement(string path, string node_root, string att_name, string att_value)
        {
            LoadXml(path, node_root);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode(node_root).ChildNodes;//��ȡbookstore�ڵ�������ӽڵ� 
            foreach (XmlNode xn in nodeList)//���������ӽڵ� 
            {
                XmlElement xe = (XmlElement)xn;//���ӽڵ�����ת��ΪXmlElement���� 
                if (xe.GetAttribute(att_name) == att_value)
                {
                    xmlDoc.Save(path);//���� 
                    break;
                }


            }

        }


        /// <summary> 
        /// ɾ���ڵ� 
        /// </summary> 
        /// <param name="path">xml�ļ�������·�� </param> 
        /// <param name="node_root">���ڵ����� </param> 
        /// <param name="att_name">�ڵ�������� </param> 
        /// <param name="att_value">�ڵ������ֵ </param> 
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
                    xe.RemoveAll();//ɾ���ýڵ��ȫ������ 
                    root.RemoveChild(xe);
                    xmlDoc.Save(path);//���� 
                    break;
                }

            }
        } 


    }
}
