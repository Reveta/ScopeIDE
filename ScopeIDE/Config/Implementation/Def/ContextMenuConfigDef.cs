using System.Drawing;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Config.Interfaces.Panels;

namespace ScopeIDE.Config.Implementation.Def {
    public class ContextMenuConfigDef : IContextMenuConfig{
        public int Width { get; set; }
        public int Height { get; set; }
        public int WidthDef { get; set; }
        public int HeightDef { get; set; }
        public IButtonConfig ButtonConfig { get; set; }

        public ContextMenuConfigDef() {
            WidthDef = 100;
            HeightDef = 30;
            Width = 100;
            Height = 30;

            ButtonConfig = new ButtonConfigEmpty() {
                WidthDef = 50,
                HeightDef = 30,
                Width = 120,
                Height = 30,
                FontName =  new FontFamily("Verdana"),
                FontSizeDef = 8,
                FontSize = 8,
                FontStyle = FontStyle.Regular
            };
        }
    }
}