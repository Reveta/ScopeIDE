using System;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.PanelInstruments {
    public partial class ButtonInstrument : ButtonColorDepend, IEventFormResize {
        public IDesignConfig DesignConfig { get; }

        public ButtonInstrument(IDesignConfig designConfig) {
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

            DesignConfig.InstrumentPanel.Button.Width =
                (int) (DesignConfig.InstrumentPanel.Button.WidthDef / 100f * coof);
            
            DesignConfig.InstrumentPanel.Button.Height =
                (int) (DesignConfig.InstrumentPanel.Button.HeightDef / 100f * coof);

            this.Width = DesignConfig.InstrumentPanel.Button.Width;
            this.Height = DesignConfig.InstrumentPanel.Button.Height;
        }
    }
}