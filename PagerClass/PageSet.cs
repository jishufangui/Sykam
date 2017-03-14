using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web;
namespace PagerClass
{
    public partial class PageSet
    {
        private int currentPage;
        private int recordCount;
        private int pageSize;
        private int pageCount;

        private String[] fieldName;
        private String[] fieldValue;


        private ArrayList AfieldName;
        private ArrayList AfieldValue;


        private const int stepNum = 3;
        private string url;
        //private string css = "border:1px #CCCCCC solid;height:16px;float:left;color:#FFFFFF;cursor:pointer;padding:6px 8px 0px 8px;margin-left:5px;background-color:#DDDDDD;";
        //private string css1 = "border:1px #CCCCCC solid;height:16px;float:left;color:#666666;padding:6px 8px 0px 8px;margin-left:5px;";
        //private string css2 = "border:1px #CCCCCC solid;height:16px;float:left;color:#999999;cursor:pointer;padding:6px 8px 0px 8px;margin-left:5px;background-color:#EEEEEE;";

        public PageSet(int currentPage, int recordCount, int pageSize, String[] fieldName, String[] fieldValue)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            this.currentPage = currentPage;
            this.recordCount = recordCount;
            this.pageSize = pageSize;

            this.fieldName = fieldName;
            this.fieldValue = fieldValue;

            GeneratePageCount();
            GenerateUrl();
        }


        public PageSet(int currentPage, int recordCount, int pageSize, ArrayList fieldName, ArrayList fieldValue)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            this.currentPage = currentPage;
            this.recordCount = recordCount;
            this.pageSize = pageSize;

            this.AfieldName = fieldName;
            this.AfieldValue = fieldValue;

            GeneratePageCount();
            AGenerateUrl();
        }


        //生成url参数列表
        protected void GenerateUrl()
        {
            if (null != fieldName && null != fieldValue)
            {
                if (fieldName.Length == fieldValue.Length)
                {
                    for (int i = 0; i < fieldValue.Length; i++)
                    {
                        if (!String.IsNullOrEmpty(fieldValue[i]) && !fieldValue[i].Equals(""))
                        {
                            url += "&" + fieldName[i] + "=" + fieldValue[i];
                        }
                    }
                }
            }
        }





        //计算共有多少页 
        protected void GeneratePageCount()
        {
            int result = 1;

            if (recordCount > 0)
            {
                if ((recordCount % pageSize) == 0)
                    result = recordCount / pageSize;
                else
                    result = (int)Math.Ceiling((decimal)(recordCount / pageSize)) + 1;

                if (result < 1)
                    result = 1;
            }
            pageCount = result;
        }





        //生成url参数列表
        protected void AGenerateUrl()
        {
            if (null != AfieldName && null != AfieldValue)
            {
                if (AfieldName.Count == AfieldValue.Count)
                {
                    for (int i = 0; i < AfieldValue.Count; i++)
                    {
                         
                        if (!String.IsNullOrEmpty(AfieldValue[i].ToString()) && !AfieldValue[i].ToString().Equals(""))
                        {
                            url += "&" + AfieldName[i].ToString() + "=" + AfieldValue[i].ToString();
                        }
                    }
                }
            }
        }
    }
}
