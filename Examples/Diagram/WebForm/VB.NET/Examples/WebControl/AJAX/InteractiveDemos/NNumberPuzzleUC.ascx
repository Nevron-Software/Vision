<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NNumberPuzzleUC" CodeFile="NNumberPuzzleUC.ascx.vb" %>
<%@ Register TagPrefix="ncwd" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 755px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 442px; vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<ncwd:NDrawingView id="NDrawingView1" runat="server" Width="416px" Height="336px" AjaxEnabled="True" AsyncAutoRefreshEnabled="False" AsyncCallbackTimeout="10000" AsyncRequestWaitCursorEnabled="False" OnQueryAjaxTools="NDrawingView1_QueryAjaxTools">
		</ncwd:NDrawingView>
		<!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 300px; font-size: 7pt;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<label for="mouseClickCheckbox"><input id="mouseClickCheckbox" name="mouseClickCheckbox" type="checkbox" onclick="UpdateState();" checked="CHECKED" /> Enable click (move a cell)</label><br />
		<label for="mouseDoubleClickCheckbox"><input id="mouseDoubleClickCheckbox" name="mouseDoubleClickCheckbox" type="checkbox" onclick="UpdateState();" /> Enable double click (reset the board)</label><br />
		<label for="mouseMoveCheckbox"><input id="mouseMoveCheckbox" name="mouseMoveCheckbox" type="checkbox" onclick="UpdateState();" /> Enable mouse move (hover effect)</label><br />
		<label for="mouseDownCheckbox"><input id="mouseDownCheckbox" name="mouseDownCheckbox" type="checkbox" onclick="UpdateState();" /> Enable mouse down (increase board size up to 7x7)</label><br />
		<label for="mouseUpCheckbox"><input id="mouseUpCheckbox" name="mouseUpCheckbox" type="checkbox" onclick="UpdateState();" /> Enable mouse up (decrease board size down to 2x2)</label><br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		Try to put all numbers in order, just like in the classical game from the days of yore!
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

<!-- Custom JavaScript placeholder BEGIN -->
<script type="text/javascript" language="javascript">
<!--
	function ReadState()
	{
		if(typeof(NDiagramCallbackService) == "undefined")
			return;
			
		var mouseClickCheckbox = document.getElementById("mouseClickCheckbox");
		var mouseDoubleClickCheckbox = document.getElementById("mouseDoubleClickCheckbox");
		var mouseMoveCheckbox = document.getElementById("mouseMoveCheckbox");
		var mouseDownCheckbox = document.getElementById("mouseDownCheckbox");
		var mouseUpCheckbox = document.getElementById("mouseUpCheckbox");
		
		//	The full hierarchical id of the diagram control must be used, e.g. "ctl04_NDrawingView1"
		//	rather than just "NDrawingView1". The "ctl05" is the id generated by the ASP.NET framework 
		//	for the user control hosting the diagram control.
		var cs = NDiagramCallbackService.GetCallbackService('ctl04_NDrawingView1');
		
		mouseClickCheckbox.checked = cs.controller.GetToolById(NMouseClickCallbackTool.GetClassName()).GetEnabled();
		mouseDoubleClickCheckbox.checked = cs.controller.GetToolById(NMouseDoubleClickCallbackTool.GetClassName()).GetEnabled();
		mouseMoveCheckbox.checked = cs.controller.GetToolById(NMouseMoveCallbackTool.GetClassName()).GetEnabled();
		mouseDownCheckbox.checked = cs.controller.GetToolById(NMouseDownCallbackTool.GetClassName()).GetEnabled();
		mouseUpCheckbox.checked = cs.controller.GetToolById(NMouseUpCallbackTool.GetClassName()).GetEnabled();
	}

	function UpdateState()
	{
		if(typeof(NDiagramCallbackService) == "undefined")
			return;
			
		var mouseClickCheckbox = document.getElementById("mouseClickCheckbox");
		var mouseDoubleClickCheckbox = document.getElementById("mouseDoubleClickCheckbox");
		var mouseMoveCheckbox = document.getElementById("mouseMoveCheckbox");
		var mouseDownCheckbox = document.getElementById("mouseDownCheckbox");
		var mouseUpCheckbox = document.getElementById("mouseUpCheckbox");
		
		//	The full hierarchical id of the diagram control must be used, e.g. "ctl04_NDrawingView1"
		//	rather than just "NDrawingView1". The "ctl05" is the id generated by the ASP.NET framework 
		//	for the user control hosting the diagram control.
		var cs = NDiagramCallbackService.GetCallbackService('ctl04_NDrawingView1');
		
		cs.controller.EnableTool(NMouseClickCallbackTool.GetClassName(), mouseClickCheckbox.checked);
		cs.controller.EnableTool(NMouseDoubleClickCallbackTool.GetClassName(), mouseDoubleClickCheckbox.checked);
		cs.controller.EnableTool(NMouseMoveCallbackTool.GetClassName(), mouseMoveCheckbox.checked);
		cs.controller.EnableTool(NMouseDownCallbackTool.GetClassName(), mouseDownCheckbox.checked);
		cs.controller.EnableTool(NMouseUpCallbackTool.GetClassName(), mouseUpCheckbox.checked);
	}

	ReadState();
//-->
</script>
<!-- Custom JavaScript placeholder END -->
