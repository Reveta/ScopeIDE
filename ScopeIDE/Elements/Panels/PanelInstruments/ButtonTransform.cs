using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.Panels.PanelInstruments {
    public partial class ButtonTransform :  AButtonColorDepend, IEventFormResize {
        public readonly IDesignConfig DesignConfig;

        public ButtonTransform(IDesignConfig designConfig) : base(designConfig.ColorConfig) {
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
            this.Height = DesignConfig.PanelInstrument.Button.Height;
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

        public void EventFormResize(Form form) {
            if (form is not IFormResizable formResizable) return;

            int coof = formResizable.Scales switch {
                EScales.HD => DesignConfig.Scale.HD,
                EScales.FullHD => DesignConfig.Scale.FullHD,
                EScales.DoubleHD => DesignConfig.Scale.DoubleHD,
                EScales.FourHD => DesignConfig.Scale.FourHD,
                _ => DesignConfig.Scale.FullHD
            };

            DesignConfig.PanelInstrument.Button.Height =
                (int) (DesignConfig.PanelInstrument.Button.HeightDef / 100f * coof);

            this.Width = DesignConfig.PanelInstrument.Button.Width;
            this.Height = DesignConfig.PanelInstrument.Button.Height;
            this.Font = new Font(
                DesignConfig.PanelInstrument.Button.FontName,
                DesignConfig.PanelInstrument.Button.FontSize,
                DesignConfig.PanelInstrument.Button.FontStyle
            );
        }
    }
}