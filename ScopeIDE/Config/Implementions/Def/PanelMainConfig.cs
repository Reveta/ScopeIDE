using System.Drawing;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementions.Def {
    public class PanelMainConfig : IPanelMainConfig{
        public int Height { get; set; }
        public int HeightDef { get; set; }
        public int WidthDef { get; set; }
        public int Width { get; set; }
        public IButtonConfig Button { get; set; }

        public PanelMainConfig() {
            Height = 60;
            HeightDef = 60;
            Width = 400;
            WidthDef = 400;
            Button = new ButtonConfigEmpty() {
                WidthDef = 50,
                HeightDef = 50,
                Width = 50,
                Height = 50,
                FontName = FontFamily.GenericMonospace,
                FontSizeDef = 15,
                FontSize = 15,
                FontStyle = FontStyle.Regular
            };
        }
    }
    
    
}