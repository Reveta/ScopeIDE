namespace ScopeIDE.Config.Interfaces {
    public interface IButtonConfig {
        public int Width { get; set; }
        public int Height { get; set; }
        
        public int WidthDef { get; }
        public int HeightDef { get; }
    }
}