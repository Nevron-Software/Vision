<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NFlowChartBuilderDemoUC" CodeFile="NFlowChartBuilderDemoUC.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 770px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 542px; vertical-align: top;">
		<!-- Diagram controls placeholder BEGIN -->
		<table style="width: 536px;">
		<tr>
			<td style="width: 536px; padding-bottom:7px;" colspan="2">
				<cc1:NDrawingView id="nDrawingViewToolbar" runat="server" Width="536px" Height="32px" AjaxEnabled="True" AsyncImageLoadTimeout="4000" AsyncRefreshEnabled="False" AsyncRequestWaitCursorEnabled="False" OnQueryAjaxTools="nDrawingViewToolbar_QueryAjaxTools" OnAsyncClick="nDrawingViewToolbar_AsyncClick">
				</cc1:NDrawingView>
			</td>
		</tr>
		<tr>
			<td style="width: 136px;">
				<div id="libraryScrollDiv" style="overflow: auto; width: 134px; height: 400px; border: solid 0px #d3d3d3;">
					<cc1:NDrawingView id="nDrawingViewLibrary" runat="server" Width="96px" Height="400px" AjaxEnabled="True" AsyncImageLoadTimeout="4000" OnQueryAjaxTools="nDrawingViewLibrary_QueryAjaxTools">
					</cc1:NDrawingView>
				</div>
			</td>
			<td style="width: 400px;">
				<div id="documentScrollDiv" style="overflow: auto; width: 398px; height: 400px; border: solid 0px #d3d3d3;">
					<cc1:NDrawingView id="nDrawingViewDocument" runat="server" Width="398px" Height="400px" AjaxEnabled="True" AsyncImageLoadTimeout="4000" OnQueryAjaxTools="nDrawingViewDocument_QueryAjaxTools" OnAsyncClick="nDrawingViewDocument_AsyncClick" OnAsyncCustomCommand="nDrawingViewDocument_AsyncCustomCommand" OnAsyncQueryCommandResult="nDrawingViewDocument_AsyncQueryCommandResult">
					</cc1:NDrawingView>
				</div>
			</td>
		</tr>
		</table>
		<!-- Diagram controls placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell">&nbsp;</td>
	<td id="exampleDescriptionCell" class="Description" style="width: 215px;">
		<!-- Description box placeholder BEGIN -->
		<p>
			This example demonstrates how to implement a simple online flow chart builder.
		</p>
		<p>
			To achieve this goal, three Nevron Diagram web controls are used: one for the
			toolbar, one for the library browser and one for the document designer.
			The following AJAX features are used:
		</p>
		<br />&nbsp;<br />
		- <b>Tooltip tool</b> - displays the tooltips over the toolbar buttons and
			the shapes in the library browser;
		<br />&nbsp;<br />
		- <b>Dynamic cursor tool</b> - changes the mouse cursor over all active elements;
		<br />&nbsp;<br />
		- <b>Dynamic image map</b> - filters the toolbar and library browser click events;
		<br />&nbsp;<br />
		- <b>Asynchronous click processing tool</b> - the main tool used to implement
			client-server interactivity;
		<br />&nbsp;<br />
		- <b>Client side click processing</b> - intercepts the mouse clicks over
			the "Change Shape Text" toolbar button and displays the text editor dialog;
		<br />&nbsp;<br />
		- <b>Asynchronous custom commands</b> - custom commands are sent to the
			server to implement the cross web control interaction;
		<br />&nbsp;<br />
		- <b>Nevron Instant Callback</b> - optimizes the loading time of the library browser.
		<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

<!-- Custom JavaScript placeholder BEGIN -->
<script type="text/javascript" language="javascript">
<!--
	//  sends an undo command to the server
	function Undo()
	{
		if(typeof(NDiagramCallbackService) == "undefined")
			return;
			
		//	The full hierarchical id of the diagram control must be used, e.g. "ctl04_nDrawingViewDocument"
		//	rather than just "nDrawingViewDocument". The "ctl05" is the id generated by the ASP.NET framework 
		//	for the user control hosting the diagram control.
		var cs = NDiagramCallbackService.GetCallbackService('ctl04_nDrawingViewDocument');
		
		cs.InvokeCustomCommand("undo", null);
	}

	//  sends a redo command to the server
	function Redo()
	{
		if(typeof(NDiagramCallbackService) == "undefined")
			return;
			
		//	The full hierarchical id of the diagram control must be used, e.g. "ctl04_nDrawingViewDocument"
		//	rather than just "nDrawingViewDocument". The "ctl05" is the id generated by the ASP.NET framework 
		//	for the user control hosting the diagram control.
		var cs = NDiagramCallbackService.GetCallbackService('ctl04_nDrawingViewDocument');
		
		cs.InvokeCustomCommand("redo", null);
	}
	
	//  sends a text command to the server
	function Text(text)
	{
		if(typeof(NDiagramCallbackService) == "undefined")
			return;
			
		//	The full hierarchical id of the diagram control must be used, e.g. "ctl04_nDrawingViewDocument"
		//	rather than just "nDrawingViewDocument". The "ctl05" is the id generated by the ASP.NET framework 
		//	for the user control hosting the diagram control.
		var cs = NDiagramCallbackService.GetCallbackService('ctl04_nDrawingViewDocument');
		
		var attributes = new Array();
		attributes["text"] = text;
		cs.InvokeCustomCommand("text", attributes);
	}
	
	//	displays a simple text editor
	function ShowTextEditor()
	{
		if(typeof(NDiagramCallbackService) == "undefined")
			return;

		var windowWidth = NBrowserCaps.GetWindowWidth();
		var windowHeight = NBrowserCaps.GetWindowHeight();
		var dialogWidth = 220;
		var dialogHeight = 93;
		var dialogLeft = (windowWidth - dialogWidth)/2;
		var dialogTop = (windowHeight - dialogHeight)/2;
		var dialogPadding = 3;

		var maskDiv = document.createElement("div");

		maskDiv.id = "maskDiv";
		maskDiv.style.position = "absolute";
		maskDiv.style.width = NBrowserCaps.ToPixelLength(windowWidth);
		maskDiv.style.height = NBrowserCaps.ToPixelLength(windowHeight);
		maskDiv.style.left = NBrowserCaps.ToPixelLength(0);
		maskDiv.style.top = NBrowserCaps.ToPixelLength(0);

		document.body.appendChild(maskDiv);
		
		var editorDialogDiv = document.createElement("div");

		editorDialogDiv.id = "editorDialogDiv";
		editorDialogDiv.style.position = "absolute";
		editorDialogDiv.style.width = NBrowserCaps.ToPixelLength(dialogWidth);
		editorDialogDiv.style.height = NBrowserCaps.ToPixelLength(dialogHeight);
		editorDialogDiv.style.left = NBrowserCaps.ToPixelLength(dialogLeft);
		editorDialogDiv.style.top = NBrowserCaps.ToPixelLength(dialogTop);
		editorDialogDiv.style.backgroundColor = "white";
		editorDialogDiv.style.border = "solid 1px black";
		editorDialogDiv.style.padding = String(dialogPadding) + "px";
		
		var html = "";
		html += "<center>";
		html += "<textarea id='textBox' rows='3' style='width: " + (dialogWidth - 2*dialogPadding) + "px'></textarea><br />"
		html += "<input type='button' value='Cancel' onclick='HideTextEditor();' />";
		html += "<input type='button' value='OK' onclick='Text(document.getElementById(\"textBox\").value);HideTextEditor();' />";
		html += "</center>";
		editorDialogDiv.innerHTML = html;

		document.body.appendChild(editorDialogDiv);
	}
	
	//	hides the simple text editor
	function HideTextEditor()
	{
		var maskDiv = document.getElementById("maskDiv");
		var editorDialogDiv = document.getElementById("editorDialogDiv");
		if(NReflection.IsInstance(editorDialogDiv))
			document.body.removeChild(editorDialogDiv);
		if(NReflection.IsInstance(maskDiv))
			document.body.removeChild(maskDiv);
	}
	
	//	intercepts the click event
	function MouseClick(self, eventTarget, pageOffset, screenOffset, localOffset)
	{
		//	processes click events only targeted at the images of the toolbar diagram control
		if(eventTarget.id.indexOf("ctl04_nDrawingViewToolbar") == -1)
			return false;
			
		//	assures that the JavaScript class NDiagramCallbackService is available,
		//	this way preventing JavaScript errors in cases, such as when a pending
		//	click event is being processed while the browser window is closing.
		if(typeof(NDiagramCallbackService) == "undefined")
			return false;
			
		//	The full hierarchical id of the diagram control must be used, e.g. "ctl04_nDrawingViewToolbar"
		//	rather than just "nDrawingViewToolbar". The "ctl05" is the id generated by the ASP.NET framework 
		//	for the user control hosting the diagram control.
		var cs = NDiagramCallbackService.GetCallbackService('ctl04_nDrawingViewToolbar');
		//  perform the hit test
		var imageMapObjectItem = cs.HitTest(eventTarget.id, localOffset);
		//  null as a return value means that no element with proper interactivity style was right-clicked
		if(imageMapObjectItem == null)
			return false;
		
		switch(imageMapObjectItem.userData)
		{
			case "undo":
				Undo();
				return true;
			case "redo":
				Redo();
				return true;
			case "text":
				ShowTextEditor();
				return true;
		}
		return false;
	}
	
	//  subscribe for the mouse click sevent
	NEventSinkService.MouseClick.Subscribe(null, MouseClick);
	
//-->
</script>
<!-- Custom JavaScript placeholder END -->
