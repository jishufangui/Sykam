<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seo.aspx.cs" Inherits="Web.operate.seo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/main.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
                <tr>
                    <td  colspan="2" class="td_left">站点seo配置管理</td>
                </tr>
                
                <tr>
                    <td align="center" class="td5">Title</td>
                    <td align="left" class="td4"><asp:TextBox ID="tbx_title" runat="server" Width="200px" Text=""></asp:TextBox>
                        &nbsp;输入网站Title</td>
                </tr>
                
                <tr style="display:none">
                    <td align="center" class="td5">公司电话</td>
                    <td align="left" class="td4"><asp:TextBox ID="tbx_Tel" runat="server" 
                            Width="200px"  ></asp:TextBox>&nbsp;公司的电话</td>
                </tr>
                
                <tr style="display:none">
                    <td align="center" class="td5">公司传真</td>
                    <td align="left" class="td4"><asp:TextBox ID="tbx_ServerTel" runat="server" Width="200px"></asp:TextBox>
                        &nbsp;公司的传真号码</td>
                </tr>
                <tr style="display:none">
                    <td align="center" class="td5">备案号</td>
                    <td align="left" class="td4">
                        <asp:TextBox ID="tbx_ipc" runat="server" 
                            Width="123px"></asp:TextBox>&nbsp;&nbsp; 网站地址  <asp:TextBox ID="tbx_href" runat="server" 
                            Width="123px"></asp:TextBox>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="td5">站点关键字</td>
                    <td align="left" class="td4">
                        <asp:TextBox ID="tbx_Keywords" runat="server" 
                            Width="520px" TextMode="MultiLine" Height="63px"></asp:TextBox>&nbsp;SEO 
                        中文关键字设置</td>
                </tr>
                <tr>
                    <td align="center" class="td5">站点描述</td>
                    <td align="left" class="td4">
                        <asp:TextBox ID="tbx_Desc" runat="server" 
                            Width="520px" TextMode="MultiLine" Height="100px"></asp:TextBox>&nbsp;SEO 
                        中文站点描述</td>
                </tr>
                <tr>
                    <td colspan="2"  class="td_left">
                        <asp:Button Text="保存信息" ID="button1" 
                            runat="server" CssClass="button5" onclick="button1_Click" 
                            />
                            
                        <input id="Reset1" type="reset" value="重填信息" style="width: 62px" class="button5" />
                        </td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
