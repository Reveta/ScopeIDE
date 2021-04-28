using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;

namespace ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements.ButtonsStates {
    public class ButtonLayerMainState : UserControl, IButtonLayerState {
        protected IDesignConfig DesignConfig { get; }
        protected IButtonLayerController ButtonLayerController { get; }

        protected UserControl LayerScreen;
        private Label _name;
        protected Button ButtonHide;

        public ButtonLayerMainState(IDesignConfig designConfig, IButtonLayerController buttonLayerController) {
            DesignConfig = designConfig;
            ButtonLayerController = buttonLayerController;

            UpdateState();
        }

        public void UpdateState() {
            this.Height = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Height;
            this.Width = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Width;

            UpdateLayerScreen();
            UpdateButtonHide();
            UpdateNameLabel();
        }

        protected virtual void UpdateLayerScreen() {
            if (LayerScreen == null) {
                LayerScreen = new UserControl();
                this.Controls.Add(LayerScreen);
            }

            var retreat = DesignConfig.Resources.RetreatSize;

            LayerScreen.Width = this.Height;
            LayerScreen.Height = this.Height;
            LayerScreen.Location = new Point(retreat, 0);

            var layerScreenBackgroundImage = ButtonLayerController.GetLayerScreen();
            LayerScreen.BackgroundImage = layerScreenBackgroundImage;
            LayerScreen.BackgroundImageLayout = ImageLayout.Stretch;
        }

        protected virtual void UpdateNameLabel() {
            if (_name == null) {
                _name = new Label {
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                _name.DoubleClick += (sender, args) => ((IButtonLayer) this.Parent).ShowEditNameState();
                this.Controls.Add(_name);
            }

            _name.Text = ButtonLayerController.Name;

            var retreatSize = DesignConfig.Resources.RetreatSize;
            var xLevel = 0;
            var yLevel = 0;
            if ((LayerScreen is not null)) {
                xLevel = (LayerScreen.Location.X + LayerScreen.Size.Width) + retreatSize;
            }

            _name.Location = new Point(xLevel, yLevel);

            _name.Height = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Height;
            _name.Width = Width - xLevel - (Width - ButtonHide.Location.X + retreatSize);
            _name.Font = new Font(
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontName,
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontSize,
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontStyle);
        }

        protected virtual void UpdateButtonHide() {
            if (ButtonHide == null) {
                ButtonHide = new ButtonHide(DesignConfig, ButtonLayerController);
                ButtonHide.MouseDown += (sender, args) => {
                    if (args.Button is MouseButtons.Right ){
                        ((IButtonLayer) this.Parent).ShowEditTranspState();
                    }
                };
                //TODO Make new idea of UX
                this.Controls.Add(ButtonHide);
            }

            this.Font = new Font(
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontName,
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontSize,
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontStyle
            );

            var retreat = DesignConfig.Resources.RetreatSize;
            ButtonHide.Width = this.Height;
            ButtonHide.Height = this.Height;
            ButtonHide.Location = new Point(this.Width - ButtonHide.Width - retreat, 0);
        }
    }
}