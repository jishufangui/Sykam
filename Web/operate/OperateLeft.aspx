<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperateLeft.aspx.cs" Inherits="Web.operate.OperateLeft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>OperateLeft</title>
      <style type="text/css">
body { margin:0px; background:transparent; overflow:hidden; background:url("Images/skins/images/leftbg.gif"); }
.left_color { text-align:right; }
.left_color a { color: #083772; text-decoration: none; font-size:12px; display:block ;  width:175px !important; text-align:right; background:url("Images/skins/images/menubg.gif") right no-repeat; height:23px; line-height:23px; padding-right:10px; margin-bottom:2px;}
.left_color a:hover { color: #7B2E00;  background:url("Images/skins/images/menubg_hover.gif") right no-repeat; }
img { float:none; vertical-align:middle; }
#on { background:#fff url("Images/skins/images/menubg_on.gif") right no-repeat; color:#f20; font-weight:bold; }
hr { width:90%; text-align:left; size:0; height:0px; border-top:1px solid #46A0C8;}
</style>
<script type="text/javascript">
<!--
	function disp(n){
	    var objs=document.getElementById("menubar").getElementsByTagName("div");
		for (var i=0;i<objs.length;i++)
		{
			if(objs[i])
			   objs[i].style.display="none";
			
		}
		
		document.getElementById("left_"+n).style.display="block";
	}
	
//-->
</script>
</head>
<body>
    <div>
  <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top" style="padding-top:10px;" class="left_color" id="menubar" runat="server"></td>
 </tr>
</table>
    </div>
</body>
</html>
