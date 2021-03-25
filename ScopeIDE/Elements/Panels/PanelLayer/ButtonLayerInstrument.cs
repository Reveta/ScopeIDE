using System;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.Panels.PanelLayer {
    public partial class ButtonLayerInstrument : ButtonColorDepend, IButtonLayerInstrument, IEventFormResize {
        public IDesignConfig DesignConfig { get; }
 
        public ButtonLayerInstrument(IDesignConfig designConfig) : base(designConfig.ColorConfig) {
            DesignConfig = designConfig;

            InitializeComponent();
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

            DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.FontSize = DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.FontSizeDef / 100 * coof;

            DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Width =
                (int) (DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.WidthDef / 100f * coof);

            DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Height =
                (int) (DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.HeightDef / 100f * coof);

            this.Width = DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Width;
            this.Height = DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Height;
            this.Font = new Font(
                DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.FontName,
                DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.FontSize,
                DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.FontStyle
            );
        }
    }
}