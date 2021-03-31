using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.Panels.PanelLayer.Buttons {
    public partial class ButtonLayerVer2 : AButtonLayer {

        public ButtonLayerVer2(IDesignConfig designConfig, IButtonLayerController buttonLayerController) :
            base(designConfig, buttonLayerController) {
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor; //TODO Why it`s not depend on base class??

            UpdateLayerScreen();

            InitializeComponent();
        }

        protected override void UpdateLayerScreen() {
            if (_layerScreen == null) {
                _layerScreen = new UserControl();
                this.Controls.Add(_layerScreen);
            }

            var retreat = DesignConfig.Resources.RetreatSize;
            
            _layerScreen.Width = this.Height - (retreat * 2);
            _layerScreen.Height = this.Height - (retreat * 2);
            _layerScreen.Location = new Point(retreat, retreat);

            var layerScreenBackgroundImage = ButtonLayerController.GetLayerScreen();
            _layerScreen.BackgroundImage = layerScreenBackgroundImage;
            _layerScreen.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}