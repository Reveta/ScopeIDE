using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces.Panels;

namespace ScopeIDE.Panels.PanelTemplates {
    public class ALocationFiller : ILocationConfig{
        public int LocationXDef { get; set; }
        public int LocationYDef { get; set; }

        public ALocationFiller(int locationXDef, int locationYDef) {
            LocationXDef = locationXDef;
            LocationYDef = locationYDef;
        }
    }
}