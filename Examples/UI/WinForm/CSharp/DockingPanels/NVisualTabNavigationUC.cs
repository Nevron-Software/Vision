using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NVisualTabNavigationUC.
	/// </summary>
	public class NVisualTabNavigationUC : NDockingPanelsBasicFeaturesUC
	{
		#region Constructor

		public NVisualTabNavigationUC(MainForm f) : base(f)
		{
			InitializeComponent();
		}


		#endregion

		#region Overrides

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

		public override void Initialize()
		{
			base.Initialize ();

			m_ExampleFormType = typeof(NVisualTabNavigationForm);
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		#endregion
	}
}