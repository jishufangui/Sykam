<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_List.aspx.cs" Inherits="Web.operate.Admin_List" ValidateRequest="false" %>

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
                        <td class="td_title" height="25">管理员管理</td>
                    </tr>
                    <tr>
                        <td class="td4" style="height: 24px">
                            注意信息：管理商铺，操作时请谨慎。</td>
                    </tr>
                    <tr>
                        <td class="td5" height="23">
                            页面拓展：<a href="javascript:location.reload();">[刷新本页]</a>
                            <a href="Shop_Add.aspx">[添加管理员]</a>
                            <a href="Shop_List.aspx">[管理员列表]</a>
                </td>
                    </tr>
                   
                </table>
         <br />
            <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center" class="td4">
                <tr>
                    <td style="height: 30px;" class="td_left">管理员管理&nbsp;<asp:Label ID="lbl_CurrentNode" runat="server" ForeColor="#006600"></asp:Label></td>
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
                                <asp:TemplateField HeaderText="管理员账号">
                                   
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Admin_UID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="td4line" Width="15%" />
                                </asp:TemplateField>
                                        <asp:TemplateField HeaderText="状态">
                                    <ItemTemplate>
                                          <asp:Literal ID="L_stat" runat="server"></asp:Literal>
                                          <asp:HiddenField ID="H_stat" runat="server" Value='<%# Bind("Admin_Stat") %>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="td4line" Width="8%" />
                                </asp:TemplateField>
                                 <asp:BoundField DataField="Admin_LogTimes" HeaderText="登录次数" >
                                  <ItemStyle  CssClass="td4line" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Admin_RegTime" HeaderText="修改时间" >
                                  <ItemStyle  CssClass="td4line" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemStyle CssClass="td4line" />
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Admin_ID", "Admin_Mod.aspx?id={0}") %>'
                                            Text="编辑"></asp:HyperLink>
                                            &nbsp;&nbsp;
                                              <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("Admin_ID", "Admin_Password_Mod.aspx?id={0}") %>'
                                            Text="修改密码"></asp:HyperLink>
                                             &nbsp;&nbsp;
                                              <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# Eval("Admin_ID", "Competence_Mod.aspx?id={0}") %>'
                                            Text="修改权限"></asp:HyperLink>
                                            &nbsp;&nbsp;
                                               <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return  confirm('确认删除?')"
                                            Text="删除"></asp:LinkButton>
                                                    
                                        
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
                 <asp:Button ID="Button1" runat="server" Text="批量排序"  CssClass="button5" OnClick="Button1_Click"/>&nbsp;
                 <asp:Button ID="Button2" runat="server" Text="批量锁定"  CssClass="button5" 
                     onclick="Button2_Click" />&nbsp;
                 <asp:Button ID="Button3" runat="server" Text="批量解锁"  CssClass="button5" 
                     onclick="Button3_Click"  />
                 </td>
            </tr>
            </table>
    </form>
</body>
</html>
