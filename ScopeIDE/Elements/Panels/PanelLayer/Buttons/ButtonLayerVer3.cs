using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;

namespace ScopeIDE.Elements.Panels.PanelLayer.Buttons {
    public partial class ButtonLayerVer3 : AButtonLayer {
        public ButtonLayerVer3(IDesignConfig designConfig, IButtonLayerController buttonLayerController) :
            base(designConfig, buttonLayerController) { 
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor; //TODO Why it`s not depend on base class??

            InitializeComponent();
        }

        protected override void UpdateButtonFix() {
            base.UpdateButtonFix();
            _buttonHide.Size = _layerScreen.Size;
            _buttonHide.Location = new Point(
                this.Width - _buttonHide.Width,
                0);
            _buttonHide.Font = new Font(
                _buttonHide.Font.FontFamily,
                DesignConfig.Resources.FontSize,
                _buttonHide.Font.Style
            );
        }

        protected override void UpdateLayerScreen() {
            if (_layerScreen == null) {
                _layerScreen = new UserControl();
                this.Controls.Add(_layerScreen);
            }

            _layerScreen.Width = this.Height;
            _layerScreen.Height = this.Height;
            _layerScreen.Location = new Point(0, 0);
            
            var layerScreenBackgroundImage = ButtonLayerController.GetLayerScreen();
            _layerScreen.BackgroundImage = layerScreenBackgroundImage;
            _layerScreen.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}