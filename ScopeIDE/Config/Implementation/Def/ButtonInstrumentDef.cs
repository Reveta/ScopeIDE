using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementation.Def {
    public partial class ButtonInstrumentDef : Button, IButtonConfig {
        public int WidthDef { get; set; }
        public int HeightDef { get; set; }
        public FontFamily FontName { get; set; }
        public float FontSizeDef { get; set; }
        public float FontSize { get; set; }
        public FontStyle FontStyle { get; set; }

        public ButtonInstrumentDef() {
            WidthDef = 40;
            Width = 40;
            HeightDef = 40;
            Height = 40;
            FontName = FontFamily.GenericMonospace;
            FontSizeDef = 15;
            FontSize = 15;
            FontStyle = FontStyle.Regular;
        }
        
    }
}