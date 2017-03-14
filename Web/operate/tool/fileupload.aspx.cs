using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CommonLibrary;
namespace Web.operate.tool
{
    public partial class fileupload : System.Web.UI.Page
    {
        int MaxSize;
        string filePath;
        string FileType;
        string Content;
        protected void Page_Load(object sender, EventArgs e)
        {
            MaxSize = Convert.ToInt32(Request.QueryString["MaxSize"].ToString());//上传文件大小，大于20M需要在iis中配置
            filePath = Request.QueryString["SavePath"].ToString();//文件保存路径
            FileType = Request.QueryString["FileType"].ToString();
            Content = Request.QueryString["UpInput"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string filetype1 = FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf(".") + 1);
                if (FileType.ToLower().IndexOf(filetype1.ToLower()) > 0)
                {
                    if (FileUpload1.PostedFile.ContentLength > MaxSize)
                    {
                       RunJs.AlertAndBack("文件大小超过限制");

                    }
                    else
                    {
                        string filename = System.Guid.NewGuid().ToString() + "." + filetype1;//设置文件名
                        if (!Directory.Exists(Server.MapPath("/") + "/" + filePath + "/" + CommOperate.GetFolder()))
                        {
                            Directory.CreateDirectory(Server.MapPath("/") + "/" + filePath + "/" +CommOperate.GetFolder());
                        }

                        string filepath = filePath  + CommOperate.GetFolder()+filename;
                        FileUpload1.SaveAs(Server.MapPath("/") + "/" + filePath + "/" + CommOperate.GetFolder()  + filename);//保存文件
                        Response.Write("<html><body style='margin:0px;padding:0px;'>");
                        Response.Write("<script type=\"text/javascript\" src=\"/Scripts/Library/jquery-1.7.1.min.js\"></script>");
                        Response.Write("<script>window.parent.document.getElementById(\"" + Content + "\").value='" +filepath + "';");
                       // Response.Write("var ObjSelect = document.parentWindow.parent.document.getElementById('CatePic');");
                       //Response.Write("ObjSelect.options[ObjSelect.options.selectedIndex].value='"+filepath+"'; ");
                        Response.Write("$(window.parent.document).find('#CatePic').append(\"<option value='"+filepath+"' selected='selected'>"+filepath+"</option>\");");
                        Response.Write("</script>");
                       // Response.Write(filepath + " ");
                        Response.Write("<a href=\"?FileType=" + FileType + "&MaxSize=" + MaxSize + "&SavePath=" + filePath + "&UpInput=" + Content + "\" target=\"_self\" style=\"font-size:12px;\">重新上传</a>");
                        Response.Write("</body></html>");
                        Response.End();



                    }
                }
                else
                {
                    RunJs.AlertAndBack("上传的文件类型不正确，只支持" + FileType + "类型文件");
                }

            }
            else
            {
                RunJs.AlertAndBack("请选择要上传的文件");
            }
        }
    }
}
