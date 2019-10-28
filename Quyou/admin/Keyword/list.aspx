﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="Quyou.admin.Keyword.list" %>
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
   <div class="mt10 ml10 mr10 mb10 f12" id="main">
		<uc1:DdlPlayCategory ID="DdlPlayCategory1" runat="server" />
		<input type="button" value="搜索" class="mr10 button_search"/>
		<div class="mt5 mb5">
			<select id="ddlParent">
				<option value="0">= 父级关键字类别 =</option>
			</select>
			<input type="text" id="currentType"/>
			<input type="button" value="添加关键字类别" class="mr10 add_keyword_type"/>
			<input type="button" value="修改关键字类别" class="mr10 edit_keyword_type"/>
			<input type="hidden" value="0" id="currentTypeId"/>
		</div>
		<div class="mt5">
		    <select id="ddlKeywordType">
				<option value="0">= 关键字类别 =</option>
			</select>
			<input type="text" id="currentWord"/>
			<input type="button" value="添加关键字" class="mr10 add_keyword"/>
			<input type="button" value="修改关键字" class="mr10 edit_keyword"/>
			<input type="hidden" value="0" id="currentWordId"/>
		</div>
		<div class="mt5"><input type="button" value="返回关键字" class="button_submit"/></div>
		<script type="text/template" id="tpl_keyword_list">
			<dl class="ovh lh30" id="keywords">
				{{#DataList}}
				<dt class="b cb">{{Name}}</dt>
				{{#Keywords}}
				<dd class="l mr20">
					<input type="checkbox" class="input_align" value="{{Name}}"/>{{Name}}
					<a href="#" class="brown1 a_orange1 ml5 edit" wordid="{{KeywordId}}" keyid="{{KeywordTypeId}}">修改</a>
					<a href="#" class="red1 a_orange1 ml5 del" wordid="{{KeywordId}}">删除</a>
				</dd>
				{{/Keywords}}
				{{/DataList}}
			</dl>
			<dl class="mt10 lh30 ovh" id="keyword_types">
				<dt class="b cb">关键字类别</dt>
				{{#DataList}}
				<dd class="l mr20">{{Name}}<a href="#" class="brown1 a_orange1 ml5 edit" keyid="{{KeywordTypeId}}" parentid="{{ParentTypeId}}">修改</a><a href="#" class="red1 a_orange1 ml5 del" keyid="{{KeywordTypeId}}">删除</a></dd>
				{{/DataList}}
			</dl>
		</script>
	</div>
	<script src="../../optimize/libs/require/require.js" type="text/javascript" data-main="../../scripts/app/admin_keyword/main"></script>
</body>
</html>
