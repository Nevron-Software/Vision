﻿using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NBubblePaletteUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBubbleSeries m_Bubble;

		public NBubblePaletteUC()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Bubble Palette";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates how to setup the bubble palette which allows you color the bubbles automatically based on their size.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Bubble Palette");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			NOrdinalScaleConfigurator ordinalScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// add a bubble series
			m_Bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			m_Bubble.DataLabelStyle.VertAlign = VertAlign.Center;
			m_Bubble.DataLabelStyle.Visible = false;
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bubble.Legend.Format = "Size <size>, Value <value>";
			m_Bubble.MinSize = new NLength(7.0f, NRelativeUnit.ParentPercentage);
			m_Bubble.MaxSize = new NLength(16.0f, NRelativeUnit.ParentPercentage);

			for (int i = 0; i < 10; i++)
			{
				m_Bubble.Values.Add(i);
				m_Bubble.Sizes.Add(i * 10 + 10);
			}

			m_Bubble.InflateMargins = true;

			NPalette palette = new NPalette();
			palette.SmoothPalette = true;
			palette.Clear();
			palette.Add(0, Color.Green);
			palette.Add(60, Color.Yellow);
			palette.Add(120, Color.Red);

			m_Bubble.Palette = palette;

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);
		}
	}
}