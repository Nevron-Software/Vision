<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NPanelSelectorToolUC" CodeFile="NPanelSelectorToolUC.ascx.vb" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
		<ncwc:NThinChartControl ID="NThinChartControl1" runat="server" Width="420px" Height="320px"/>
		<!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The NPanelSelector tool allows you to dynamically change the currently active chart, which then becomes the target for tools suchs as the trackball tool, data zoom tool etc. <br />
		Press the mouse button over one of the pies. When that pie becomes the active one press again the mouse and start to drag - the currently active pie rotation and elevation properties will change dynamically.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
