<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Competence_Mod.aspx.cs" Inherits="Web.operate.Competence_Mod"  ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="css/main.css" />
     <script type="text/javascript" src="../Scripts/Library/jquery-1.3.2.min.js"></script>
     <script type="text/javascript" src="../Scripts/CheckBox.js"></script>
     <script type="text/javascript" src="../Scripts/SystemRole.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
   <tr>
     <td colspan="2" style="text-align:center; height: 26px;" class="td_title">
         用户权限修改修改</td>
   </tr>
   <tr>
     <td height="23" class="td4" style="width:100%">
         注意信息：谨慎填写每一项。</td>
    
   </tr>
   <tr>
     <td  class="td5" height="23" style="width: 348px">页面拓展：<a href="Admin_List.aspx"><span style=" color:Red">[返回用户列表]</span></a></td>
     
   </tr>
 </table>
 <br />
    <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
   <tr>
     <td colspan="2" height="25" style="text-align:left" class="td_title">
         &nbsp;&nbsp;用户权限修改修改
      </td>
   </tr>
   
   <tr>
     <td class="td5" style="width: 17%; height: 24px;">
         &nbsp; 用户名：
    
    
    </td>
     
     
     
     <td style="width:100%; text-align:left; height: 24px; "  class="td4">
         &nbsp;<asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
   </tr>
      <tr>
     <td class="td5" style="width: 17%; ">
         &nbsp;&nbsp; 权限分配</td>
     
     
     
     <td style="width:100%; text-align:left; height: 24px; "  class="td4">
         <asp:Literal id="L_panel" runat="server"></asp:Literal></td>
   </tr>
   <tr>
     <td colspan="2" height="25" style="text-align:center" class="td_title"> 
         <input onclick="CheckChange(true);" type="button" value="全选" class="button5" />&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<input onclick="CheckChange(false);"
             type="button" value="全不选"  class="button5"/>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="Button1" runat="server" Text="确认修改" OnClick="Button1_Click1" CssClass="button5" />
         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button
             ID="Button2" runat="server" Text="取消"   CssClass="button5" OnClick="Button2_Click"  /></td>
   </tr>
   </table>
    </form>
</body>
</html>
