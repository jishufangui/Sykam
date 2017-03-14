<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.operate.Login" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>网站后台管理系统</title>
     <link href="Css/Stylesheet.css" rel="Stylesheet" type="text/css" />
        <script type="text/javascript">
      <!--
      window.onload=function(){
          document.getElementById("userName").focus();
      }
      
       function ValidateInput()
       {
           var u=document.getElementById("userName");
           var p=document.getElementById("passWord");
           var c=document.getElementById("validCode");

           var _msg="";
           
           if(u.value=="")
               _msg+="[错误提示]请输入用户名！\n";
           if(p.value=="")
               _msg+="[错误提示]请输入密码！\n";
           if(c.value=="")
               _msg+="[错误提示]请输入验证码！";
               
           if(_msg!="")
           {
               alert(_msg);
               return false;
           }
           
           return true;
       }
       
       function ClearInput()
       {
           var u=document.getElementById("userName");
           var p=document.getElementById("passWord");
           var c=document.getElementById("validCode");
           
           u.value="";
           p.value="";
           c.value="";
       }
       -->
    </script>
</head>
<body>
    <form id="form1" runat="server">
<div>
       <table width="934" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="756" height="116" colspan="2">&nbsp;</td>
    <td width="178" height="503" rowspan="2" background="images/manage_03.jpg">&nbsp;</td>
  </tr>
  <tr>
    <td height="387" align="right" valign="bottom" background="images/manage_05.jpg" style="width: 409px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="100%" align="right">&nbsp;</td>
      </tr>
      <tr>
        <td height="48">&nbsp;</td>
      </tr>
    </table></td>
    <td width="347" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="45">&nbsp;</td>
      </tr>
      <tr>
        <td height="294" valign="top" background="images/manage_07.jpg"><table width="67%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td height="70" colspan="3">&nbsp;</td>
            </tr>
            <tr>
              <td width="58" height="38">用户名：</td>
              <td colspan="2">
                  <asp:TextBox CssClass="input" ID="userName" Width="155px" runat="server"></asp:TextBox>
                                            </td>
            </tr>
            <tr>
              <td style="height: 38px">密　码：</td>
              <td colspan="2" style="height: 38px">
                  <asp:TextBox ID="passWord" CssClass="input" Width="155px" runat="server" TextMode="Password"></asp:TextBox>
                                            </td>
            </tr>
            <tr>
              <td height="38">验证码：</td>
              <td width="111">
                  <asp:TextBox ID="validCode" runat="server" CssClass="input" Width="90px" MaxLength="5"></asp:TextBox>
                                            </td>
              <td width="63">
                  <font color="red">
                  <%
                                                Random rd = new Random();
                                                int i = rd.Next(10000, 99999);
                                                Response.Write(i.ToString());
                                                Session["yz"] = i.ToString();
                   %>
                  </font></td>
            </tr>
        </table>
          <table width="65%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td height="50" align="left">
                  <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/an31.jpg" OnClick="ImageButton1_Click" OnClientClick="return ValidateInput();" />
                  <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
              <td align="right"><img src="images/an32.jpg" width="86" height="33" border="0" id="IMG1" onclick="ClearInput()" style="cursor:pointer;" /></td>
            </tr>
          </table>
          <table width="100" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td><img src="images/dd22.jpg" width="308" height="3"></td>
            </tr>
          </table>
          <table width="100%" height="50" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              </tr>
          </table></td>
      </tr>
      <tr>
        <td height="48">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>
<table width="934" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td align="center"></td>
  </tr>
  <tr>
    <td align="center" style="height: 30px">Copyright &copy; 2017-  www.sykam.com.cn  All Rights Reserved  Powered By <a href="mailto:370333487@qq.com" target="_blank">370333487@qq.com</a></td>
  </tr>
  <tr>
    <td align="center" class="font1"></td>
  </tr>
</table>
    </div>      
    </form>
</body>
</html>
