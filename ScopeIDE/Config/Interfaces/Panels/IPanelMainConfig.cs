namespace ScopeIDE.Config.Interfaces.Panels {
    public interface IPanelMainConfig : ISizeConfig, ILocationConfig {
        public IButtonConfig Button { get; set; }
    }
}