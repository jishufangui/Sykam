using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lucene.Net;
using Lucene.Net.Analysis;
using ChineseAnalyzer;

namespace Web.operate.ajax
{
    public partial class GetTag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                string keywords = CommonLibrary.CommOperate.GetStrFromRequestQueryString("title");
                StringBuilder sb = new StringBuilder();
                string t1 = "";
                Analyzer analyzer = new ChineseAnalyzer.ChineseAnalyzer();
                StringReader sr = new StringReader(keywords);
                TokenStream stream = analyzer.TokenStream(null, sr);
                //long begin = System.DateTime.Now.Ticks;
                Token t = stream.Next();
                while (t != null)
                {
                    t1 = t.ToString();
                    t1 = t1.Replace("(", "");
                    char[] separator = { ',' };
                    t1 = t1.Split(separator)[0];
                    sb.Append(t1);
                    sb.Append(",");
                    t = stream.Next();
                }
              
                Response.Write(sb.ToString());
                Response.End();
 
        }
    }
}
