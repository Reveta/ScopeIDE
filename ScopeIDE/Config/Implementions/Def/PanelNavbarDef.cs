using System.Drawing;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementions.Def {
    public class PanelNavbarDef : IPanelNavbar {
        public int Height { get; set; }
        public int HeightDef { get; set; }
        public int LogoHeight { get; set; }
        public int LogoWidth { get; set; }
        public IButtonConfig Button { get; set; }

        public PanelNavbarDef() {
            LogoHeight = 20;
            LogoWidth = 20;
            HeightDef = 50;
            Height = 50;

            Button = new ButtonConfigEmpty() {
                WidthDef = 100,
                HeightDef = 30,
                Width = 100,
                Height = 30,
                FontName = FontFamily.GenericMonospace,
                FontSizeDef = 10,
                FontStyle = FontStyle.Regular
            };
        }
    }
}