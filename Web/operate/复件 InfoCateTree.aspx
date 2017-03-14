<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoCateTree.aspx.cs" Inherits="Web.operate.InfoCateTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Scripts/jquery.treeview.css" />
    <link rel="stylesheet" href="screen.css" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/CheckBox.js"></script>
    <style type="text/css">
        html, body
        {
            height: 100%;
            margin: 0;
            padding: 0;
        }
        html > body
        {
            font-size: 16px;
            font-size: 68.75%;
        }
        /* Reset Base Font Size */
        body
        {
            font-family: Verdana, helvetica, arial, sans-serif;
            font-size: 68.75%;
            background: #fff;
            color: #333;
        }
        h1, h2
        {
            font-family: 'trebuchet ms' , verdana, arial;
            padding: 10px;
            margin: 0;
        }
        h1
        {
            font-size: large;
        }
        #banner
        {
            padding: 15px;
            background-color: #06b;
            color: white;
            font-size: large;
            border-bottom: 1px solid #ccc;
            background: url(bg.gif) repeat-x;
            text-align: center;
        }
        #banner a
        {
            color: white;
        }
        #main
        {
            padding: 1em;
        }
        a img
        {
            border: none;
        }
    </style>

    <script type="text/javascript" src="../Scripts/Library/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../Scripts/jquery.treeview.js"></script>

    <script type="text/javascript" src="../Scripts/jquery.cookie.js"></script>
     
</head>
<body>
    <form id="form1" runat="server">

    <script type="text/javascript">
        $(function() {
            $("#browser").treeview();
        });
    </script>

    <div>
        <ul id="browser" class="filetree">
          	<li><span class="folder"><a href='Info_List.aspx' target="_parent">根目录</a></span>
          	<ul>
            <asp:Literal ID="L_CateTree" runat="server"></asp:Literal>
            </ul>
           </li>
        </ul>
    </div>
    </form>
</body>
</html>
