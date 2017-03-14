<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Add.aspx.cs" Inherits="Web.operate.Admin_Add" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <link href="css/main.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="/Scripts/Library/jquery-1.7.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
                    <tr>
                        <td class="td_title">添加管理员</td>
                    </tr>
                    <tr>
                        <td class="td4">
                            注意信息：请慎重修改管理员信息</td>
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
                    <td colspan="2" class="td_left">添加管理员</td>
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
                    <td align="center" class="td5" style="width:141px">管理员账号</td>
                    <td align="left" class="td4">
                        <asp:TextBox ID="tbx_uid" runat="server" 
                             ValidationGroup="2" Width="200px" Height="20px"></asp:TextBox>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbx_uid"
                                        Display="Dynamic" ErrorMessage="必须输入管理员账号" ValidationGroup="2"></asp:RequiredFieldValidator>&nbsp;请输入管理员账号</td>
                </tr>
                 <tr>
                    <td align="center" class="td5" style="width:141px">管理员昵称</td>
                    <td align="left" class="td4">
                        <asp:TextBox ID="tbx_nickname" runat="server" 
                             ValidationGroup="2" Width="200px" Height="20px"></asp:TextBox>
                                    &nbsp;</td>
                </tr>
              
             
                <tr>
                    <td align="center" class="td5" style="width: 141px">管理员密码</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_password1" runat="server"  TextMode="Password"
                              Width="200px" ></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                  <tr>
                    <td align="center" class="td5" style="width: 141px">确认密码</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_password2" runat="server" TextMode="Password"
                              Width="200px" ></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                
                <tr>
                    <td align="center" class="td5" style="width: 141px">添加时间</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_Addtime" runat="server" 
                              Width="200px" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate"></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                  <tr>
                    <td align="center" class="td5" style="width: 141px">状态</td>
                    <td align="left" class="td4"><Select id="sel_stat" name="sel_stat"><option value="true">未锁定</option><option value="false">已锁定</option></Select>
                                    &nbsp;</td>
                </tr>
                 <tr>
                    <td align="center" class="td5" style="width: 141px">登录次数</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_logtimes" runat="server" 
                              Width="200px"  Text="0"></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2"  class="td_left">
                       <asp:Button ID="Button2" runat="server" Text="提交" 
                              ValidationGroup="2" CssClass="button5"  
                            onclick="Button2_Click" /> &nbsp;<input id="Reset1" type="reset" value="重填" style=" " class="button5" />&nbsp;
                    </td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
