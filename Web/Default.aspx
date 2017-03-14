<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<%@ Register src="usercontrol/Top.ascx" tagname="Top" tagprefix="uc1" %>

<%@ Register src="usercontrol/Foot.ascx" tagname="Foot" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <meta name="keywords" content=<%=Page_Keyword %> />
    <meta name="description" content=<%=Page_Description %>/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="css/main.css" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.2.6.js"></script> 
</head>
<body>
<uc1:Top ID="Top1" runat="server" />
 <div id="middle">
		<div class="middle_con">
			<div class="banner">
				
				<div id="picplayer" style="position:relative;overflow:hidden;width:664px;height:297px;clear:none;border:solid 1px #ccc;"> 
				there is a pic-player 
				</div> 
					<script language="javascript" type="text/javascript">
					var p = $('#picplayer');
					var pics1 = [{ url: 'images/banner1.jpg', link: '#', time: 5000 }, { url: 'images/banner.jpg', link: '#', time: 4000 }, { url: 'images/banner2.jpg', link: '#', time: 6000 }, { url: 'images/banner1.jpg', link: '#', time: 5000 }]; 
					initPicPlayer(pics1,p.css('width').split('px')[0],p.css('height').split('px')[0]); 
					// 
					// 
					function initPicPlayer(pics,w,h) 
					{ 
					//选中的图片 
					var selectedItem; 
					//选中的按钮 
					var selectedBtn; 
					//自动播放的id 
					var playID; 
					//选中图片的索引 
					var selectedIndex; 
					//容器 
					var p = $('#picplayer'); 
					p.text(''); 
					p.append('<div id="piccontent"></div>'); 
					var c = $('#piccontent'); 
					for(var i=0;i<pics.length;i++) 
					{ 
					//添加图片到容器中 
					c.append('<a href="'+pics[i].link+'" target="_blank"><img id="picitem'+i+'" style="display: none;z-index:'+i+'" src="'+pics[i].url+'" /></a>'); 
					} 
					//按钮容器，绝对定位在右下角 
					p.append('<div id="picbtnHolder" style="position:absolute;top:'+(h-25)+'px;width:'+w+'px;height:16px;z-index:10000;"></div>'); 
					// 
					var btnHolder = $('#picbtnHolder'); 
					btnHolder.append('<div id="picbtns" style="float:right;"></div>'); 
					var btns = $('#picbtns'); 
					// 
					for(var i=0;i<pics.length;i++) 
					{ 
					//增加图片对应的按钮 
					btns.append('<span id="picbtn'+i+'" style="cursor:pointer; border:solid 1px #1D366F ;background-color:#fff; display:inline-block; width:16px; text-align:center"> '+(i+1)+' </span> '); 
					$('#picbtn'+i).data('index',i); 
					$('#picbtn'+i).click( 
					function(event) 
					{ 
					if(selectedItem.attr('src') == $('#picitem'+$(this).data('index')).attr('src')) 
					{ 
					return; 
					} 
					setSelectedItem($(this).data('index')); 
					} 
					); 
					} 
					btns.append(' '); 
					/// 
					setSelectedItem(0); 
					//显示指定的图片index 
					function setSelectedItem(index) 
					{ 
					selectedIndex = index; 
					clearInterval(playID); 
					//alert(index); 
					if(selectedItem)selectedItem.fadeOut('fast'); 
					selectedItem = $('#picitem'+index); 
					selectedItem.fadeIn('slow'); 
					// 
					if(selectedBtn) 
					{ 
					selectedBtn.css('backgroundColor','#eee'); 
					selectedBtn.css('color','#000'); 
					}  
					selectedBtn = $('#picbtn'+index); 
					selectedBtn.css('backgroundColor','#1D366F'); 
					selectedBtn.css('color','#fff'); 
					//自动播放 
					playID = setInterval(function() 
					{ 
					var index = selectedIndex+1; 
					if(index > pics.length-1)index=0; 
					setSelectedItem(index); 
					},pics[index].time); 
					} 
					} 
					
					
					
					</script> 
			</div>
			<div class="sub_list">
				<ul class="subMenu">
					<li class="thisStyle"><a href="javascript:void(0)">最新资讯</a></li>
					<li><a href="javascript:void(0)">推荐资讯</a></li>
				</ul>
				<div class="subContent">
					<ul style="display:block;">
						<li><span class="new_left"><a href="#">【商业大厦】</a> <a href="#">感恩回全场八折，买200元送600</a></span><span class="new_time">2012-11-11</span></li>
						<li><a href="#"><span class="new_left">【八佰伴】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【商业大厦】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【明泰百货】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【茂业百货】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【大洋百货】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【百盛】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【小店】 感恩回馈八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【万达店】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【大洋百货】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>

					</ul>
					<div style=" clear:both"></div>
					<ul>
						<li><a href="#"><span class="new_left">【商业大厦】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【明泰百货】 回馈only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【茂业百货】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【大洋百货】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【百盛】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【商业大厦】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【明泰百货】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【茂业百货】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【大洋百货】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
						<li><a href="#"><span class="new_left">【百盛】 感恩回馈，only全场八折，买200元送600</span><span class="new_time">2012-11-11</span></a></li>
					</ul>
					<div style=" clear:both"></div>					
				</div>
				<script>
					function $_class(name){
						var elements = document.getElementsByTagName("*");
						for(s=0;s<elements.length;s++){
							if(elements[s].className==name){
								return 	elements[s];
							}	
						}
					}
					//tab effects
					var tabList = $_class("subMenu").getElementsByTagName("li")
						tabCon = $_class("subContent").getElementsByTagName("ul");
					for(i=0;i<tabList.length;i++){
						(function(){
							var t = i;	  
							tabList[t].onclick = function(){
								for(o=0;o<tabCon.length;o++){
									tabCon[o].style.display = "none";
									tabList[o].className = "";
									if(t==o){
										this.className = "thisStyle";
										tabCon[o].style.display = "block";	
									}
								}
							}	
						})()	
					}
				</script>
			</div>
			<div style="clear:both"></div>
			<!-- 分类 开始 -->
			<div id="shopping">
				<div class="shopping_title">
					<span><a href="#">更 多</a></span>
				</div>
				<div class="shopping_part">
					<div class="sp_title">商场/专卖店</div>
					<ul>
						<li><span class="sp_left"><a href="#">【商厦】</a> <a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-31</span></li>
						<li><span class="sp_left"><a href="#">【商大厦】</a> <a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【是】</a> <a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">感恩回八折，买200元送600</a></span><span class="sp_time">01-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-16</span></li>
					</ul>
				</div>
				<div class="shopping_part">
					<div class="sp_title">特色小店</div>
					<ul>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-31</span></li>
						<li><span class="sp_left"><a href="#">【商大厦】</a> <a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【是】</a> <a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">感恩回八折，买200元送600</a></span><span class="sp_time">01-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-16</span></li>
					</ul>
				</div>
				<div class="shopping_right">
					<div class="sp_title">最近过期</div>
					<ul>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-31</span></li>
						<li><span class="sp_left"><a href="#">【商大厦】</a> <a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【是】</a> <a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">感恩回八折，买200元送600</a></span><span class="sp_time">01-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-16</span></li>
					</ul>
				</div>
				<div style="clear:both"></div>
			</div>
			<div id="shuma">
				<div class="shuma_title">
					<span><a href="#">更 多</a></span>
				</div>
				<div class="shuma_part">
					<ul class="list_r">
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600恩回全场八折，买200元送600恩回200元送600恩回</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600恩回全场八折，买</a></span><span class="sp_time">11-31</span></li>
						<li><span class="sp_left"><a href="#">【商大厦】</a> <a href="#">感恩回全场八折恩回全场八折，买，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【是】</a> <a href="#">感恩回全场八折恩回全场八折，买，买200元送600恩回200元送600恩回200元送600</a></span><span class="sp_time">11-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">感恩回八折，买2恩回全场八200元送600恩回200元送600恩回200元送600恩回折，买00元送600</a></span><span class="sp_time">01-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，200元送600恩回200元送600恩回200元送600恩回买200元送600</a></span><span class="sp_time">11-16</span></li>
					</ul>
					
					<ul>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600恩回全场八折，买200元送600恩回200元送600恩回</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600恩回全场八折，买</a></span><span class="sp_time">11-31</span></li>
						<li><span class="sp_left"><a href="#">【商大厦】</a> <a href="#">感恩回全场八折恩回全场八折，买，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【是】</a> <a href="#">感恩回全场八折恩回全场八折，买，买200元送600恩回200元送600恩回200元送600</a></span><span class="sp_time">11-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">感恩回八折，买2恩回全场八200元送600恩回200元送600恩回200元送600恩回折，买00元送600</a></span><span class="sp_time">01-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，200元送600恩回200元送600恩回200元送600恩回买200元送600</a></span><span class="sp_time">11-16</span></li>
					</ul>
				</div>
				<div style="clear:both"></div>
			</div>
			
			<div id="jjjc">
				<div class="jjjc_title">
					<span><a href="#">更 多</a></span>
				</div>
				<img src="images/jjjc.jpg" border="0" />
				<div class="jjjc_part">
					
					<ul>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600恩回全场八折，买200元送600恩回200元送600恩回</a></span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600恩回全场八折，买</a></span></li>
						<li><span class="sp_left"><a href="#">【商大厦】</a> <a href="#">感恩回全场八折恩回全场八折，买，买200元送600</a></span></li>
						<li><span class="sp_left"><a href="#">【是】</a> <a href="#">感恩回全场八折恩回全场八折，买，买200元送600恩回200元送600恩回200元送600</a></span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">感恩回八折，买2恩回全场八200元送600恩回200元送600恩回200元送600恩回折，买00元送600</a></span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，200元送600恩回200元送600恩回200元送600恩回买200元送600</a></span></li>
						<div style="clear:both"></div>
					</ul>
					
					<ul>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600恩回全场八折，买200元送600恩回200元送600恩回</a></span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600恩回全场八折，买</a></span></li>
						<li><span class="sp_left"><a href="#">【商大厦】</a> <a href="#">感恩回全场八折恩回全场八折，买，买200元送600</a></span></li>
						<li><span class="sp_left"><a href="#">【是】</a> <a href="#">感恩回全场八折恩回全场八折，买，买200元送600恩回200元送600恩回200元送600</a></span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">感恩回八折，买2恩回全场八200元送600恩回200元送600恩回200元送600恩回折，买00元送600</a></span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">回全场八折，买200元送600</a></span></li>
						<div style="clear:both"></div>
					</ul>
					<ul>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600恩回全场八折，买200元送600恩回200元送600恩回</a></span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600恩回全场八折，买</a></span></li>
						<li><span class="sp_left"><a href="#">【商大厦】</a> <a href="#">感恩回全场八折恩回全场八折，买，买200元送600</a></span></li>
						<li><span class="sp_left"><a href="#">【是】</a> <a href="#">感恩回全场八折恩回全场八折，买，买200元送600恩回200元送600恩回200元送600</a></span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">感恩回八折，买2恩回全场八200元送600恩回200元送600恩回200元送600恩回折，买00元送600</a></span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">回全场八折，买200元送600</a></span></li>
						<div style="clear:both"></div>
					</ul>
					<ul>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600恩回全场八折，买200元送600恩回200元送600恩回</a></span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600恩回全场八折，买</a></span></li>
						<li><span class="sp_left"><a href="#">【商大厦】</a> <a href="#">感恩回全场八折恩回全场八折，买，买200元送600</a></span></li>
						<li><span class="sp_left"><a href="#">【是】</a> <a href="#">感恩回全场八折恩回全场八折，买，买200元送600恩回200元送600恩回200元送600</a></span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">感恩回八折，买2恩回全场八200元送600恩回200元送600恩回200元送600恩回折，买00元送600</a></span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">回全场八折，买200元送600</a></span></li>
						<div style="clear:both"></div>
					</ul>
					
				</div>
				<div style="clear:both"></div>
			</div>
			<div id="food">
				<div class="food_title">
					<span><a href="#">更 多</a></span>
				</div>
				<div class="food_part">
					<div class="fd_title">
						<h2>异国美食</h2>
						<span><a href="#">更多 >> </a></span>
					</div>
					<ul>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-31</span></li>
						<li><span class="sp_left"><a href="#">【商大厦】</a> <a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【是】</a> <a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">感恩回八折，买200元送600</a></span><span class="sp_time">01-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-16</span></li>
					</ul>
				</div>
				<div class="food_part2">
					<div class="fd_title">
						<h2>特色小店</h2>
						<span><a href="#">更多</a></span>
					</div>
					<ul>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200感恩回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200感恩回全场八折，买200元送600</a></span><span class="sp_time">11-31</span></li>
						<li><span class="sp_left"><a href="#">【商大厦】</a> <a href="#">感恩回全场八折，买200感恩回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【是】</a> <a href="#">感恩感恩回全场八折，买200回全场八折，买200元送600</a></span><span class="sp_time">11-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">感恩感恩回全场八折，买200回八折，买200元送600</a></span><span class="sp_time">01-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">回全感恩回全场八折，买200感恩回全场八折，买200场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩感恩回全场八折，买200回全场八折，买200元送600</a></span><span class="sp_time">11-16</span></li>
						<div style="clear:both"></div>
					</ul>
					
				</div>
				<div class="food_part3">
					<div class="fd_title">
						<h2>最近过期</h2>
					</div>
					<ul>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-31</span></li>
						<li><span class="sp_left"><a href="#">【商大厦】</a> <a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【是】</a> <a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">感恩回八折，买200元送600</a></span><span class="sp_time">01-11</span></li>
						<li><span class="sp_left"><a href="#">【商】</a> <a href="#">回全场八折，买200元送600</a></span><span class="sp_time">12-11</span></li>
						<li><span class="sp_left"><a href="#">【商厦】</a><a href="#">感恩回全场八折，买200元送600</a></span><span class="sp_time">11-16</span></li>
					</ul>
				</div>
				<div style="clear:both"></div>
			</div>
			<div class="yqlj">
				<div class="yqlj_title">友情链接</div>
				<ul>
					<a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a><a href="#">安卓机锋网</a><a href="#">威锋网</a>
				</ul>
			</div>
		</div>
	</div>
	<!-- 尾部内容 -->
    <uc2:Foot ID="Foot1" runat="server" />
</body>
</html>
