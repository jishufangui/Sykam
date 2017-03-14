<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Brand_Mod.aspx.cs" Inherits="Web.operate.Brand_Mod" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <link href="css/main.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="/Scripts/Library/jquery-1.7.1.min.js"></script>
      <script language="javascript" type="text/javascript" src="../Scripts/Library/My97DatePicker/WdatePicker.js"></script>
     <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
     <script type="text/javascript" src="../ckfinder/ckfinder.js"></script>
     <script type="text/javascript">
         $(document).ready(function() {


         var url = $("#CatePic").val();
         if (url != "") {
             $("#viewpic").html(
                  "<a href='" + url + "'  target='_blank'>查看图片</a>"
                 );
         }

         $("#CatePic").change(
             function() {
                 var url = $(this).val();
                 if (url != "") {
                     $("#viewpic").html(
                  "<a href='" + url + "'  target='_blank'>查看图片</a>"
                 );
                 }
             }
             );
         
         
         });
     
     </script>
</head>
<body>
    <form id="form1" runat="server">
<div>
             <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
                    <tr>
                        <td class="td_title">修改品牌信息</td>
                    </tr>
                    <tr>
                        <td class="td4">
                            注意信息：修改时请确保信息真实性</td>
                    </tr>
                    <tr>
                        <td  class="td4" >
                            页面拓展：<a href="javascript:location.reload();">[刷新本页]</a>
                            <a href="javascript:history.back();">[返回上页]</a>
                            <a href="Brand_List.aspx">[品牌列表]</a>
                        </td>
                    </tr>
                </table>
 <br />
            <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
                <tr>
                    <td colspan="2" class="td_left">修改品牌信息</td>
                </tr>
                <tr>
                    <td align="center" class="td5" style="width:141px">排序号</td>
                    <td align="left" class="td4"><asp:TextBox ID="tbx_SortId" runat="server" ValidationGroup="2" Width="100px">0</asp:TextBox>&nbsp;<asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbx_SortId" 
                            Display="Dynamic" ErrorMessage="请输入数字" ValidationExpression="\d+$" 
                            ValidationGroup="2"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                
                <tr>
                    <td align="center" class="td5" style="width:141px">品牌名称</td>
                    <td align="left" class="td4">
                        <asp:TextBox ID="tbx_title" runat="server" 
                             ValidationGroup="2" Width="200px" Height="20px"></asp:TextBox>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbx_title"
                                        Display="Dynamic" ErrorMessage="必须输入品牌名称" ValidationGroup="2"></asp:RequiredFieldValidator>&nbsp;请输入品牌名称&nbsp; &nbsp;<asp:Literal ID="L_IsRecoom" runat="server"></asp:Literal><span style=" color:Red;">作为推荐品牌(点击作为推荐品牌)</span></td>
                </tr>
                 <tr>
                    <td align="center" class="td5" style="width:141px">品牌描述</td>
                    <td align="left" class="td4">
                       <textarea name="content" id="ContentHolder" class="ckeditor"  rows="0" runat="server"></textarea> 
                        &nbsp;<br /><span  ><asp:Literal ID="L_isRemote" runat="server"></asp:Literal>获取远程图片</span></td>
                </tr>
                <tr>
                    <td align="center" class="td5" style="width: 141px">
                        品牌描述图片</td>
                    <td align="left" class="td4"><asp:Literal ID="L_selpic" runat="server"></asp:Literal><br /><input  type="hidden"  id="PicName" name="PicName" runat ="server"/> <iframe id="wfupload" src="tool/FileUpload.aspx?FileType=.gif/.jpeg/.bmp/.png/.jpg&MaxSize=5242880&SavePath=/uploadfile/Brand/&UpInput=PicName" frameborder="0" scrolling="no" width="300em" height="25" style="height: 27px"></iframe>
    &nbsp;gif/jpeg/jpg/png/bmp 小于5M<span id='viewpic'></span>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="td5" style="width: 141px">品牌模板</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_BrandTemplate" runat="server" 
                             ValidationGroup="2" Width="200px"></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                  <tr>
                    <td align="center" class="td5" style="width:141px">生成路径</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_htmlpath" runat="server" 
                             ValidationGroup="2" Width="200px"></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                   <tr>
                    <td align="center" class="td5" style="width: 141px">添加时间</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_Addtime" runat="server" 
                              Width="200px" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate"></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                  <tr>
                    <td align="center" class="td5" style="width: 141px">添加人</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_Adder" runat="server" 
                              Width="200px" ></asp:TextBox><asp:HiddenField ID="H_Adder"  runat="server"/>
                                    &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2"  class="td_left"><asp:Button ID="Button1" runat="server" Text="确认提交" OnClick="Button1_Click" ValidationGroup="2" CssClass="button5" Width="62px" />
                        &nbsp;<input id="Reset1" type="reset" value="重填信息" style="width: 62px" class="button5" />&nbsp;
                    </td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
