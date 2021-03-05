using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementions.Def {
    public class InstrumentPanelDef : IInstrumentPanel{
        public IButtonConfig Button { get; set; }

        public InstrumentPanelDef() {
            Button = new ButtonConfigDef();
        }
    }
}