using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStackFloatBarUC : NExampleBaseUC
	{
		private const int dataPointCount = 8;
		private Nevron.UI.WinForm.Controls.NButton PosDataButton;
		private Nevron.UI.WinForm.Controls.NButton PosNegDataButton;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox BarShapeCombo;
		private System.ComponentModel.IContainer components = null;

		public NStackFloatBarUC()
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.PosDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PosNegDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.BarShapeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// PosDataButton
			// 
			this.PosDataButton.Location = new System.Drawing.Point(6, 72);
			this.PosDataButton.Name = "PosDataButton";
			this.PosDataButton.Size = new System.Drawing.Size(162, 24);
			this.PosDataButton.TabIndex = 2;
			this.PosDataButton.Text = "Positive Data...";
			this.PosDataButton.Click += new System.EventHandler(this.PosDataButton_Click);
			// 
			// PosNegDataButton
			// 
			this.PosNegDataButton.Location = new System.Drawing.Point(6, 104);
			this.PosNegDataButton.Name = "PosNegDataButton";
			this.PosNegDataButton.Size = new System.Drawing.Size(162, 24);
			this.PosNegDataButton.TabIndex = 3;
			this.PosNegDataButton.Text = "Positive and Negative Data...";
			this.PosNegDataButton.Click += new System.EventHandler(this.PosNegDataButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Bar Shape:";
			// 
			// BarShapeCombo
			// 
			this.BarShapeCombo.ListProperties.CheckBoxDataMember = "";
			this.BarShapeCombo.ListProperties.DataSource = null;
			this.BarShapeCombo.ListProperties.DisplayMember = "";
			this.BarShapeCombo.Location = new System.Drawing.Point(8, 24);
			this.BarShapeCombo.Name = "BarShapeCombo";
			this.BarShapeCombo.Size = new System.Drawing.Size(160, 21);
			this.BarShapeCombo.TabIndex = 1;
			this.BarShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BarShapeCombo_SelectedIndexChanged);
			// 
			// NStackFloatBarUC
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BarShapeCombo);
			this.Controls.Add(this.PosNegDataButton);
			this.Controls.Add(this.PosDataButton);
			this.Name = "NStackFloatBarUC";
			this.Size = new System.Drawing.Size(180, 192);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Stack Float Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlaced stripe to the Y axis
            NLinearScaleConfigurator scaleY = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
            stripStyle.Interlaced = true;
			scaleY.StripStyles.Add(stripStyle);

            // setup the floatbar series
			NFloatBarSeries floatbar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatbar.MultiFloatBarMode = MultiFloatBarMode.Series;
			floatbar.Name = "Floatbar series";
			floatbar.FillStyle = new NColorFillStyle(Color.SandyBrown);
			floatbar.DataLabelStyle.Visible = false;

			// setup the bar series
			NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar1.Name = "Bar series";
			bar1.MultiBarMode = MultiBarMode.Stacked;
			bar1.FillStyle = new NColorFillStyle(Color.Green);
			bar1.DataLabelStyle.Visible = false;

			// setup the bar series
			NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar2.Name = "Bar series";
			bar2.MultiBarMode = MultiBarMode.Stacked;
			bar2.FillStyle = new NColorFillStyle(Color.CornflowerBlue);
			bar2.DataLabelStyle.Visible = false;

			GeneratePosData();

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// init form controls
			BarShapeCombo.FillFromEnum(typeof(BarShape));
			BarShapeCombo.SelectedIndex = 0;

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}

		private double GetRandValue(double min, double max)
		{
			if(max < min)
			{
				double temp = min;
				min = max;
				max = temp;
			}

			return min + Random.NextDouble() * (max - min);
		}

		private double SetRandSign(double val)
		{
			if(Random.NextDouble() > 0.5)
				return val;

			return  -val;
		}

		private void PosDataButton_Click(object sender, System.EventArgs e)
		{			
			GeneratePosData();
			nChartControl1.Refresh();
		}

		private void PosNegDataButton_Click(object sender, System.EventArgs e)
		{
			GeneratePosNegData();
			nChartControl1.Refresh();
		}

		private void GeneratePosData()
		{
			NFloatBarSeries floatbar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			NBarSeries bar1 = (NBarSeries)nChartControl1.Charts[0].Series[1];
			NBarSeries bar2 = (NBarSeries)nChartControl1.Charts[0].Series[2];

			floatbar.BeginValues.Clear();
			floatbar.EndValues.Clear();
			bar1.Values.Clear();
			bar2.Values.Clear();

			for(int i = 0; i < dataPointCount; i++)
			{
				floatbar.BeginValues.Add(GetRandValue(1, 4));
				floatbar.EndValues.Add(GetRandValue(6, 9));
				bar1.Values.Add(GetRandValue(3, 7));
				bar2.Values.Add(GetRandValue(3, 7));
			}
		}

		private void GeneratePosNegData()
		{
			NFloatBarSeries floatbar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			NBarSeries bar1 = (NBarSeries)nChartControl1.Charts[0].Series[1];
			NBarSeries bar2 = (NBarSeries)nChartControl1.Charts[0].Series[2];

			floatbar.BeginValues.Clear();
			floatbar.EndValues.Clear();
			bar1.Values.Clear();
			bar2.Values.Clear();

			for(int i = 0; i < dataPointCount; i++)
			{
				floatbar.BeginValues.Add(GetRandValue(-10, 10));
				floatbar.EndValues.Add(SetRandSign(GetRandValue(10, 20)));
				bar1.Values.Add(SetRandSign(GetRandValue(5, 10)));
				bar2.Values.Add(SetRandSign(GetRandValue(5, 10)));
			}
		}

		private void BarShapeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NFloatBarSeries floatbar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			NBarSeries bar1 = (NBarSeries)nChartControl1.Charts[0].Series[1];
			NBarSeries bar2 = (NBarSeries)nChartControl1.Charts[0].Series[2];

			BarShape selectedShape = (BarShape)BarShapeCombo.SelectedIndex;

			floatbar.BarShape = selectedShape;
			bar1.BarShape = selectedShape;
			bar2.BarShape = selectedShape;

			nChartControl1.Refresh();
		}
	}
}

