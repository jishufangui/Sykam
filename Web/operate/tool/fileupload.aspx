<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fileupload.aspx.cs" Inherits="Web.operate.tool.fileupload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body style="margin:0px; padding:0px; background-color:White;">
    <form id="form1" runat="server" style="margin-top:0; vertical-align:top; display: inline-table; clip: rect(0px auto auto auto);">
      <asp:FileUpload ID="FileUpload1" runat="server" /> <asp:Button ID="Button1" runat="server" Text="上传" OnClick="Button1_Click"  CssClass="td4"/>
    </form>
</body>
</html>
