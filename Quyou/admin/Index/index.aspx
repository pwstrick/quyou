<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Quyou.admin.Index.index" %>
<%@ Register src="../uc/DdlPlayCategory.ascx" tagname="DdlPlayCategory" tagprefix="uc1" %>
<!DOCTYPE HTML>
<html lang="en-US">
<head>
	<meta charset="UTF-8"/>
	<title>pwstrick</title>
	<link rel="stylesheet" href="../styles/2014/style.css" type="text/css"/>
	<script src="../../optimize/libs/modernizr/modernizr.js" type="text/javascript"></script>
	<script src="../../optimize/config.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="h90 w1080 mc pt30">
		<uc1:DdlPlayCategory ID="DdlPlayCategory1" runat="server" />
		<input type="text" class="w200"/><a href="javascript:void(0)" id="showKeyword">打开关键字</a>
	</div>
	<script src="../../optimize/libs/require/require.js" type="text/javascript" data-main="../../scripts/app/admin_index/main"></script>
    </form>
</body>
</html>
