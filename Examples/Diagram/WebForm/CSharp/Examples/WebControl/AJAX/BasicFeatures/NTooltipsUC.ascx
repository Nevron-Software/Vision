<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NTooltipsUC" CodeFile="NTooltipsUC.ascx.cs" %>
<%@ Register TagPrefix="ncwd" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 769px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 520px; vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<ncwd:NDrawingView id="NDrawingView1" runat="server" Width="516px" Height="516px" AjaxEnabled="True" AsyncCallbackTimeout="10000" AjaxImageMapMode="Auto" OnQueryAjaxTools="NDrawingView1_QueryAjaxTools" AsyncRequestWaitCursorEnabled="False">
		</ncwd:NDrawingView>
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 249px;">
		<!-- Configuration controls panel placeholder BEGIN -->
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates the client side tooltip AJAX tool. Move the mouse over
        the periodic table to see the tooltips.<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->