namespace ScopeIDE.Config.Interfaces {
    public interface IPanelMainConfig : ISizeConfig, ILocationConfig {
        public IButtonConfig Button { get; set; }
    }
}