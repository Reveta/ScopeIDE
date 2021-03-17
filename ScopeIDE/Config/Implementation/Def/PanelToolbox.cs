using System.Drawing;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementation.Def {
    public class PanelToolbox : IPanelToolBox {
        public IButtonConfig Button { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public PanelToolbox() {
            Button = new ButtonConfigEmpty() {
                WidthDef = 40,
                HeightDef = 80,
                Width = 40,
                Height = 80,

                FontName = new FontFamily("Verdana"),
                FontSizeDef = 8,
                FontSize = 8,
                FontStyle = FontStyle.Regular,
            };
        }
    }
}