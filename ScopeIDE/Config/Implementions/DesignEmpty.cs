using ScopeIDE.Config.Implementions.Def;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementions {
    public class DesignEmpty : IDesignConfig{
        public IColorConfig ColorConfig { get; set; }
        public IFormSize FormSize { get; set; }
        public IInstrumentPanel InstrumentPanel { get; set; }
        public IResources Resources { get; set; }
        public IScale Scale { get; set; }

        public DesignEmpty() {
            ColorConfig = new ColorConfigDef();
            FormSize = new FormSizeDef();
            InstrumentPanel = new InstrumentPanelDef();
            Resources = new ResourcesDef();
            Scale = new ScaleDef();
        }
    }
}