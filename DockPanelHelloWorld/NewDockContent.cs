using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DockPanelHelloWorld {
    public partial class NewDockContent : WeifenLuo.WinFormsUI.Docking.DockContent {

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // NewDockContent
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "NewDockContent";
            this.ResumeLayout(false);
            
        }
    }
}