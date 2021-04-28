using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements.ButtonsStates;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements.ButtonsLayers {
    public abstract partial class AButtonLayer : AButtonColorDepend, IButtonLayer, IEventFormResize {
        protected IDesignConfig DesignConfig { get; }
        protected IButtonLayerController ButtonLayerController { get; }

        public IButtonLayerState MainState { get; set; }
        public IButtonLayerState EditNameState { get; set; }
        public IButtonLayerState EditTranspState { get; set; }
        private Form _parentForm;

        protected AButtonLayer(IDesignConfig designConfig, IButtonLayerController buttonLayerController,
            IButtonLayerState mainState,
            IButtonLayerState editNameState,
            IButtonLayerState editTranspState
            ) :
            base(designConfig.ColorConfig) {
            DesignConfig = designConfig;
            ButtonLayerController = buttonLayerController;
            

            MainState = mainState;
            Controls.Add((UserControl) MainState);
            EditNameState = editNameState;
            Controls.Add((UserControl) EditNameState);
            EditTranspState = editTranspState;
            Controls.Add((UserControl) EditTranspState);
        }

        public void ShowMainState() {
            ((UserControl) EditNameState).Hide();
            ((UserControl) EditTranspState).Hide();
            ((UserControl) MainState).Show();
            RePaint();
            UpdateMainState();
        }

        public void ShowEditNameState() {
            ((UserControl) MainState).Hide();
            ((UserControl) EditTranspState).Hide();
            ((UserControl) EditNameState).Show();
            RePaint();
            UpdateEditNameState();
        }

        public void ShowEditTranspState() {
            ((UserControl) MainState).Hide();
            ((UserControl) EditNameState).Hide();
            ((UserControl) EditTranspState).Show();
            RePaint();
            UpdateEditTranspState();
        }

        private void UpdateMainState() {
            if (MainState is null) {
                MainState = new ButtonLayerMainState(DesignConfig, ButtonLayerController);
                Controls.Add((UserControl) MainState);
            }

            MainState.UpdateState();
        }

        private void UpdateEditNameState() {
            if (EditNameState is null) {
                EditNameState = new ButtonLayerEditingNameState(DesignConfig, ButtonLayerController);
                Controls.Add((UserControl) EditNameState);
            }
            
            EditNameState.UpdateState();
        }

        private void UpdateEditTranspState() {
            if (EditTranspState is null) {
                EditTranspState = new ButtonLayerEditingTransparencyState(DesignConfig, ButtonLayerController);
                Controls.Add((UserControl) EditTranspState);
            }
            
            EditTranspState.UpdateState();
        }

        
        public void EventFormResize(Form form) {
            if (form is not IFormResizable formResizable) return;
            
            int coof = formResizable.Scales switch {
                EScales.HD => DesignConfig.Scale.HD,
                EScales.FullHD => DesignConfig.Scale.FullHD,
                EScales.DoubleHD => DesignConfig.Scale.DoubleHD,
                EScales.FourHD => DesignConfig.Scale.FourHD,
                _ => DesignConfig.Scale.FullHD
            };
            
            //updateLayerScreen config
            DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontSize =
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontSizeDef / 100 * coof;

            DesignConfig.PanelLayerConfig.ButtonLayerConfig.Height =
                (int) (DesignConfig.PanelLayerConfig.ButtonLayerConfig.HeightDef / 100f * coof);

            RePaint();

            UpdateMainState();
            UpdateEditNameState();
        }

        private void RePaint() {
            this.Width = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Width;
            this.Height = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Height;
            this.Font = new Font(
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontName,
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontSize,
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontStyle
            );
        }
    }
}