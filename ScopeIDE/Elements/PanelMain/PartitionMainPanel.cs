using System;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.PanelMain {
    public partial class PartitionMainPanel : ButtonColorDepend, IEventFormResize {
        public IDesignConfig DesignConfig { get; }

        public PartitionMainPanel(IDesignConfig designConfig) {
            DesignConfig = designConfig;

            InitializeComponent();
        }

        private void InitializeComponent() {
            this.SuspendLayout();

            base.Text = "|";
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor;
            this.ForeColor = DesignConfig.ColorConfig.ActiveBackColor;

            this.FlatStyle = FlatStyle.Flat;

            this.FlatAppearance.BorderSize = 0;
            this.Margin = new Padding(0);

            this.Size = new Size(
                DesignConfig.PanelMainConfig.Button.Width,
                DesignConfig.PanelMainConfig.Button.Height);

            this.TabStop = false;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.UseVisualStyleBackColor = false;
            this.AutoSize = false;

            this.ResumeLayout(false);
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

            DesignConfig.PanelMainConfig.Button.FontSize = DesignConfig.PanelMainConfig.Button.FontSizeDef / 100 * (coof + 100);

            DesignConfig.PanelMainConfig.Button.Width =
                (int) (DesignConfig.PanelMainConfig.Button.WidthDef / 100f * coof);

            DesignConfig.PanelMainConfig.Button.Height =
                (int) (DesignConfig.PanelMainConfig.Button.HeightDef / 100f * coof);

            this.Width = DesignConfig.PanelMainConfig.Button.Width;
            this.Height = DesignConfig.PanelMainConfig.Button.Height;
            this.Font = new Font(
                DesignConfig.PanelMainConfig.Button.FontName,
                this.Height / 2,
                DesignConfig.PanelMainConfig.Button.FontStyle
            );
        }

        protected override void OnClick(EventArgs e) { }

        protected override void OnMouseHover(EventArgs e) { }

        protected override void OnMouseEnter(EventArgs e) {}

        protected override void OnMouseLeave(EventArgs e) {}

        protected override void OnMouseUp(MouseEventArgs mevent) {}

        protected override void OnMouseMove(MouseEventArgs mevent) {}

        protected override void OnMouseDown(MouseEventArgs mevent) {}
    }
}