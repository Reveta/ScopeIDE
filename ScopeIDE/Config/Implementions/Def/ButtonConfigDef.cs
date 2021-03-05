using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementions.Def {
    public class ButtonConfigDef : IButtonConfig {
        public int Width { get; set; }
        public int Height { get; set; }
        public int WidthDef { get; }
        public int HeightDef { get; }

        public ButtonConfigDef() {
            
            WidthDef = 50;
            HeightDef = 50;
            Width = WidthDef;
            Height = HeightDef;

        }
    }
}