using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements.ButtonsStates;

namespace ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements.ButtonsLayers {
    public partial class ButtonLayerVer2 : AButtonLayer {
        
        public ButtonLayerVer2(
            IDesignConfig designConfig,
            IButtonLayerController buttonLayerController) :
            base(designConfig, buttonLayerController,
                new ButtonLayerMainStateVer2(designConfig, buttonLayerController),
                new ButtonLayerEditingNameStateVer2(designConfig, buttonLayerController),
                new ButtonLayerEditingTransparencyState(designConfig, buttonLayerController)) {
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor; //TODO Why it`s not depend on base class??

            InitializeComponent();
        }

        internal sealed class ButtonLayerMainStateVer2 : ButtonLayerMainState {
            public ButtonLayerMainStateVer2(IDesignConfig designConfig, IButtonLayerController buttonLayerController) :
                base(designConfig, buttonLayerController) {
            }

            protected override void UpdateNameLabel() {
                base.UpdateNameLabel();
            }

            protected override void UpdateButtonHide() {
                base.UpdateButtonHide();
                ButtonHide.Font = new Font(
                    ButtonHide.Font.FontFamily,
                    DesignConfig.Resources.FontSize - 1,
                    ButtonHide.Font.Style
                );
            }

            protected override void UpdateLayerScreen() {
                base.UpdateLayerScreen();
                var retreat = DesignConfig.Resources.RetreatSize;

                LayerScreen.Width = this.Height - (retreat * 2);
                LayerScreen.Height = this.Height - (retreat * 2);
                LayerScreen.Location = new Point(retreat, retreat);

                var layerScreenBackgroundImage = ButtonLayerController.GetLayerScreen();
                LayerScreen.BackgroundImage = layerScreenBackgroundImage;
                LayerScreen.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        internal sealed class ButtonLayerEditingNameStateVer2 : ButtonLayerEditingNameState {
            public ButtonLayerEditingNameStateVer2(IDesignConfig designConfig,
                IButtonLayerController buttonLayerController)
                : base(designConfig, buttonLayerController) { }

            protected override void UpdateNameBox() {
                base.UpdateNameBox();
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.Width =
                    DesignConfig.PanelLayerConfig.ButtonLayerConfig.WidthDef;
            }
        }
    }
}