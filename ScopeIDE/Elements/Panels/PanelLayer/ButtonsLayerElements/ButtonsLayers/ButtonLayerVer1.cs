using ScopeIDE.Config;
using ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements.ButtonsStates;

namespace ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements.ButtonsLayers {
    public partial class ButtonLayerVer1 : AButtonLayer {
        public ButtonLayerVer1(
            IDesignConfig designConfig,
            IButtonLayerController buttonLayerController) :
            base(designConfig, buttonLayerController,
                new ButtonLayerMainStateVer1(designConfig, buttonLayerController),
                new ButtonLayerEditingNameStateVer1(designConfig, buttonLayerController),
                new ButtonLayerEditingTransparencyState(designConfig, buttonLayerController)) {
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor; //TODO Why it`s not depend on base class??

            InitializeComponent();
        }
    }

    internal sealed class ButtonLayerMainStateVer1  : ButtonLayerMainState {
        public ButtonLayerMainStateVer1(IDesignConfig designConfig, IButtonLayerController buttonLayerController) :
            base(designConfig, buttonLayerController) {
        }
    }

    internal sealed class ButtonLayerEditingNameStateVer1  : ButtonLayerEditingNameState{
        public ButtonLayerEditingNameStateVer1(IDesignConfig designConfig, IButtonLayerController buttonLayerController) : base(designConfig, buttonLayerController) { }

        protected override void UpdateNameBox() {
            base.UpdateNameBox();
            DesignConfig.PanelLayerConfig.ButtonLayerConfig.Width =
            DesignConfig.PanelLayerConfig.ButtonLayerConfig.WidthDef ;
        }
    }
}