using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Elements.Panels.PanelMain;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.Panels.PanelLayer.Buttons {
    public abstract partial class AButtonLayer : AButtonColorDepend, IButtonLayer, IEventFormResize {
        protected IDesignConfig DesignConfig { get; }
        protected IButtonLayerController ButtonLayerController { get; }
        protected UserControl _layerScreen;
        protected UserControl _buttonHide;
        private TextBox NameBox;

        protected AButtonLayer(IDesignConfig designConfig, IButtonLayerController buttonLayerController) :
            base(designConfig.ColorConfig) {
            DesignConfig = designConfig;
            ButtonLayerController = buttonLayerController;

            UpdateLayerScreen();
            UpdateNameLabel();
            UpdateButtonFix();
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

        protected virtual void UpdateButtonFix() {
            if (_buttonHide == null) {
                _buttonHide = new UserControl() {
                    Text = "😁",
                    Name = "dsa"
                };
                this.Controls.Add(_buttonHide);
            }

            this.Font = new Font(
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontName,
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontSize,
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontStyle
            );

            var retreat = DesignConfig.Resources.RetreatSize;
            _buttonHide.Width = this.Height - retreat - retreat;
            _buttonHide.Height = this.Height - retreat - retreat;
            _buttonHide.Location = new Point(this.Width - _buttonHide.Width - retreat, retreat);
            
    
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

            if (_buttonHide != null) {
                UpdateButtonFix();
            }
        }
    }
}