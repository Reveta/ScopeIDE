﻿using ScopeIDE.Config.Implementions.Def;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementions {
    public class DesignConfigDef : IDesignConfig {
        public IColorConfig ColorConfig { get; set; }
        public IFormSize FormSize { get; set; }
        public IPanelMainConfig PanelMainConfig { get; set; }
        public IPanelInstrument PanelInstrument { get; set; }
        public IPanelNavbar PanelNavbar { get; set; }
        public IResources Resources { get; set; }
        public IScale Scale { get; set; }

        public DesignConfigDef() {
            ColorConfig = new ColorConfigDef();
            FormSize = new FormSizeDef();
            PanelInstrument = new PanelInstrumentDef();
            PanelMainConfig = new PanelMainConfig();
            PanelNavbar = new PanelNavbarDef();
            Resources = new ResourcesDef();
            Scale = new ScaleDef();
        }
    }
}