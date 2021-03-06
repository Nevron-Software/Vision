Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.GraphicsCore
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.UI.WebForm.Controls
Imports Nevron.Examples.Framework.WebForm

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NImageResponseUC.
	''' </summary>
	Public Partial Class NImageResponseUC
		Inherits NDiagramExampleUC
		#Region "Fields"

		Protected Document As Nevron.Diagram.NDrawingDocument

		#End Region

		#Region "Event handlers"

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not IsPostBack) Then
				ImageTypeDropDownList.Items.Add("PNG")
				ImageTypeDropDownList.Items.Add("JPEG")
				ImageTypeDropDownList.Items.Add("GIF")
				ImageTypeDropDownList.Items.Add("Bitmap")
				ImageTypeDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(JPEGQualityDropDownList, 10, 100, 10)
				JPEGQualityDropDownList.SelectedIndex = 9
			End If

			' start document initialization
			Document = NDrawingView1.Document

			Document.BeginInit()
			Document.Width = 800
			Document.Height = 700
			Document.Style.TextStyle.TextFormat = TextFormat.XML
			Document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None
			Document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None

			' configure shadow (inherited by all objects)
			Document.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(150, Color.Black), New Nevron.GraphicsCore.NPointL(3, 3), 1, New NLength(4))

			Document.ShadowsZOrder = ShadowsZOrder.BehindDocument

			' init scene
			CreateScene()

			' end document initialization
			Document.EndInit()

			NDrawingView1.Document = Document
			NDrawingView1.ViewLayout = CanvasLayout.Stretch

			Dim response As NImageResponse = New NImageResponse()

			JPEGQualityDropDownList.Enabled = False
			Select Case ImageTypeDropDownList.SelectedIndex
				Case 0 ' PNG
					response.ImageFormat = New NPngImageFormat()
				Case 1 ' JPEG
					Dim jpegImageFormat As NJpegImageFormat = New NJpegImageFormat()

					JPEGQualityDropDownList.Enabled = True
					jpegImageFormat.Quality = JPEGQualityDropDownList.SelectedIndex * 10 + 10
					response.ImageFormat = jpegImageFormat
				Case 2 ' GIF
					response.ImageFormat = New NGifImageFormat()
				Case 3 ' BMP
					response.ImageFormat = New NBitmapImageFormat()
			End Select

			NDrawingView1.ServerSettings.BrowserResponseSettings.DefaultResponse = response
		End Sub

		#End Region

		#Region "Implementation"

		Protected Sub CreateScene()
			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = False

			' configure title
			Dim title As NTextShape = New NTextShape("The Business Company", 0, 0, Document.Width, 60)
			Document.ActiveLayer.AddChild(title)

			Dim textStyle As NTextStyle = TryCast(title.ComposeTextStyle().Clone(), NTextStyle)
			textStyle.FontStyle.InitFromFont(New Font("Arial Black", 22, FontStyle.Bold Or FontStyle.Italic))

			' set gradient fill style
			textStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(241, 100, 34), Color.FromArgb(255, 247, 151))

			' add shadow
			textStyle.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(50, 122, 122, 122), New Nevron.GraphicsCore.NPointL(5, 5), 1, New NLength(3))

			title.Style.TextStyle = textStyle

			Dim personalInfos As NPersonalInfo() = NPersonalInfo.CreateCompanyInfo()


			' create an Org chart shape for each person in the Org chart
			Dim presidentShape As NCompositeShape = CreateOrgChartShape(personalInfos(0))

			Dim vpMarketingShape As NCompositeShape = CreateOrgChartShape(personalInfos(1))
			Dim vpSalesShape As NCompositeShape = CreateOrgChartShape(personalInfos(2))
			Dim vpProductionShape As NCompositeShape = CreateOrgChartShape(personalInfos(3))

			Dim mm01Shape As NCompositeShape = CreateOrgChartShape(personalInfos(4))
			Dim mm02Shape As NCompositeShape = CreateOrgChartShape(personalInfos(5))

			Dim sm01Shape As NCompositeShape = CreateOrgChartShape(personalInfos(6))
			Dim sm02Shape As NCompositeShape = CreateOrgChartShape(personalInfos(7))

			Dim pm01Shape As NCompositeShape = CreateOrgChartShape(personalInfos(8))
			Dim pm02Shape As NCompositeShape = CreateOrgChartShape(personalInfos(9))

			'	connect the Org chart shapes
			' 1. President to VPs
			Dim ge As NShape = Nothing
			ge = New NStep3Connector(True, 50, 0, True)
			Document.ActiveLayer.AddChild(ge)
			ge.StartPlug.Connect(TryCast(presidentShape.Ports.GetChildByName("Bottom", 0), NPort))
			ge.EndPlug.Connect(TryCast(vpMarketingShape.Ports.GetChildByName("Top", 0), NPort))

			ge = New NStep3Connector(True, 50, 0, True)
			Document.ActiveLayer.AddChild(ge)
			ge.StartPlug.Connect(TryCast(presidentShape.Ports.GetChildByName("Bottom", 0), NPort))
			ge.EndPlug.Connect(TryCast(vpSalesShape.Ports.GetChildByName("Top", 0), NPort))

			ge = New NStep3Connector(True, 50, 0, True)
			Document.ActiveLayer.AddChild(ge)
			ge.StartPlug.Connect(TryCast(presidentShape.Ports.GetChildByName("Bottom", 0), NPort))
			ge.EndPlug.Connect(TryCast(vpProductionShape.Ports.GetChildByName("Top", 0), NPort))

			' 1. VPs to managers
			ge = New NStep2Connector(True)
			Document.ActiveLayer.AddChild(ge)
			ge.StartPlug.Connect(TryCast(vpMarketingShape.Ports.GetChildByName("Bottom", 0), NPort))
			ge.EndPlug.Connect(TryCast(mm01Shape.Ports.GetChildByName("Left", 0), NPort))

			ge = New NStep2Connector(True)
			Document.ActiveLayer.AddChild(ge)
			ge.StartPlug.Connect(TryCast(vpMarketingShape.Ports.GetChildByName("Bottom", 0), NPort))
			ge.EndPlug.Connect(TryCast(mm02Shape.Ports.GetChildByName("Left", 0), NPort))

			ge = New NStep2Connector(True)
			Document.ActiveLayer.AddChild(ge)
			ge.StartPlug.Connect(TryCast(vpSalesShape.Ports.GetChildByName("Bottom", 0), NPort))
			ge.EndPlug.Connect(TryCast(sm01Shape.Ports.GetChildByName("Left", 0), NPort))

			ge = New NStep2Connector(True)
			Document.ActiveLayer.AddChild(ge)
			ge.StartPlug.Connect(TryCast(vpSalesShape.Ports.GetChildByName("Bottom", 0), NPort))
			ge.EndPlug.Connect(TryCast(sm02Shape.Ports.GetChildByName("Left", 0), NPort))

			ge = New NStep2Connector(True)
			Document.ActiveLayer.AddChild(ge)
			ge.StartPlug.Connect(TryCast(vpProductionShape.Ports.GetChildByName("Bottom", 0), NPort))
			ge.EndPlug.Connect(TryCast(pm01Shape.Ports.GetChildByName("Left", 0), NPort))

			ge = New NStep2Connector(True)
			Document.ActiveLayer.AddChild(ge)
			ge.StartPlug.Connect(TryCast(vpProductionShape.Ports.GetChildByName("Bottom", 0), NPort))
			ge.EndPlug.Connect(TryCast(pm02Shape.Ports.GetChildByName("Left", 0), NPort))
		End Sub

		Protected Function CreateOrgChartShape(ByVal info As NPersonalInfo) As NCompositeShape
			Dim bounds As NRectangleF = info.Bounds
			Dim bottomPortAlignment As Single = info.BottomPortAlignment
			Dim photo As Bitmap = New Bitmap(Me.MapPathSecure(info.Picture))

			' compose a new graph vertex from a frame and an image
			Dim frame As NRectanglePath = New NRectanglePath(bounds)
			Dim image As NRectanglePath = New NRectanglePath(New NPointF(bounds.X + 5, bounds.Y+ 5), New NSizeF(photo.Size))
			NStyle.SetFillStyle(image,New NImageFillStyle(photo, &Hff))

			Dim shape As NCompositeShape = New NCompositeShape()
			shape.Primitives.AddChild(frame)
			shape.Primitives.AddChild(image)
			shape.UpdateModelBounds()
			Document.ActiveLayer.AddChild(shape)

			' set the vertex fill style
			Dim fillStyle As NColorFillStyle = Nothing
			Select Case info.Level
				Case 0
					fillStyle = New NColorFillStyle(Color.FromArgb(241, 100, 34))
				Case 1
					fillStyle = New NColorFillStyle(Color.FromArgb(249, 167, 26))
				Case 2
					fillStyle = New NColorFillStyle(Color.FromArgb(255, 247, 151))
			End Select

			fillStyle.ImageFiltersStyle.Filters.Add(New NLightingImageFilter())
			shape.Style.FillStyle = fillStyle

			' add a new label for the person name
			Dim nameLabel As NRotatedBoundsLabel = New NRotatedBoundsLabel(info.Name, shape.UniqueId, New Nevron.Diagram.NMargins(40, 1, 50, 1))
			shape.Labels.AddChild(nameLabel)
			NStyle.SetTextStyle(nameLabel, TryCast(nameLabel.ComposeTextStyle().Clone(), NTextStyle))
			nameLabel.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Right
			nameLabel.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Top

			' configure default label (used for the person position)
			Dim positionLabel As NRotatedBoundsLabel = TryCast(shape.Labels.DefaultLabel, NRotatedBoundsLabel)
			NStyle.SetTextStyle(positionLabel, TryCast(positionLabel.ComposeTextStyle().Clone(), NTextStyle))
			positionLabel.Style.TextStyle.FontStyle.InitFromFont(New Font("Arial", 10, FontStyle.Bold))
			positionLabel.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Right
			positionLabel.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Bottom
			positionLabel.Margins = New Nevron.Diagram.NMargins(40, 5, 1, 50)
			positionLabel.Text = info.Position

			' create the optional ports of the shape
			shape.CreateShapeElements(ShapeElementsMask.Ports)

			' add rotated bounds ports
			Dim leftPort As NPort = New NRotatedBoundsPort(shape.UniqueId, New NContentAlignment(ContentAlignment.MiddleLeft))
			leftPort.Name = "Left"
			shape.Ports.AddChild(leftPort)

			Dim rightPort As NPort = New NRotatedBoundsPort(shape.UniqueId, New NContentAlignment(ContentAlignment.MiddleRight))
			rightPort.Name = "Right"
			shape.Ports.AddChild(rightPort)

			Dim topPort As NPort = New NRotatedBoundsPort(shape.UniqueId, New NContentAlignment(ContentAlignment.TopCenter))
			topPort.Name = "Top"
			shape.Ports.AddChild(topPort)

			Dim bottomPort As NRotatedBoundsPort = New NRotatedBoundsPort(shape.UniqueId, New NContentAlignment(bottomPortAlignment, 50))
			bottomPort.Name = "Bottom"
			shape.Ports.AddChild(bottomPort)

			Return shape
		End Function

		#End Region
	End Class
End Namespace
