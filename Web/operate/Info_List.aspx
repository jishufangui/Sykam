<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info_List.aspx.cs" Inherits="Web.operate.Info_List"  ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/CheckBox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
                    <tr>
                        <td class="td_title" height="25">网站信息管理</td>
                    </tr>
                    <tr>
                        <td class="td4" style="height: 24px">
                            注意信息：管理网站信息时，操作时请谨慎。</td>
                    </tr>
                    <tr>
                        <td class="td5" height="23">
                            页面拓展：<a href="javascript:location.reload();">[刷新本页]</a>
                            <a href="InfoCate_Add.aspx">[添加频道]</a>
                            <a href="Info_List.aspx">[信息管理]</a>
                </td>
                    </tr>
                         </tr>
                         <tr>
                        <td class="td5" height="23">
                            搜索新闻：
                            <asp:TextBox ID="Tbx_keyword" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="Button2"
                                runat="server" CssClass="button5"   Text="搜索" UseSubmitBehavior="False" 
                                onclick="Button2_Click" /></td>
                    </tr>
                        <tr>
                        <td class="td5" height="23">
                            按类别搜索：           <asp:Literal   ID="L_CateTree" runat="server"></asp:Literal>&nbsp;<asp:Button ID="Button3"
                                runat="server" CssClass="button5"  Text="搜索" UseSubmitBehavior="False" OnClick="Button3_Click" /></td>
                    </tr>
                </table>
         <br />
            <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center" class="td4" width="100%">
                <tr>
                    <td style="height: 30px;" class="td_left">网站信息管理&nbsp;</td>
                </tr>
                <tr>
                    <td style="  height: 24px; width:100%" align="left" valign="top" >
                   <table style=" width:100%"><tr>
                   <td valign="top" style=" width:150px;"><iframe src="InfoCateTree.aspx" style="float:left;width:150px;min-height:280px; height:auto;" frameborder="0"></iframe></td>
                   <td valign="top" style=" width:auto; text-align:center"><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellSpacing="1" CellPadding="3"  BackColor="#CCCCCC" GridLines="None"  Width="100%" ForeColor="#333333" OnRowDeleting="GridView1_RowDeleting"   OnRowDataBound="GridView1_RowDataBound"  >
                            <Columns>
                                <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="chkAll" name="chkAll" onclick="CheckChange1()"  type="checkbox"/>
                            </HeaderTemplate>
                             <ItemTemplate>
                                 <asp:CheckBox ID="CheckBox1"  name="chk" runat="server" />
                             </ItemTemplate>
                                    <ItemStyle CssClass="td4line" />
                                           <ItemStyle CssClass="td4line" Width="6%" />
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SortID") %>' Width="20px"  BorderStyle="None" BackColor="white"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle CssClass="td4line" Width="6%" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtSort" runat="server" Text='<%# Bind("SortID") %>' Width="20px"  BorderStyle="None" BackColor="white"  Font-Underline="true"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="标题">
                                   
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("InfoTitle") %>'></asp:Label>
                                          <asp:HiddenField ID="H_InfoType" runat="server" Value='<%# Bind("InfoType") %>' />
                                          <asp:Literal ID="L_InfoType" runat="server"></asp:Literal>
                                          <asp:HiddenField ID="H_Recom" runat="server" Value='<%# Bind("IsRecom") %>' />
                                          <asp:Literal ID="L_Recom" runat="server"></asp:Literal>
                                          
                                    </ItemTemplate>
                                    <ItemStyle CssClass="td4line" Width="20%" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="所属栏目">
                                   
                                    <ItemTemplate>
                                          <asp:Literal ID="L_Node" runat="server"></asp:Literal>
                                          <asp:HiddenField ID="H_Node" runat="server" Value='<%# Bind("InfoCateID") %>' />
                                         
                                    </ItemTemplate>
                                    <ItemStyle CssClass="td4line" Width="10%" />
                                </asp:TemplateField>
                                 <asp:BoundField DataField="Admin_RealName" HeaderText="添加人" >
                                 <ItemStyle CssClass="td4line" Width="7%" />
                                  <ItemStyle  CssClass="td4line" />
                                </asp:BoundField>
                                     
                                  <asp:BoundField DataField="InfoAddTime" HeaderText="添加时间" >
                                  <ItemStyle  CssClass="td4line" />
                                   <ItemStyle CssClass="td4line" Width="10%" />
                                </asp:BoundField>
                                 <asp:TemplateField HeaderText="状态"  Visible="false">
                                 <ItemStyle CssClass="td4line" Width="6%" />
                                    <ItemStyle CssClass="td4line" />
                                    <ItemTemplate>
                                        <asp:Literal ID="L_check" runat="server"></asp:Literal>
                                         <asp:HiddenField ID="H_Check" runat="server" Value='<%# Bind("IsCheck") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="编辑频道">
                                    <ItemStyle CssClass="td4line" />
                                        <ItemStyle CssClass="td4line" Width="17%" />
                                    <ItemTemplate>
                                               <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("InfoID", "Info_Mod.aspx?id={0}") %>'
                                            Text="编辑信息"></asp:HyperLink>
                                            
                                            &nbsp; &nbsp;
                                       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return  confirm('确认删除?')"
                                            Text="删除信息"></asp:LinkButton>
                                           
                                                                                              
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <RowStyle BackColor="#EFF3FB" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                          <EditRowStyle BackColor="#2461BF" />
                          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" CssClass="td4line" />
                          <AlternatingRowStyle BackColor="White" />
                    
                        </asp:GridView> </td>
                     </tr></table>
                    
                    </td>
                </tr>
               <tr>
                <td align="center" style=" background-color:White;">
                    <asp:Literal ID="L_page" runat="server"></asp:Literal></td>
               </tr>
            </table>
            <br />
            <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center" style=" background-color:White;">
            <tr>
             <td  style="width:20%;">
                <ul style=" list-style:none;padding:0px">
                 <li style="float:left;padding:0px"><asp:Button ID="Button1" runat="server" Text="批量排序"  CssClass="button5" OnClick="Button1_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;</li>
                <li style="float:left;padding:0px"> <asp:ImageButton ID="ImageButton1" runat="server"  ImageUrl="~/operate/Images/skins/images/imgbuttom12.jpg" OnClick="ImageButton1_Click"  /></li>
                 </ul>
                 </td>
            </tr>
            </table>
    </form>
</body>
</html>
