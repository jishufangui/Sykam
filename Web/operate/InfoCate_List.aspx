<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoCate_List.aspx.cs" Inherits="Web.operate.InfoCate_List"  ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/CheckBox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
                    <tr>
                        <td class="td_title" height="25">网站频道管理</td>
                    </tr>
                    <tr>
                        <td class="td4" style="height: 24px">
                            注意信息：管理网站频道，类型无级别限制，操作时请谨慎。</td>
                    </tr>
                    <tr>
                        <td class="td5" height="23">
                            页面拓展：<a href="javascript:location.reload();">[刷新本页]</a>
                            <a href="InfoCate_Add.aspx">[添加频道]</a>
                            <a href="Info_List.aspx">[信息管理]</a>
                </td>
                    </tr>
                      
                </table>
         <br />
            <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center" class="td4">
                <tr>
                    <td style="height: 30px;" class="td_left">网站频道管理&nbsp;<asp:Label ID="lbl_CurrentNode" runat="server" ForeColor="#006600"></asp:Label></td>
                </tr>
                <tr>
                    <td style="padding:6px; height: 24px;" align="center" valign="top" >
                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellSpacing="1" CellPadding="3"  BackColor="#CCCCCC" GridLines="None"  Width="100%" ForeColor="#333333" OnRowDeleting="GridView1_RowDeleting"   OnRowDataBound="GridView1_RowDataBound"  >
                            <Columns>
                                <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="chkAll" name="chkAll" onclick="CheckChange1()"  type="checkbox"/>
                            </HeaderTemplate>
                             <ItemTemplate>
                                 <asp:CheckBox ID="CheckBox1"  name="chk" runat="server" />
                             </ItemTemplate>
                                    <ItemStyle CssClass="td4line" />
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SortID") %>' Width="20px"  BorderStyle="None" BackColor="white"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle CssClass="td4line" Width="10%" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtSort" runat="server" Text='<%# Bind("SortID") %>' Width="20px"  BorderStyle="None" BackColor="white"  Font-Underline="true"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="标题">
                                   
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("NodeName") %>'></asp:Label>
                                        
                                          <asp:HiddenField ID="H_Recom" runat="server" Value='<%# Bind("IsRecom") %>' />
                                          <asp:Literal ID="L_Recom" runat="server"></asp:Literal>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="td4line" Width="20%" />
                                </asp:TemplateField>
                                 <asp:BoundField DataField="Admin_RealName" HeaderText="添加人" >
                                  <ItemStyle  CssClass="td4line" />
                                </asp:BoundField>
                               
                                <asp:TemplateField HeaderText="删除频道">
                                    <ItemStyle CssClass="td4line" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return  confirm('确认删除?')"
                                            Text="删除"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="编辑频道">
                                    <ItemStyle CssClass="td4line" />
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("NodeId", "InfoCate_Mod.aspx?id={0}") %>'
                                            Text="编辑当前频道"></asp:HyperLink>
                                            &nbsp; &nbsp;
                                           <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("NodeId", "InfoCate_List.aspx?pid={0}") %>'
                                            Text="进入下级频道"></asp:HyperLink>    
                                            
                                            &nbsp;&nbsp;
                                                     <!--<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# Eval("NodeId", "InfoCate_Move.aspx?pid={0}") %>'  Text="移动当前类别"></asp:HyperLink>        -->
                                        
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
                    
                        </asp:GridView> 
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
                 <asp:Button ID="Button1" runat="server" Text="批量排序"  CssClass="button5" OnClick="Button1_Click"/></td>
            </tr>
            </table>
    </form>
</body>
</html>
