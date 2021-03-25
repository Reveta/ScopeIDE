namespace ScopeIDE.Config.Interfaces.Panels {
    public interface IPanelNavbar : ISizeConfig, ILocationConfig {
        public int LogoHeight { get; set; }
        public int LogoWidth { get; set; }
        public IButtonConfig Button { get; set; }
    }
}