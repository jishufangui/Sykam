<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperateTop.aspx.cs" Inherits="Web.operate.OperateTop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>OperateTop</title>
    <style type="text/css">
body { margin:0px; background:#337ABB url("Images/skins/images/top_bg.gif"); font-size:12px; }
div { margin:0px; padding:0px; }
.system_logo { width:160px; float:left; text-align:left; margin-top:5px; margin-left:5px; }
/*- Menu Tabs 6--------------------------- */

#tabs {
  float:left;
  width:auto;
  line-height:normal;
  }
#tabs ul {
  margin:0;
  padding:26px 10px 0 0px !important;
  *padding:27px 10px 0 0px !important;
  padding:27px 10px 0 0px;
  list-style:none;
  }
#tabs li {
  display:inline;
  margin:0;
  padding:0;
  }
#tabs a {
  float:left;
  background:url("Images/skins/images/tableft6.gif") no-repeat left top;
  margin:0;
  padding:0 0 0 4px;
  text-decoration:none;
  }
#tabs a span {
  float:left;
  display:block;
  background:url("Images/skins/images/tabright6.gif") no-repeat right top;
  padding:8px 8px 6px 6px;
  color:#E9F4FF;
  }
/* Commented Backslash Hack hides rule from IE5-Mac \*/
#tabs a span {float:none;}
/* End IE5-Mac hack */
#tabs a:hover span {
  color:#fff;
  }
#tabs a:hover {
  background-position:0% -42px;
  }
#tabs a:hover span {
  background-position:100% -42px;
  color:#222;
  }
</style>
</head>
<body>
    <div class="menu">
	<div class="system_logo"><img src="Images/skins/images/logo_up.gif"></div>
	<div id="tabs">
		<ul id="menu"  runat="server"></ul>
	</div>
	</div>
</body>
</html>
