﻿<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Themes/OrangeGrey/Styles.css" rel="stylesheet" type="text/css" />
</head>
<body onresize ="adjustRootDivSize()" onload = "adjustRootDivSize()">
<script type ="text/javascript" src="/Scripts/Scripts.js">	</script>
<div class="page" id="rootDiv" style="width: 746px; height: 10000px;">
<link href="../../Themes/OrangeGrey/Styles.css" rel="stylesheet" type="text/css" />
<%Html.RenderAction("TabContent", "NTab", new { title = "Welcome to Nevron Chart for MVC" });%>
<div id = "TabControl_MultiViewHolder" style="border-right: 1px solid rgb(155, 155, 155); overflow: auto;font-family:Tahoma; font-size: 11px;text-align:left;"">
<table style="width:100%;padding-bottom:10px;" summary="Splash image and keywords">
<tr>
	<td align = "center" >
		<p class="TextMain" ><b>Welcome to Nevron Chart</b><br/>
		<span class="TextSubMainSmall" >The industry leading Chart and Gauge component for WebForm and MVC applications.</span></p>
		<p class ="TextSubMain">Nevron Chart sets the standards for web based interactivity and feature richness delivered to your browser in pure, zero footprint HTML.</p>
	</td>
</tr>
<tr>
	<td align = "center" >
		<img alt="Nevron Chart for .NET" src="../Images/WelcomePage/splashImage.png" /><br />
	</td>
</tr>
</table>
<table style="width:100%;margin-bottom:10px;" summary="Featured examples">
<tr>
	<td colspan="5" style="margin-bottom:10px;text-align: left; font-size: large; color: #bbbbbb;">
		<span style="border-left:8px solid #EC7537;height:22px;vertical-align: -3px;"><span style="width:24px">&nbsp</span>Featured Examples<br />
	</td>
</tr>
<tr align = "center">
	<td>
		<a href="/Examples/Example?url=Tools/NDataZoomTool"><img alt="" src="../../Images/WelcomePage/th01.png" width="111" height="85" border="0" /></a>
	</td>
	<td>
		<a href="/Examples/Example?url=Tools/NTrackballTool"><img alt="" src="../../Images/WelcomePage/th02.png" width="112" height="85" border="0" /></a>
	</td>
	<td>
		<a href="/Examples/Example?url=Tools/NIndicatorDragTool"><img alt="" src="../../Images/WelcomePage/th05.png" width="111" height="85" border="0" /></a>
	</td>
</tr>
<tr class = "TextFeaturedExample" align = "center">
	<td>
		Data Zoom Tool
	</td>
	<td>
		Trackball Tool
	</td>
	<td>
		Indicator Drag Tool
	</td></tr>
</table>

<table style="font-family:Tahoma;width:100%;margin-bottom:10px;" summary="Links and contacts">
<tr>
	<td colspan="4" style="padding-bottom:10px;text-align: left; font-size: large; color: #bbbbbb">
		<span style="border-left:8px solid #EC7537;height:22px;vertical-align: -3px;"></span><span style="width:24px">&nbsp</span>Links & Contacts<br />
	</td>
</tr>
<tr>
	<td style="vertical-align: bottom;">
		<img alt="" src="../Images/WelcomePage/orangeBullet.png"  />&nbsp;&nbsp;<a style="color: #ec7135; " href="http://www.nevron.com" target="_blank">Nevron Home</a><br />
		<img alt="" src="../Images/WelcomePage/orangeBullet.png"  />&nbsp;&nbsp;<a style="color: #ec7135; " href="http://www.nevron.com/Products.ChartFor.NET.Overview.aspx" target="_blank">Nevron Chart for .NET Home</a><br />
		<img alt="" src="../Images/WelcomePage/orangeBullet.png"  />&nbsp;&nbsp;<a style="color: #ec7135; " href="http://www.nevron.com/Products.ChartFor.NET.FeatureList.aspx" target="_blank">Nevron Chart for .NET Editions</a><br />
	</td>
	<td style="vertical-align: bottom;">
		<img alt="" src="../Images/WelcomePage/orangeBullet.png"  />&nbsp;&nbsp;<a style="color: #ec7135; " href="http://www.nevron.com/Support.OnlineDocumentation.aspx" target="_blank">Nevron Online Documentation</a><br />
		<img alt="" src="../Images/WelcomePage/orangeBullet.png"  />&nbsp;&nbsp;<a style="color: #ec7135; " href="http://support.nevron.com/KB/search.aspx" target="_blank">Nevron Knowledge Base</a><br />
		<img alt="" src="../Images/WelcomePage/orangeBullet.png"  />&nbsp;&nbsp;<a style="color: #ec7135; " href="mailto:sales@nevron.com">Contact Nevron Sales Team</a><br />
		<img alt="" src="../Images/WelcomePage/orangeBullet.png"  />&nbsp;&nbsp;<a style="color: #ec7135; " href="mailto:support@nevron.com">Contact Nevron Support Team</a><br />
	</td>
	<td style="width:50%">&nbsp</td>
</tr>
</table>
</div>
</div>

</body>
</html>