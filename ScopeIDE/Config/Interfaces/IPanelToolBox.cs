namespace ScopeIDE.Config.Interfaces {
    public interface IPanelToolBox {
        public IButtonConfig Button { get; set; }
        
        public int Height { get; set; }
        public int Width { get; set; }
        
    }
}