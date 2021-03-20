using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Elements.Panels.PanelInstruments {
    public partial class ButtonTransform : Button {
        public readonly IDesignConfig DesignConfig;

        public ButtonTransform(IDesignConfig designConfig) {
            DesignConfig = designConfig;
            
            InitializeComponent();
        }

        private void InitializeComponent() {
            components = new System.ComponentModel.Container();

            // 
            // buttonTransform1
            // 
            this.Name = "buttonTransform1";
            this.BackColor = DesignConfig.ColorConfig.ThirdBackColor;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = FlatStyle.Flat;
            this.Font = new Font("Arial", 15.33333F, System.Drawing.FontStyle.Regular);
            this.ForeColor = DesignConfig.ColorConfig.FontColorMain;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Height = 30;
            this.TabIndex = 0;
            this.TabStop = false;
            this.UseVisualStyleBackColor = true;
        }

        public void SetBigStyle() {
            this.Width = this.Parent.Width;
            this.Text = "<<<";
        }

        public void SetSmallStyle() {
            this.Width = this.Parent.Width;
            this.Text = ">>>";
        }
    }
}