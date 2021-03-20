using System;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Forms;
using ScopeIDE.Panels;

namespace ScopeIDE.Elements.Panels.PanelToolBoxs {
    public partial class ButtonToolBox : ButtonColorDepend, IEventFormResize {
        public IDesignConfig DesignConfig { get; }
        public UserControl Panel { get; }
        
        private string VerticalText { get; set; }

        public ButtonToolBox(string verticalText, IDesignConfig designConfig, UserControl panel) : base(designConfig.ColorConfig) {
            DesignConfig = designConfig;
            Panel = panel;
            
            this.VerticalText = verticalText;
            SetVerticalText(this);
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e) {
            if (Panel.Visible) {
                Panel.Hide();
            }
            else {
                Panel.Show();
            }

            base.OnClick(e);
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

            DesignConfig.PanelToolBox.Button.FontSize = DesignConfig.PanelToolBox.Button.FontSizeDef / 100 * coof;

            DesignConfig.PanelToolBox.Button.Width =
                (int) (DesignConfig.PanelToolBox.Button.WidthDef / 100f * coof);

            DesignConfig.PanelToolBox.Button.Height =
                (int) (DesignConfig.PanelToolBox.Button.HeightDef / 100f * coof);

            this.Width = DesignConfig.PanelToolBox.Button.Width;
            this.Height = DesignConfig.PanelToolBox.Button.Height;
            this.Font = new Font(
                DesignConfig.PanelToolBox.Button.FontName,
                DesignConfig.PanelToolBox.Button.FontSize,
                DesignConfig.PanelToolBox.Button.FontStyle
            );

            SetVerticalText(this);
        }

        private void SetVerticalText(Button button) {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;

            Bitmap img = new Bitmap(button.Height, button.Width);
            Graphics grap = Graphics.FromImage(img);

            grap.Clear(Color.Empty);

            SolidBrush brushText = new SolidBrush(button.ForeColor);
            grap.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            grap.DrawString(VerticalText, button.Font, brushText, new Rectangle(0, 0, img.Width, img.Height), format);
            brushText.Dispose();

            img.RotateFlip(RotateFlipType.Rotate270FlipNone);

            button.BackgroundImage = img;
        }
    }
}