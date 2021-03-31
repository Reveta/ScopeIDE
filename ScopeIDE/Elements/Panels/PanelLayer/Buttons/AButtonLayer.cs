using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.Panels.PanelLayer.Buttons {
    public abstract class AButtonLayer : AButtonColorDepend, IButtonLayer, IEventFormResize {
        public IDesignConfig DesignConfig { get; }
        public IButtonLayerController ButtonLayerController { get; }
        public UserControl _layerScreen;

        protected AButtonLayer(IDesignConfig designConfig, IButtonLayerController buttonLayerController) :
            base(designConfig.ColorConfig) {
            DesignConfig = designConfig;
            BackColor = DesignConfig.ColorConfig.SecondBackColor;
            ButtonLayerController = buttonLayerController;

            UpdateLayerScreen();

            InitializeComponent();
        }

        protected abstract void UpdateLayerScreen();

        public void EventFormResize(Form form) {
            if (form is not IFormResizable formResizable) return;


            int coof = formResizable.Scales switch {
                EScales.HD => DesignConfig.Scale.HD,
                EScales.FullHD => DesignConfig.Scale.FullHD,
                EScales.DoubleHD => DesignConfig.Scale.DoubleHD,
                EScales.FourHD => DesignConfig.Scale.FourHD,
                _ => DesignConfig.Scale.FullHD
            };

            DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontSize =
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontSizeDef / 100 * coof;

            DesignConfig.PanelLayerConfig.ButtonLayerConfig.Height =
                (int) (DesignConfig.PanelLayerConfig.ButtonLayerConfig.HeightDef / 100f * coof);


            this.Width = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Width;
            this.Height = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Height;
            this.Font = new Font(
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontName,
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontSize,
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontStyle
            );

            UpdateLayerScreen();
        }
    }
}