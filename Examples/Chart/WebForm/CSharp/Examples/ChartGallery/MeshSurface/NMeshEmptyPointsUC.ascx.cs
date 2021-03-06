using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NMeshEmptyPointsUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
            nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Mesh with Empty Data Points");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup legend
			NLegend legend =nChartControl1.Legends[0];
			legend.VerticalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.HorizontalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterBottomBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterLeftBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterRightBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterTopBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.FillStyle = new NColorFillStyle(Color.Transparent);
			legend.Data.MarkSize = new NSizeL(
				new NLength(8, NGraphicsUnit.Pixel),
				new NLength(8, NGraphicsUnit.Pixel));

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.Width = 70.0f;
			chart.Depth = 70.0f;
			chart.Height = 30.0f;

			if (IsPostBack)
			{
				chart.Projection.Rotation = (float)Convert.ToDouble(RotationTextBox.Text);
				chart.Projection.Elevation = (float)Convert.ToDouble(ElevationTextBox.Text);
			}
			else
			{
				RotationTextBox.Text = chart.Projection.Rotation.ToString();
				ElevationTextBox.Text = chart.Projection.Elevation.ToString();
				smoothShadingCheck.Checked = true;
			}

			// setup Y axis
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

			// setup X axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.RoundToTickMin = false;
			linearScaleConfigurator.RoundToTickMax = false;
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Back };
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator;

			// setup Z axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.RoundToTickMin = false;
			linearScaleConfigurator.RoundToTickMax = false;
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Left };
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator;

			// setup mesh surface series
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series.Add(SeriesType.MeshSurface);
			surface.Name = "Surface";
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			surface.FillMode = SurfaceFillMode.Zone;
			surface.PositionValue = 0.5;
			surface.Data.SetGridSize(20, 20);
			surface.SyncPaletteWithAxisScale = false;
			surface.PaletteSteps = 8;
			surface.ValueFormatter.FormatSpecifier = "0.0";

			FillDataXY(surface);

			if(smoothShadingCheck.Checked)
			{
				surface.ShadingMode = ShadingMode.Smooth;
			}
			else
			{
				surface.ShadingMode = ShadingMode.Flat;
			}

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, legend);
		}

		private void FillDataXY(NMeshSurfaceSeries surface)
		{
			double x, y, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 8.0;
			const double dIntervalZ = 8.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			for(int j = 0; j < nCountZ; j++)
			{
				for(int i = 0; i < nCountX; i++)
				{
					x = -(dIntervalX / 2) + (i * dIncrementX);
					z = -(dIntervalZ / 2) + (j * dIncrementZ);

					y = Math.Log( Math.Abs(x) * Math.Abs(z) );

					x += Math.Sin(j / 2.0) / 2.2;
					z += Math.Cos(i / 2.0) / 2.2;

					if(y > -7)
					{
						surface.Data.SetValue(i, j, y, x, z);
					}
					else
					{
						surface.Data.SetValue(i, j, DBNull.Value, DBNull.Value, DBNull.Value);
					}
				}
			}
		}
	}
}

