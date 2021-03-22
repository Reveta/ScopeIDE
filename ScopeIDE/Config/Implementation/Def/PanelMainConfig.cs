using System.Drawing;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementation.Def {
    public class PanelMainConfig : IPanelMainConfig{
        public IButtonConfig Button { get; set; }
        public int Height { get; set; }
        public int HeightDef { get; set; }
        public int WidthDef { get; set; }
        public int Width { get; set; }

        public int LocationXDef { get; set; }

        public int LocationYDef { get; set; }

        public PanelMainConfig() {
            Height = 60;
            HeightDef = 60;
            Width = 400;
            WidthDef = 400;
            Button = new ButtonConfigEmpty() {
                WidthDef = 40,
                HeightDef = 40,
                Width = 40,
                Height = 40,
                FontName = FontFamily.GenericMonospace,
                FontSizeDef = 15,
                FontSize = 15,
                FontStyle = FontStyle.Regular
            };
        }
    }
    
    
}