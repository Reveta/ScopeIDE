namespace ScopeIDE.Config.Interfaces.Panels {
    public interface IPanelToolBox : ISizeConfig, ILocationConfig {
        public IButtonConfig Button { get; set; }
    }
}