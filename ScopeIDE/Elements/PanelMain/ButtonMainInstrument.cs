using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.PanelMain {
    public partial class ButtonMainInstrument : ButtonColorDepend, IEventFormResize {
        public IDesignConfig DesignConfig { get; }

        public ButtonMainInstrument(IDesignConfig designConfig) {
            DesignConfig = designConfig;

            InitializeComponent();
        }

        private void InitializeComponent() {
            this.SuspendLayout();

            this.Height = DesignConfig.PanelMainConfig.HeightDef;
            this.Width = DesignConfig.PanelMainConfig.WidthDef;
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

            DesignConfig.PanelMainConfig.Button.Width =
                (int) (DesignConfig.PanelMainConfig.Button.WidthDef / 100f * coof);
            
            DesignConfig.PanelMainConfig.Button.Height =
                (int) (DesignConfig.PanelMainConfig.Button.HeightDef / 100f * coof);

            this.Width = DesignConfig.PanelMainConfig.Button.Width;
            this.Height = DesignConfig.PanelMainConfig.Button.Height;
        }
    }
}