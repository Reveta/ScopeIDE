namespace ScopeIDE.Config.Interfaces {
    public interface IPanelInstrument : ISizeConfig, ILocationConfig {
        public IButtonConfig Button { get; set; }
    }
}