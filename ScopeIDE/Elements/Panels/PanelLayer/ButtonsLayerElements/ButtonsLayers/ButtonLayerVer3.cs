using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements.ButtonsStates;

namespace ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements.ButtonsLayers {
    public partial class ButtonLayerVer3 : AButtonLayer {
        public ButtonLayerVer3(
            IDesignConfig designConfig,
            IButtonLayerController buttonLayerController) :
            base(designConfig, buttonLayerController,
                new ButtonLayerMainStateVer3(designConfig, buttonLayerController),
                new ButtonLayerEditingNameStateVer3(designConfig, buttonLayerController),
                new ButtonLayerEditingTransparencyState(designConfig, buttonLayerController
                )) {
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor; //TODO Why it`s not depend on base class??

            InitializeComponent();
        }

        internal sealed class ButtonLayerMainStateVer3 : ButtonLayerMainState {
            public ButtonLayerMainStateVer3(IDesignConfig designConfig, IButtonLayerController buttonLayerController) :
                base(designConfig, buttonLayerController) { }

            protected override void UpdateNameLabel() {
                base.UpdateNameLabel();
            }

            protected override void UpdateButtonHide() {
                base.UpdateButtonHide();
                ButtonHide.Size = LayerScreen.Size;
                ButtonHide.Location = new Point(
                    this.Width - ButtonHide.Width - DesignConfig.Resources.RetreatSize,
                    0);
                ButtonHide.Font = new Font(
                    ButtonHide.Font.FontFamily,
                    DesignConfig.Resources.FontSize,
                    ButtonHide.Font.Style
                );
            }

            protected override void UpdateLayerScreen() {
                base.UpdateLayerScreen();
                LayerScreen.Width = this.Height;
                LayerScreen.Height = this.Height;
                LayerScreen.Location = new Point(DesignConfig.Resources.RetreatSize, 0);

                var layerScreenBackgroundImage = ButtonLayerController.GetLayerScreen();
                LayerScreen.BackgroundImage = layerScreenBackgroundImage;
                LayerScreen.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        internal sealed class ButtonLayerEditingNameStateVer3 : ButtonLayerEditingNameState {
            public ButtonLayerEditingNameStateVer3(IDesignConfig designConfig,
                IButtonLayerController buttonLayerController) : base(designConfig, buttonLayerController) { }

            protected override void UpdateNameBox() {
                base.UpdateNameBox();

                DesignConfig.PanelLayerConfig.ButtonLayerConfig.Width =
                    DesignConfig.PanelLayerConfig.ButtonLayerConfig.WidthDef;
            }
        }
    }
}