namespace ScopeIDE.Config.Interfaces {
    public interface IContextMenuConfig {
        
        public int Width { get; set; }
        public int Height { get; set; }
        
        public int WidthDef { get; set; }
        public int HeightDef { get; set; }
        
        public IButtonConfig ButtonConfig { get; set; }
    }
}