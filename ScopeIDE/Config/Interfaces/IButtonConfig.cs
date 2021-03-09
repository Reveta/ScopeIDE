using System.Drawing;

namespace ScopeIDE.Config.Interfaces {
    public interface IButtonConfig {
        public int WidthDef { get; set; }
        public int HeightDef { get; set; }
        
        public int Width { get; set; }
        public int Height { get; set; }
        
        public FontFamily FontName { get; set; }
        public float FontSizeDef { get; set; }
        public float FontSize { get; set; }
        public FontStyle FontStyle { get; set; }

    }
}