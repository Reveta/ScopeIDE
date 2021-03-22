using System.Drawing;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementation.Def {
    public class PanelToolbox : IPanelToolBox {
        public IButtonConfig Button { get; set; }
        
        public int HeightDef { get; set; }
        public int Height { get; set; }
        
        public int WidthDef { get; set; }
        public int Width { get; set; }

        public PanelToolbox() {
            Button = new ButtonConfigEmpty() {
                WidthDef = 40,
                HeightDef = 84,
                Width = 40,
                Height = 84,

                FontName = new FontFamily("Verdana"),
                FontSizeDef = 8,
                FontSize = 8,
                FontStyle = FontStyle.Regular,
            };
        }

        public int LocationXDef { get; set; }
        public int LocationYDef { get; set; }
    }
}