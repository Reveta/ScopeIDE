namespace ScopeIDE.Config.Interfaces.Panels {
    public interface IPanelInstrument : ISizeConfig, ILocationConfig {
        public IButtonConfig Button { get; set; }
    }
}