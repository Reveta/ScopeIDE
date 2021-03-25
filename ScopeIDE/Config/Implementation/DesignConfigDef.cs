using ScopeIDE.Config.Implementation.Def;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Config.Interfaces.Panels;

namespace ScopeIDE.Config.Implementation {
    public class DesignConfigDef : IDesignConfig {
        public IColorConfig ColorConfig { get; set; }
        public IFormSize FormSize { get; set; }
        public IContextMenuConfig ContextMenuConfig { get; set; }
        public IPanelMainConfig PanelMainConfig { get; set; }
        public IPanelInstrument PanelInstrument { get; set; }
        public IPanelLayerConfig PanelLayerConfig { get; set; }
        public IPanelNavbar PanelNavbar { get; set; }
        public IPanelToolBox PanelToolBox { get; set; }
        public IResources Resources { get; set; }
        public IScale Scale { get; set; }

        public DesignConfigDef() {
            ColorConfig = new ColorConfigDef();
            FormSize = new FormSizeDef();
            ContextMenuConfig = new ContextMenuConfigDef();
            PanelInstrument = new PanelInstrumentDef();
            PanelLayerConfig = new PanelLayerConfigDef();
            PanelMainConfig = new PanelMainConfig();
            PanelToolBox = new PanelToolbox();
            PanelNavbar = new PanelNavbarDef();
            Resources = new ResourcesDef();
            Scale = new ScaleDef();
        }
    }
}