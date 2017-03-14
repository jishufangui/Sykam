<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperateIndex.aspx.cs" Inherits="Web.operate.OperateIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>网站后台管理系统</title>
     <link rel="stylesheet" type="text/css" href="css/main.css" />
</head>
<body>
    <form id="form1" runat="server">

      <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
   <tr>
     <td colspan="2" height="25" class="td_title">登录用户的状态</td>
   </tr>
   <tr>
     <td height="23" class="td4">真实姓名：<asp:Literal ID="lit_TrueName" runat="server"></asp:Literal></td>
     <td height="23" class="td4"> 　　　用户帐号：<asp:Literal ID="lit_User" runat="server"></asp:Literal></td>
   </tr>
   <tr>
     <td  class="td5" height="23">
         登 录 IP：<asp:Literal ID="lit_ClientIP" runat="server"></asp:Literal></td>
     <td  class="td5" height="23">　　　登录次数： <asp:Literal ID="lit_Count" runat="server"></asp:Literal>次</td>
   </tr>
   </table>
 <br>
 <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
<tr>
  <td colspan="2" height="25" class="td_title"><STRONG>系统详细信息</STRONG></td>
</tr>
<tr>
  <td class="td4" style="height: 24px">
      服务器IP：<asp:Literal ID="lit_ServerIP" runat="server"></asp:Literal></td>
  <td class="td4" style="height: 24px"> 　　　站点物理路径：<asp:Literal ID="lit_Directory" runat="server"></asp:Literal></td>
</tr>
<tr>
  <td  class="td5" height="23">
      返回服务器的主机名：<asp:Literal ID="lit_ServerName" runat="server"></asp:Literal></td>
  <td  class="td5" height="23">　　　服务器操作系统：<asp:Literal ID="lit_ServerOs" runat="server"></asp:Literal></td>
</tr>
            <tr>
                <td style="height: 24px" width="44%" class="td4">
                    脚本解释引擎：<asp:Literal ID="lit_ScriptEngin" runat="server"></asp:Literal></td>
                <td class="td4" style="height: 24px" width="56%">　　　服务器 CPU   数量：<asp:Literal ID="lit_CPU" runat="server"></asp:Literal></td>
            </tr>
<tr>
  <td class="td5" style="height: 24px">客户端操作系统： <asp:Literal ID="lit_ClientOS" runat="server"></asp:Literal>
      　</td>
  <td class="td5" style="height: 24px">
      </td>
</tr>
     <tr>
         <td class="td4" colspan="2" height="23">
             你的浏览器：<asp:Literal ID="L_browser" runat="server"></asp:Literal>
             [推荐IE5.5以上,请确认你的浏览器开启cookie功能]。</td>
     </tr>
</table>
      </form>
</body>
</html>
