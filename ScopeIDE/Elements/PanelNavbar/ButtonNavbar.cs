using System.Windows.Forms;

namespace ScopeIDE.Elements.PanelNavbar {
    public partial class ButtonNavbar : Button {
        public ButtonNavbar() {
            InitializeComponent();
            SetStyle();
        }
        
        private void SetStyle() {
            /*TODO do not work*/
            
            /*Clean border*/
            base.TabStop = false;
            base.FlatStyle = FlatStyle.Flat;
            base.FlatAppearance.BorderSize = 0;

            /*Set style*/
            // this.BackColor = Color.DimGray;
        }

    }
}