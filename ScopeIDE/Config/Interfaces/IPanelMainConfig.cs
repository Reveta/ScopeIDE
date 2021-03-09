namespace ScopeIDE.Config.Interfaces {
    public interface IPanelMainConfig {
        public int Height { get; set; }
        public int HeightDef { get; set; }
        public int WidthDef { get; set; }
        public int Width { get; set; }
        public IButtonConfig Button { get; set; }
    }
}