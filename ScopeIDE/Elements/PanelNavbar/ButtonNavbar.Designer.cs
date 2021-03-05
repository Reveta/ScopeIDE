using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ScopeIDE.Elements.PanelNavbar {
    partial class ButtonNavbar {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            
            this.Size = new System.Drawing.Size(50, 20);
            this.Font = new Font("Arial", (float) 8, FontStyle.Regular);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Padding = new Padding(5, 0, 5,0);
            this.Margin = new Padding(5, 0, 5,0);
            this.BackColor = System.Drawing.Color.Gray;
            this.AutoSize = true;
        }

        #endregion
    }
}