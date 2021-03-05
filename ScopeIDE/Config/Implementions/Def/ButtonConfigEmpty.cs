using System.Windows.Forms;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementions.Def {
    public class ButtonConfigEmpty : Button, IButtonConfig {
        public int WidthDef { get; set; }
        public int HeightDef { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public ButtonConfigEmpty() {
            this.FlatAppearance.BorderSize = 0;

        }
    }
}