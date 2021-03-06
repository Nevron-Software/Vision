<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NCustomScaleDecorationsUC" CodeFile="NCustomScaleDecorationsUC.ascx.vb" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
		<ncwc:NChartControl id="nChartControl1" runat="server" Width="420px" Height="320px">
		</ncwc:NChartControl>
		<!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<asp:Label id="Label1" runat="server">Hot Zone Begin:</asp:Label>
		<br />
		<asp:DropDownList id="HotZoneBeginDropDownList" runat="server" AutoPostBack="True" onselectedindexchanged="HotZoneBeginDropDownList_SelectedIndexChanged"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Cold Zone Begin:</asp:Label>
		<br />
		<asp:DropDownList id="ColdZoneEndDropDownList" runat="server" AutoPostBack="True" onselectedindexchanged="ColdZoneEndDropDownList_SelectedIndexChanged"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates how to custom program the scale of the axis. In this 
		example the scale definition is first created from the standard scale 
		configurator and then extended with a scale level containing custom titles, 
		ticks and horizontal scale separators.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
