using System.Drawing;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementation.Def {
    public class PanelInstrumentDef : IPanelInstrument{
        public IButtonConfig Button { get; set; }

        public PanelInstrumentDef() {
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