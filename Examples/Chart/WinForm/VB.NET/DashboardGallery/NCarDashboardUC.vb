﻿Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WinForm

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NCarDashboardUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents m_Timer As System.Windows.Forms.Timer
		Private components As System.ComponentModel.IContainer
		Private GasScrollBar As Nevron.UI.WinForm.Controls.NVScrollBar

		Private m_Gear As Integer = 1
		Private m_Speed As Single = 0
		Private m_Rotation As Single = 0
		Private m_SpeedIndicator As NNeedleValueIndicator
		Private m_RotationIndicator As NNeedleValueIndicator

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If

				If m_Timer IsNot Nothing Then
					m_Timer.Stop()
					RemoveHandler m_Timer.Tick, AddressOf timer1_Tick
					m_Timer.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Car Dashboard")
			header.ContentAlignment = ContentAlignment.MiddleCenter
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.TextStyle.FillStyle = New NGradientFillStyle(Color.Black, Color.White)
			header.TextStyle.BorderStyle = New NStrokeStyle(Color.Gray)
			header.TextStyle.FontStyle.EmSize = New NLength(22)
			header.TextStyle.FontStyle.Style = FontStyle.Bold
			header.BoundsMode = BoundsMode.None
			header.UseAutomaticSize = False
			header.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			header.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(6, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(header)

			CreateSpeedGauge()
			CreateRPMGauge()

			nChartControl1.AutoRefresh = True

			m_Timer.Interval = 50
			m_Timer.Start()
		End Sub

		Private Sub CreateSpeedGauge()
			' create the radial gauge
			Dim radialGauge As New NRadialGaugePanel()

			radialGauge.PaintEffect = New NGlassEffectStyle()
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.BackgroundFillStyle = CreateAdvancedGradient()
			radialGauge.ContentAlignment = ContentAlignment.BottomRight
			radialGauge.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			radialGauge.Size = New NSizeL(New NLength(45, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			Dim label As New NLabel("km/h")
			label.ContentAlignment = ContentAlignment.BottomCenter
			label.TextStyle.FontStyle = New NFontStyle("Times New Roman", 20, FontStyle.Italic)
			label.TextStyle.FontStyle.Style = FontStyle.Italic
			label.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			label.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			label.BoundsMode = BoundsMode.Fit
			label.UseAutomaticSize = False
			label.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(7, NRelativeUnit.ParentPercentage))
			label.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(55, NRelativeUnit.ParentPercentage))
			label.Cache = True

			radialGauge.ChildPanels.Add(label)
			nChartControl1.Panels.Add(radialGauge)

			Dim axis As NGaugeAxis = DirectCast(radialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 250)

'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
			ConfigureScale(scale_Renamed, New NRange1DD(220, 260))
			radialGauge.Indicators.Add(CreateRangeIndicator(220))

			Dim indicator3 As New NMarkerValueIndicator()
			indicator3.Value = 90
			radialGauge.Indicators.Add(indicator3)

			m_SpeedIndicator = New NNeedleValueIndicator()
			m_SpeedIndicator.Value = 0
			m_SpeedIndicator.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_SpeedIndicator.Shape.StrokeStyle.Color = Color.Red
			radialGauge.Indicators.Add(m_SpeedIndicator)

			radialGauge.BeginAngle = -240
			radialGauge.SweepAngle = 300
		End Sub

		Private Function CreateAdvancedGradient() As NFillStyle
			Dim agfs As New NAdvancedGradientFillStyle()

			agfs.BackgroundColor = Color.FromArgb(234, 234, 234)

			Dim point1 As New NAdvancedGradientPoint()
			point1.X = 50
			point1.Y = 50
			point1.Color = Color.FromArgb(51, 51, 51)
			point1.Intensity = 70
			agfs.Points.Add(point1)

			Dim point2 As New NAdvancedGradientPoint()
			point2.X = 50
			point2.Y = 50
			point2.Color = Color.FromArgb(41, 41, 41)
			point2.Intensity = 50
			agfs.Points.Add(point2)

			Return agfs
		End Function

		Private Sub CreateRPMGauge()
			' create the radial gauge
			Dim radialGauge As New NRadialGaugePanel()

			radialGauge.PaintEffect = New NGlassEffectStyle()
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.BackgroundFillStyle = CreateAdvancedGradient()
			radialGauge.ContentAlignment = ContentAlignment.BottomRight
			radialGauge.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			radialGauge.Size = New NSizeL(New NLength(45, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			Dim label As New NLabel("RPM")
			label.ContentAlignment = ContentAlignment.BottomCenter
			label.TextStyle.FontStyle.Name = "Palatino Linotype"
			label.TextStyle.FontStyle.Style = FontStyle.Italic
			label.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			label.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			label.BoundsMode = BoundsMode.Fit
			label.UseAutomaticSize = False
			label.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(7, NRelativeUnit.ParentPercentage))
			label.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(55, NRelativeUnit.ParentPercentage))
			label.Cache = True

			radialGauge.ChildPanels.Add(label)
			nChartControl1.Panels.Add(radialGauge)

			Dim axis As NGaugeAxis = DirectCast(radialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 7000)

'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
			ConfigureScale(scale_Renamed, New NRange1DD(6000, 7000))
			radialGauge.Indicators.Add(CreateRangeIndicator(6000))

			m_RotationIndicator = New NNeedleValueIndicator()
			m_RotationIndicator.Value = 79
			m_RotationIndicator.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_RotationIndicator.Shape.StrokeStyle.Color = Color.Red
			radialGauge.Indicators.Add(m_RotationIndicator)

			radialGauge.BeginAngle = -240
			radialGauge.SweepAngle = 300
		End Sub

		Private Sub ConfigureScale(ByVal scale As NStandardScaleConfigurator, ByVal redRange As NRange1DD)
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 11, FontStyle.Bold)
			scale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			scale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			scale.MinorTickCount = 1
			scale.RulerStyle.BorderStyle.Width = New NLength(0)
			scale.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.SlateGray))

			Dim scaleSection As New NScaleSectionStyle()
			scaleSection.Range = redRange
			scaleSection.MajorTickFillStyle = New NColorFillStyle(Color.Red)
			scaleSection.MinorTickFillStyle = New NColorFillStyle(Color.Red)

			Dim labelStyle As New NTextStyle()
			labelStyle.FillStyle = New NGradientFillStyle(Color.Red, Color.DarkRed)
			labelStyle.FontStyle = New NFontStyle("Arial", 11, FontStyle.Bold)
			scaleSection.LabelTextStyle = labelStyle

			scale.Sections.Add(scaleSection)
		End Sub

		Private Function CreateRangeIndicator(ByVal minValue As Double) As NRangeIndicator
			Dim rangeIndicator As New NRangeIndicator()

			rangeIndicator.Value = minValue
			rangeIndicator.OriginMode = OriginMode.ScaleMax
			rangeIndicator.FillStyle = New NColorFillStyle(Color.Red)
			rangeIndicator.StrokeStyle.Width = New NLength(0)
			rangeIndicator.BeginWidth = New NLength(2)
			rangeIndicator.EndWidth = New NLength(10)

			Return rangeIndicator
		End Function

		Private Function GetSpeedFromRotation() As Single
			Select Case m_Gear
				Case 1
					Return m_Rotation * 0.005F
				Case 2
					Return m_Rotation * 0.01F
				Case 3
					Return m_Rotation * 0.015F
				Case 4
					Return m_Rotation * 0.02F
				Case 5
					Return m_Rotation * 0.034F
			End Select

			Return 0
		End Function

		Private Function GetRotationFromSpeed() As Single
			Select Case m_Gear
				Case 1
					Return m_Speed / 0.005F
				Case 2
					Return m_Speed / 0.01F
				Case 3
					Return m_Speed / 0.015F
				Case 4
					Return m_Speed / 0.02F
				Case 5
					Return m_Speed / 0.034F
			End Select

			Return 0
		End Function

		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_Timer.Tick
			m_Rotation += GasScrollBar.Value

			If m_Rotation < 0 Then
				m_Rotation = 0
			ElseIf m_Rotation > 7000 Then
				m_Rotation = 7000
			End If

			m_Speed = GetSpeedFromRotation()
			m_SpeedIndicator.Value = m_Speed

			' change gear
			If m_Rotation < 1000 Then
				m_Gear -= 1
			ElseIf m_Rotation > 3500 Then
				m_Gear += 1
			End If

			If m_Gear < 1 Then
				m_Gear = 1
			End If
			If m_Gear > 5 Then
				m_Gear = 5
			End If

			m_Rotation = GetRotationFromSpeed()
			m_RotationIndicator.Value = m_Rotation
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.GasScrollBar = New Nevron.UI.WinForm.Controls.NVScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.m_Timer = New System.Windows.Forms.Timer(Me.components)
			Me.SuspendLayout()
			' 
			' GasScrollBar
			' 
			Me.GasScrollBar.Location = New System.Drawing.Point(24, 16)
			Me.GasScrollBar.Maximum = 200
			Me.GasScrollBar.Minimum = -200
			Me.GasScrollBar.MinimumSize = New System.Drawing.Size(16, 32)
			Me.GasScrollBar.Name = "GasScrollBar"
			Me.GasScrollBar.Size = New System.Drawing.Size(16, 208)
			Me.GasScrollBar.TabIndex = 0
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(48, 200)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(80, 23)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Speed Up"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(48, 16)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(80, 23)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Slow Down"
			' 
			' timer1
			' 
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_Timer.Tick += new System.EventHandler(this.timer1_Tick);
			' 
			' NCarDashboardUC
			' 
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.GasScrollBar)
			Me.Name = "NCarDashboardUC"
			Me.Size = New System.Drawing.Size(180, 405)
			Me.ResumeLayout(False)

		End Sub
		#End Region
	End Class
End Namespace
