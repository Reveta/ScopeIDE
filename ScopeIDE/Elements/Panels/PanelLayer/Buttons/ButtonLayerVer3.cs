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