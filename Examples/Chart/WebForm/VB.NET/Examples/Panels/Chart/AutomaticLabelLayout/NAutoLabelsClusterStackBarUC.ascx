<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NAutoLabelsClusterStackBarUC" CodeFile="NAutoLabelsClusterStackBarUC.ascx.vb" %>
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
		<br />
		<asp:checkbox id="EnableInitialPositioningCheckBox" runat="server" AutoPostBack="True" Text="Enable Initial Positioning"></asp:checkbox>
		<br />
		<br />
		<asp:checkbox id="EnableLabelAdjustmentCheckBox" runat="server" AutoPostBack="True" Text="Enable Label Adjustment"></asp:checkbox>
		<br />
		<!-- Configuration controls panel placeholder END -->
		<asp:HiddenField ID="HiddenField1" runat="server" />
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		<p>
		The example demonstrates automatic data label layout for a cluster-stack bar chart.
		</p>
		<p>
		The two stages of the layout (initial positioning and adjustment) can be activated or deactivated independently using the respective check boxes.
		Initial positioning however takes effect only for the labels of the single bar series, because it is disabled for the two series in the stack.
		The labels of these series are initially positioned in the center of the bars and they can be shifted only by the "label adjustment" feature.
		The labels of the single bar series can be initially placed above or below their respective origin points.
		</p>
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
