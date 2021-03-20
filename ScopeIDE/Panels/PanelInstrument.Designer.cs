using System.ComponentModel;
using System.Windows.Forms;

namespace ScopeIDE.Panels {
	partial class PanelInstrument {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private IContainer components = new System.ComponentModel.Container();

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}

			base.Dispose(disposing);
		}
	}
}