<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NPuzzleAnimationUC" CodeFile="NPuzzleAnimationUC.ascx.vb" %>
<!-- Example layout BEGIN -->
<table id="exampleImageTable" style="width:730px; vertical-align: top;" summary="Image and description table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width:620px; height:650px; vertical-align:top;">
		<!-- Diagram control placeholder BEGIN 
			 The <object> tag is recognized by Internet Explorer, and Netscape recognizes the
			 <embed> tag and ignores the <object> tag.
		-->
		<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="620" height="620">
			<param name="movie" value="../Examples/Flash/NPuzzleAnimationRenderPage.aspx" />
			<embed src="../Examples/Flash/NPuzzleAnimationRenderPage.aspx" width="620" height="620" />
		</object>
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 100px;">
		<asp:Button Text="Replay" runat="server" />
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" style="vertical-align: top;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates the ability of Nevron Diagram for .NET to binary stream flash animations
		to the browser without generating a file on the server.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
