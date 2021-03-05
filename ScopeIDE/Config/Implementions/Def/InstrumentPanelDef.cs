using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementions.Def {
    public class PanelInstrumentDef : IPanelInstrument{
        public IButtonConfig Button { get; set; }

        public PanelInstrumentDef() {
            Button = new ButtonConfigEmpty() {
                WidthDef = 50,
                HeightDef = 50,
                Width = 50,
                Height = 50
            };
        }
    }
}