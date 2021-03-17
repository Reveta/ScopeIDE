using ScopeIDE.Config.Implementation.Def;
using ScopeIDE.Config.Implementation.Light;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementation {
    public class DesignConfigLight : IDesignConfig{
        public IColorConfig ColorConfig { get; set; }
        public IFormSize FormSize { get; set; }
        public IPanelMainConfig PanelMainConfig { get; set; }
        public IPanelInstrument PanelInstrument { get; set; }
        public IPanelNavbar PanelNavbar { get; set; }
        public IPanelToolBox PanelToolBox { get; set; }
        public IResources Resources { get; set; }
        public IScale Scale { get; set; }

        public DesignConfigLight() {
            ColorConfig = new ColorConfigLight();
            FormSize = new FormSizeDef();
            PanelMainConfig = new PanelMainConfig();
            PanelInstrument = new PanelInstrumentDef();
            PanelNavbar = new PanelNavbarDef();
            PanelToolBox = new PanelToolbox();
            Resources = new ResourcesDef();
            Scale = new ScaleDef();
        }
    }
}