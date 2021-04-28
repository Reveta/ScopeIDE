namespace ScopeIDE.Config.Interfaces.Panels {
    public interface IContextMenuConfig : ISizeConfig {
        public IButtonConfig ButtonConfig { get; set; }
    }
}