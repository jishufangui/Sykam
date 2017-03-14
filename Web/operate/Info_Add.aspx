<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info_Add.aspx.cs" Inherits="Web.operate.Info_Add"  ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>网站后台管理系统</title>
     <link href="css/main.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="/Scripts/Library/jquery-1.7.1.min.js"></script>
      <script type="text/javascript" src="../Scripts/jquery.autocomplete.pack.js"></script>
      <link href="../Scripts/jquery.autocomplete.css" rel="stylesheet" type="text/css"/>
      <script language="javascript" type="text/javascript" src="../Scripts/Library/My97DatePicker/WdatePicker.js"></script>
     <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
     <script type="text/javascript" src="../ckfinder/ckfinder.js"></script>
     <script type="text/javascript">



         $(document).ready(

          function() {
              $("#tbx_ShopID").autocomplete("/operate/ajax/GetShop.aspx",
                     { max: 12,    //列表里的条目数
                         minChars: 0,    //自动完成激活之前填入的最小字符
                         width: 202,     //提示的宽度，溢出隐藏
                         scrollHeight: 300,   //提示的高度，溢出显示滚动条
                         matchContains: true,
                         autoFill: false,
                         dataType: 'json',
                         parse: function(data) {
                             var rows = [];
                             for (var i = 0; i < data.length; i++) {
                                 rows[rows.length] = {
                                     data: data[i],
                                     value: data[i].ShopID,
                                     result: data[i].ShopTitle
                                 };

                             }
                             return rows;
                         },
                         formatItem: function(row, i, max) { return row.ShopTitle; },
                         formatMatch: function(row) { return row; },
                         formatResult: function(row) { }
                     }

             ).result(function(event, data, formatted) { $("#h_shopid").val(data.ShopID); });



              $("#tbx_brand").autocomplete("/operate/ajax/GetBrand.aspx",
                     { max: 12,    //列表里的条目数
                         minChars: 0,    //自动完成激活之前填入的最小字符
                         width: 202,     //提示的宽度，溢出隐藏
                         scrollHeight: 300,   //提示的高度，溢出显示滚动条
                         matchContains: true,
                         autoFill: false,
                         dataType: 'json',
                         parse: function(data) {
                             var rows = [];
                             for (var i = 0; i < data.length; i++) {
                                 rows[rows.length] = {
                                     data: data[i],
                                     value: data[i].BrandID,
                                     result: data[i].BrandName
                                 };

                             }
                             return rows;
                         },
                         formatItem: function(row, i, max) { return row.BrandName; },
                         formatMatch: function(row) { return row; },
                         formatResult: function(row) { }
                     }

             ).result(function(event, data, formatted) { $("#h_brandid").val(data.BrandID); });


              $("#but_creatTag").click(
                     function() {
                         $.ajax(
                             {
                                 type: "POST",

                                 url: encodeURI("ajax/GetTag.aspx?title=" + $("#tbx_title").val()),
                                 success: function(msg) {
                                     $("#Tbx_tag").val(msg);
                                 }


                             }

                             );
                     }
              );



              $("#sel_SelInfoType").change(

                     function() {
                         if ($(this).val() == '2') {
                             $('.dazhe').hide();
                         }
                         else {

                             $('.dazhe').show();
                         }
                     }

              );

          }

         );
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
                    <tr>
                        <td class="td_title">添加信息</td>
                    </tr>
                    <tr>
                        <td class="td4">
                            注意信息：添加时选择正确的类别</td>
                    </tr>
                    <tr>
                        <td  class="td4" >
                            页面拓展：<a href="javascript:location.reload();">[刷新本页]</a>
                            <a href="javascript:history.back();">[返回上页]</a>
                            <a href="Shop_List.aspx">[信息列表]</a>
                        </td>
                    </tr>
                </table>
 <br />
            <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
                <tr>
                    <td colspan="2" class="td_left">添加信息</td>
                </tr>
                <tr>
                    <td align="center" class="td5" style="width:141px">信息类型</td>
                    <td align="left" class="td4">
                     <select id='sel_SelInfoType' name='sel_SelInfoType'>
                     <option value="1"> 新闻 </option>
                     <option value="2"> 产品 </option>
                     </select>
                     </td>
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
                    <td align="center" class="td5" style="width:10%">所属类别</td>
                    <td align="left" class="td4" ><asp:Literal ID="L_CateTree" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td align="center" class="td5" style="width:141px">标题名称</td>
                    <td align="left" class="td4">
                        <asp:TextBox ID="tbx_title" runat="server" 
                             ValidationGroup="2" Width="200px" Height="20px"></asp:TextBox>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbx_title"
                                        Display="Dynamic" ErrorMessage="必须输入信息标题" ValidationGroup="2"></asp:RequiredFieldValidator>&nbsp;请输入信息标题&nbsp; &nbsp;<input type="checkbox" id="Chk_tuijian" name="Chk_tuijian" value="true" /><span style=" color:Red;">作为推荐信息</span></td>
                </tr>
                 <tr>
                    <td align="center" class="td5" style="width:141px">Title</td>
                    <td align="left" class="td4">
                        <asp:TextBox ID="tbx_Etitle" runat="server" 
                             ValidationGroup="2" Width="200px" Height="20px"></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                 <tr>
                    <td align="center" class="td5" style="width:141px">内容简介</td>
                    <td align="left" class="td4">
                        <asp:TextBox ID="Tbx_SubMemo" runat="server" 
                             ValidationGroup="2" Width="200px" Height="57px" TextMode="MultiLine"></asp:TextBox>
                                    &nbsp; &nbsp; </td>
                </tr>
                 <tr>
                    <td align="center" class="td5" style="width:141px">信息内容</td>
                    <td align="left" class="td4">
                       <textarea name="content" id="ContentHolder" class="ckeditor"  rows="0" runat="server"></textarea> 
                        &nbsp;<br /><span  ><input type="checkbox" id="Chk_Remote" name="Chk_Remote" value="true" />获取远程图片</span></td>
                </tr>
                <tr>
                    <td align="center" class="td5" style="width: 141px">
                        信息图片</td>
                    <td align="left" class="td4"><select id="CatePic" name="CatePic"><option value="">无封面图片...</option></select><br /><input  type="hidden"  id="PicName" name="PicName" runat ="server"/> <iframe id="wfupload" src="tool/FileUpload.aspx?FileType=.gif/.jpeg/.bmp/.png/.jpg&MaxSize=5242880&SavePath=/uploadfile/Info/&UpInput=PicName" frameborder="0" scrolling="no" width="300em" height="25" style="height: 27px"></iframe>
    &nbsp;gif/jpeg/jpg/png/bmp 小于5M
                    </td>
                </tr>
                 <tr class='dazhe' >
                    <td align="center" class="td5" style="width: 141px">所属品牌</td>
                    <td align="left" class="td4"><asp:TextBox ID="tbx_brand"  runat="server" Text="暂无品牌信息"></asp:TextBox><input type="hidden" id="h_brandid" name="h_brandid"  value="-1"/></td>
                </tr>
              
                <tr class='dazhe' style="display:none">
                    <td align="center" class="td5" style="width: 141px">所属商家</td>
                    <td align="left" class="td4"><asp:TextBox ID="tbx_ShopID" runat="server" 
                             ValidationGroup="2" Width="200px" Text="暂无商家"></asp:TextBox><input type="hidden" id="h_shopid" name="h_shopid"  value="-1"/>
                                    &nbsp;</td>
                </tr>
                <tr class='dazhe' style="display:none">
                    <td align="center" class="td5" style="width: 141px">活动起始时间</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_BeginTime" runat="server" 
                             ValidationGroup="2" Width="200px" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate"></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                  <tr class='dazhe' style="display:none">
                    <td align="center" class="td5" style="width:141px">活动结束时间</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_EndTime" runat="server" 
                             ValidationGroup="2" Width="200px" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate"></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                   <tr>
                    <td align="center" class="td5" style="width: 141px">信息来源</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_from" runat="server" 
                              Width="200px" ></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                  <tr>
                    <td align="center" class="td5" style="width: 141px">添加人</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_Adder" runat="server" 
                              Width="200px" ReadOnly="true" ></asp:TextBox><asp:HiddenField ID="H_Adder"  runat="server"/>
                                    &nbsp;</td>
                </tr>
                
                <tr>
                    <td align="center" class="td5" style="width: 141px">添加时间</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_Addtime" runat="server" 
                              Width="200px" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate"></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                  <tr>
                    <td align="center" class="td5" style="width: 141px">点击数</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_clicknum" runat="server" 
                              Width="200px"  Text="0"></asp:TextBox>
                                    &nbsp;</td>
                </tr>
                  <tr>
                    <td align="center" class="td5" style="width: 141px">tag标签</td>
                    <td align="left" class="td4"><asp:TextBox ID="Tbx_tag" runat="server" 
                              Width="300px"   ></asp:TextBox>
                                    &nbsp;<input type="button"  class="button6" title="自动生成tag" value="自动生成tag"  id="but_creatTag" /></td>
                </tr>
                <tr>
                    <td colspan="2"  class="td_left"><asp:Button ID="Button1" runat="server" 
                            Text="未审核提交"   ValidationGroup="2" CssClass="button5" Width="107px" 
                            onclick="Button1_Click" Visible="false" />
                        &nbsp;<asp:Button ID="Button2" runat="server" Text="提交信息" 
                              ValidationGroup="2" CssClass="button5" Width="107px" 
                            onclick="Button2_Click" /> &nbsp;<input id="Reset1" type="reset" value="重填信息" style="width: 62px" class="button5" />&nbsp;
                    </td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
