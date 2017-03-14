<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.operate.Default" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta content="no-cache" /> 
    <meta http-equiv="Cache-Control" content="no-cache" /> 
    <meta http-equiv="Expires" content="0" />
    <title>后台管理系统</title>
    <link href="Images/skins/css/style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    html,body{height:100%;}
.main_left {table-layout:auto; background:url(Images/skins/images/left_bg.gif)}
.main_left_top{ background:url(Images/skins/images/left_menu_bg.gif); padding-top:2px !important; padding-top:5px;}
.main_left_title{text-align:left; padding-left:15px; font-size:14px; font-weight:bold; color:#fff;}
.left_iframe{HEIGHT: 92%; VISIBILITY: inherit;WIDTH: 180px; background:transparent;}
.main_iframe{HEIGHT: 92%; VISIBILITY: inherit; WIDTH:100%; Z-INDEX: 1}
table { font-size:12px; font-family : tahoma, 宋体, fantasy; }
td { font-size:12px; font-family : tahoma, 宋体, fantasy;}

</style>
<script type="text/javascript" src="../Scripts/Library/jquery-1.3.2.min.js"></script>

<script type="text/javascript" language="javascript">

var status = 1;
function switchSysBar(){
     if (1 == window.status){
		  window.status = 0;
		  switchPoint.innerHTML="<img src='Images/skins/images/left.gif' />";
          document.all("frmTitle").style.display="none"
     }
     else{
		  window.status = 1;
		  switchPoint.innerHTML="<img src='Images/skins/images/right.gif' />";
          document.all("frmTitle").style.display="block"
     }
     
     }
</script>
</head>
<body >
               
<table border="0" cellpadding="0" cellspacing="0" width="100%" style="background:#C3DAF9; height:100%;">
<tr>
<td style="height:58px;" colspan="3">
<iframe frameborder="0" id="top" name="top" scrolling="no" src="OperateTop.aspx" style="height: 100%; visibility: inherit;width: 100%;"></iframe>
</td>
</tr>
<tr>
<td style="height:30px;" colspan="3">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr style="background:url(Images/skins/images/bg2.gif); height:32px;">
	  <td style="padding-left:30px; width:20px;"><img src="Images/skins/images/arrow.gif"alt="" /></td>
	  <td ><span style="float:left; width: 76px;">友情提示：</span><div>
          &nbsp;
          <marquee behavior="scroll" direction="left" scrollamount="2" scrolldelay="50" onmouseover="this.stop()" onmouseout="this.start()" width="500">
          <script language="JavaScript" type="text/javascript" >
var enabled=0;today=new Date();
var day;var date;var strTemp;
if(today.getDay()==0)    day="星期日" 
if(today.getDay()==1)    day="星期一" 
if(today.getDay()==2)    day="星期二" 
if(today.getDay()==3)    day="星期三" 
if(today.getDay()==4)    day="星期四" 
if(today.getDay()==5)    day="星期五" 
if(today.getDay()==6)    day="星期六" 
H=today.getHours();
if(H>0&&H<12) strTemp="上午好! "
if(H==12) strTemp="中午好! "
if((H>12&&H<18)||H==18) strTemp="下午好! "
if(H>18) strTemp="晚上好! "
date="<font color=#ff0000>"+strTemp+"</font>"+" 今天是："+(today.getFullYear())+"年"+(today.getMonth()+1)+"月"+today.getDate()+"日   "+day;
document.write(date);

            </script> 
            
            
	    对于不同功能模块的页面，要仔细看页面中的说明，以免误操作</marquee></div></td>
	  <td  style="text-align:right; color: #135294; ">
 
          | <a href="OperateIndex.aspx" target='frmright'>后台首页</a> | <a href="/" target="_blank">网站首页</a> | 
          <a href="LogOut.aspx" onclick="return confirm('确认退出吗？');">退出</a>&nbsp;</td>
  </tr>
</table>
</td>
</tr>
<tr>
	<td align="center" id="frmTitle" valign="top" name="fmtitle" style="background:#c9defa">
	<iframe frameborder="0" id="frmleft" name="frmleft" src="OperateLeft.aspx" style="height: 100%; visibility: inherit;width: 185px;background:url(Images/skins/images/leftop.gif) no-repeat" allowtransparency="true"></iframe>
	</td>
	<td style="width:0px;" valign="middle">
		<div onclick="switchSysBar()"><span class="navpoint" id="switchPoint" title="关闭/打开左栏"><img src="Images/skins/images/right.gif" alt="" /></span></div>
	</td>
	<td style="width: 100%" valign="top">
		<iframe frameborder="0" id="frmright" name="frmright" scrolling="yes" src="OperateIndex.aspx" style="height: 100%; visibility: inherit; width:100%; z-index: 1"></iframe>
	</td>
</tr>
<tr>

<td style="height:30px;" colspan="3">
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="background:url(Images/skins/images/botbg.gif)">
  <tr style="height:30px;">
	<td style="padding-left:30px; font-family:arial; font-size:11px;" align="left">Copyright Right &copy; 2017- 版权所有：www.sykam.com.cn &nbsp; &nbsp;Powered By <a href="mailto:370333487@qq.com" target="_blank">370333487@qq.com</a></td>
	<td style="text-align:right; color:#91B1C6;"></td>
	<td style="text-align:right; color: #135294; padding-right:20px;"><asp:Literal ID="L_changepwd" runat="server"></asp:Literal> |  </td>
  </tr>
</table>
</td>
</tr>

</table>
</body>
</html>
