using ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements.ButtonsStates;

namespace ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements {
    public interface IButtonLayer {
        public IButtonLayerState MainState { get; set; }
        public IButtonLayerState EditNameState { get; set; }
        public IButtonLayerState EditTranspState { get; set; }

        public void ShowEditTranspState();
        public void ShowEditNameState();

        public void ShowMainState();
    }
}