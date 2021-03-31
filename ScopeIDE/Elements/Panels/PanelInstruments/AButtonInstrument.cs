using System;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.Panels.PanelInstruments {
    public partial class AButtonInstrument : AButtonColorDepend, IEventFormResize {
        public IDesignConfig DesignConfig { get; }

        public AButtonInstrument(IDesignConfig designConfig) : base(designConfig.ColorConfig) {
            DesignConfig = designConfig;

            InitializeComponent();
        }

        protected override void OnClick(EventArgs e) {
            this.BackColor = ColorTranslator.FromHtml("#A30015");

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

            DesignConfig.PanelInstrument.Button.FontSize = DesignConfig.PanelInstrument.Button.FontSizeDef / 100 * coof;

            DesignConfig.PanelInstrument.Button.Width =
                (int) (DesignConfig.PanelInstrument.Button.WidthDef / 100f * coof);

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