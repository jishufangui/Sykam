<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Password_Mod.aspx.cs" Inherits="Web.operate.Admin_Password_Mod" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <link href="css/main.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="/Scripts/Library/jquery-1.7.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
  <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
                    <tr>
                        <td class="td_title">修改密码</td>
                    </tr>
                    <tr>
                        <td class="td4">
                            注意信息：请慎重修改管理员密码</td>
                    </tr>
                    <tr>
                        <td  class="td4" >
                            页面拓展：<a href="javascript:location.reload();">[刷新本页]</a>
                            <a href="javascript:history.back();">[返回上页]</a>
                            <a href="Admin_List.aspx">[管理员列表]</a>
                        </td>
                    </tr>
                </table>
 <br />
            <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
                <tr>
                    <td colspan="2" class="td_left">修改管理员密码</td>
                </tr>
                <tr>
                    <td align="center" class="td5" style="width:141px">管理员账号</td>
                    <td align="left" class="td4">&nbsp;<asp:Literal ID="L_admin_uid" runat="server"></asp:Literal></td>
                </tr>
             
                  <tr>
                    <td align="center" class="td5" style="width: 141px">原始密码</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_oldpassword" runat="server" 
                              Width="200px"   TextMode="Password"></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                 <tr>
                    <td align="center" class="td5" style="width: 141px">更新密码</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_password1" runat="server" 
                              Width="200px"  TextMode="Password"></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                 <tr>
                    <td align="center" class="td5" style="width: 141px">确认密码</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_password2" runat="server" 
                              Width="200px"   TextMode="Password"></asp:TextBox>
                                    &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ErrorMessage="两次输入密码不一致" ControlToValidate="Tbx_password2" ControlToCompare="Tbx_password1"></asp:CompareValidator>
                     </td>
                </tr>
                <tr>
                    <td colspan="2"  class="td_left">
                       <asp:Button ID="Button2" runat="server" Text="提交" 
                              CssClass="button5"  
                            onclick="Button2_Click" /> &nbsp;<input id="Reset1" type="reset" value="重填" style=" " class="button5" />&nbsp;
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>
