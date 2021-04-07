using System;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.Panels.PanelLayer.Buttons {
    public partial class ButtonLayer : AButtonLayer {
        public ButtonLayer(IDesignConfig designConfig, IButtonLayerController buttonLayerController) :
            base(designConfig, buttonLayerController) {
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor; //TODO Why it`s not depend on base class??

            InitializeComponent();
        }
        
        protected override void UpdateLayerScreen() {
            if (_layerScreen == null) {
                _layerScreen = new UserControl();
                this.Controls.Add(_layerScreen);
            }

            var retreat = DesignConfig.Resources.RetreatSize;
            
            _layerScreen.Width = this.Height;
            _layerScreen.Height = this.Height;
            _layerScreen.Location = new Point(retreat, 0);
            
            var layerScreenBackgroundImage = ButtonLayerController.GetLayerScreen();
            _layerScreen.BackgroundImage = layerScreenBackgroundImage;
            _layerScreen.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}