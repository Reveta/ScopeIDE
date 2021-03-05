using System;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Panels {
    public partial class PanelNavbar : UserControl {
        public new Form ParentForm { get; set; }

        public IDesignConfig DesignConfig { get; set; }

        public PanelNavbar() {
            InitializeComponent();
            ParentForm = this.Parent as Form;
        }

        private void buttonNavbar10_Click(object sender, EventArgs e) {
            ParentForm.Close();
        }

        private void buttonNavbar9_Click(object sender, EventArgs e) {
            ParentForm.WindowState = FormWindowState.Maximized;
        }

        private void buttonNavbar8_Click(object sender, EventArgs e) {
            ParentForm.WindowState = FormWindowState.Minimized;
        }
    }
}