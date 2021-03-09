namespace ScopeIDE.Config.Interfaces {
    public interface IPanelNavbar {
        public int Height { get; set; }
        public int HeightDef { get; set; }

        public int LogoHeight { get; set; }
        public int LogoWidth { get; set; }
        public IButtonConfig Button { get; set; }
    }
}