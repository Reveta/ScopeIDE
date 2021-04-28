using ScopeIDE.Config.Interfaces;
using ScopeIDE.Config.Interfaces.Panels;

namespace ScopeIDE.Config {
    public interface IDesignConfig {
        public IColorConfig ColorConfig { get; set; }
        public IFormSize FormSize { get; set; }
        public  IContextMenuConfig ContextMenuConfig { get; set; }
        public  IPanelMainConfig PanelMainConfig { get; set; }
        public  IPanelInstrument PanelInstrument { get; set; }
        public  IPanelLayerConfig PanelLayerConfig { get; set; }
        public  IPanelNavbar PanelNavbar { get; set; }
        public  IPanelToolBox PanelToolBox { get; set; }
        public IResources Resources { get; set; }

        public IScale Scale { get; set; }
    }
}