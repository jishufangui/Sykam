<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Top.ascx.cs" Inherits="Web.usercontrol.Top" %>
<div id="head">
		<div class="head_top">
			<p><a href="#">登录</a> | <a href="#">注册</a> | <a href="#">设为首页</a> | <a href="#">加入收藏</a></p>
		</div>
		<div class="head_mid">
			<a href="#"><img src="images/logo.jpg" border="0" /></a>
			<div class="search">
				<form name="form_search" style="margin:0px;" action="#" method="GET">
				<TABLE cellpadding="0" cellspacing="0"><TR><TD background="../images/bckgrnd-search.gif" style="padding-left:27px;padding-right:7px;"><INPUT TYPE="text" NAME="q" maxlength="50" value="search" id="search_value" style="color:#CCC;width:168px;border:0px;margin:0px;padding:0px;" onFocus="if (this.value=='search') this.value='';"> </TD><TD> <input type="image" src="../images/btn_go.png" alt="search" style="margin:1px 0 0 2px;"/></TD></TR></TABLE>
				</form>
			</div>
		</div>
		<div class="menu">
			<ul>
				<div class="menu_left">
					<li><a href="#">首 页</a></li>
					<li><a href="#">商场打折</a></li>
					<li><a href="#">数 码</a></li>
					<li><a href="#">家居建材</a></li>
					<li><a href="#">美食天地</a></li>
					<li><a href="#">电影快讯</a></li>
				</div>
				<div class="menu_right">
					<p>关注淘折网：<img src="images/sina.jpg" border="0" /> 111111万</p>
				</div>
				<div style="clear:both"></div>
			</ul>
		</div>
		<div class="head_bot">
			<ul>
				<p><strong>热点推荐：</strong> 手镯3折起  </p>
			</ul>
		</div>
	</div>
	