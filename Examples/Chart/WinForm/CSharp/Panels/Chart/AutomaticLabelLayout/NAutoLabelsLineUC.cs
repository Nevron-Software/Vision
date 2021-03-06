using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAutoLabelsLineUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton GenerateDataButton;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableInitialPositioningCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableLabelAdjustmentCheck;
		private System.ComponentModel.Container components = null;

		public NAutoLabelsLineUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.GenerateDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.EnableInitialPositioningCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EnableLabelAdjustmentCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// GenerateDataButton
			// 
			this.GenerateDataButton.Location = new System.Drawing.Point(9, 9);
			this.GenerateDataButton.Name = "GenerateDataButton";
			this.GenerateDataButton.Size = new System.Drawing.Size(166, 24);
			this.GenerateDataButton.TabIndex = 4;
			this.GenerateDataButton.Text = "Generate Data";
			this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			// 
			// EnableInitialPositioningCheck
			// 
			this.EnableInitialPositioningCheck.ButtonProperties.BorderOffset = 2;
			this.EnableInitialPositioningCheck.Location = new System.Drawing.Point(9, 49);
			this.EnableInitialPositioningCheck.Name = "EnableInitialPositioningCheck";
			this.EnableInitialPositioningCheck.Size = new System.Drawing.Size(166, 21);
			this.EnableInitialPositioningCheck.TabIndex = 16;
			this.EnableInitialPositioningCheck.Text = "Enable Initial Positioning";
			this.EnableInitialPositioningCheck.CheckedChanged += new System.EventHandler(this.EnableInitialPositioningCheck_CheckedChanged);
			// 
			// EnableLabelAdjustmentCheck
			// 
			this.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2;
			this.EnableLabelAdjustmentCheck.Location = new System.Drawing.Point(9, 80);
			this.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck";
			this.EnableLabelAdjustmentCheck.Size = new System.Drawing.Size(166, 21);
			this.EnableLabelAdjustmentCheck.TabIndex = 15;
			this.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment";
			this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			// 
			// NAutoLabelsLineUC
			// 
			this.Controls.Add(this.EnableInitialPositioningCheck);
			this.Controls.Add(this.EnableLabelAdjustmentCheck);
			this.Controls.Add(this.GenerateDataButton);
			this.Name = "NAutoLabelsLineUC";
			this.Size = new System.Drawing.Size(180, 157);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];

			// configure Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// add interlaced stripe for Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.StripStyles.Add(stripStyle);

			// line series
			NLineSeries series1 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			series1.InflateMargins = true;
			series1.MarkerStyle.Visible = true;
			series1.MarkerStyle.FillStyle = new NColorFillStyle(DarkOrange);
			series1.MarkerStyle.PointShape = PointShape.Ellipse;
			series1.MarkerStyle.Width = new NLength(1.0f, NRelativeUnit.ParentPercentage);
			series1.MarkerStyle.Height = new NLength(1.0f, NRelativeUnit.ParentPercentage);

			series1.DataLabelStyle.Visible = true;
			series1.DataLabelStyle.VertAlign = VertAlign.Top;
			series1.DataLabelStyle.ArrowLength = new NLength(10);
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange;
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange;


			chart.LabelLayout.EnableInitialPositioning = true;
			chart.LabelLayout.EnableLabelAdjustment = true;

			series1.LabelLayout.EnableDataPointSafeguard = true;
			series1.LabelLayout.DataPointSafeguardSize = new NSizeL(
				new NLength(1.3f, NRelativeUnit.ParentPercentage),
				new NLength(1.3f, NRelativeUnit.ParentPercentage));
			series1.LabelLayout.UseLabelLocations = true;
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;
			series1.LabelLayout.InvertLocationsIfIgnored = true;

			// fill with random data
			GenerateData(series1);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// init form controls
			EnableInitialPositioningCheck.Checked = true;
			EnableLabelAdjustmentCheck.Checked = true;
		}

		void GenerateData(NSeries series)
		{
			series.Values.Clear();

			for (int i = 0; i < 30; i++)
			{
				double value = Math.Sin(i * 0.2) * 10 + Random.NextDouble() * 2;
				series.Values.Add(value);
			}
		}

		private void GenerateDataButton_Click(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSeries series = (NSeries)chart.Series[0];

			GenerateData(series);

			nChartControl1.Refresh();
		}

		private void EnableInitialPositioningCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheck.Checked;

			nChartControl1.Refresh();
		}

		private void EnableLabelAdjustmentCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheck.Checked;

			nChartControl1.Refresh();
		}
	}
}