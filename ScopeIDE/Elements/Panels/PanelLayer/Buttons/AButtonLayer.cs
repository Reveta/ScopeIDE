using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Forms;
using ScopeIDE.libs;

namespace ScopeIDE.Elements.Panels.PanelLayer.Buttons {
    public abstract partial class AButtonLayer : AButtonColorDepend, IButtonLayer, IEventFormResize {
        public IDesignConfig DesignConfig { get; }
        public IButtonLayerController ButtonLayerController { get; }
        public UserControl _layerScreen;
        public TextBox NameBox;

        protected AButtonLayer(IDesignConfig designConfig, IButtonLayerController buttonLayerController) :
            base(designConfig.ColorConfig) {
            DesignConfig = designConfig;
            ButtonLayerController = buttonLayerController;

            UpdateLayerScreen();
            UpdateNameLabel();
        }

        protected virtual void UpdateNameLabel() {
            if (NameBox is null) {
                this.Text = "Layer";
                ConfigNameBox();
                this.Controls.Add(NameBox);
            }
            
            int xLevel = 0;
            int yLevel = DesignConfig.Resources.RetreatSize;
            if ((_layerScreen is not null)) {
                xLevel = (_layerScreen.Location.X + _layerScreen.Size.Width) + DesignConfig.Resources.RetreatSize;
            }

            NameBox.Location = new Point(xLevel, yLevel);
            NameBox.Height = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Height -
                               (DesignConfig.Resources.RetreatSize * 2);
            NameBox.Font = new Font(
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontName,
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontSize,
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontStyle);
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

            //updateLayerScreen
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

            if (_layerScreen != null) {
                UpdateLayerScreen();
            }

            if (NameBox != null) {
                UpdateNameLabel();
            }
        }
    }
}