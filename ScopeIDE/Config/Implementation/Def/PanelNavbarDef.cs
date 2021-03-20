using System.Drawing;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementation.Def {
    public class PanelNavbarDef : IPanelNavbar {
        public int Height { get; set; }
        public int HeightDef { get; set; }
        public int LogoHeight { get; set; }
        public int LogoWidth { get; set; }
        public IButtonConfig Button { get; set; }

        public PanelNavbarDef() {
            LogoHeight = 20;
            LogoWidth = 20;
            HeightDef = 30;
            Height = 30;

            Button = new ButtonConfigEmpty() {
                WidthDef = 50,
                HeightDef = 40,
                Width = 50,
                Height = 40,
                FontName =  new FontFamily("Verdana"),
                FontSizeDef = 10,
                FontStyle = FontStyle.Regular
            };
        }
    }
}