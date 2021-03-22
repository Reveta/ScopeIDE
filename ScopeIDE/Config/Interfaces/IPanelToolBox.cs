namespace ScopeIDE.Config.Interfaces {
    public interface IPanelToolBox : ISizeConfig, ILocationConfig {
        public IButtonConfig Button { get; set; }
    }
}