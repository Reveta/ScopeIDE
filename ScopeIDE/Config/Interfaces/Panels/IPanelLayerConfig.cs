namespace ScopeIDE.Config.Interfaces.Panels {
    public interface IPanelLayerConfig : ISizeConfig, ILocationConfig {
        public IButtonConfig ButtonInstrumentsConfig { get; set; }
        public IButtonConfig ButtonLayerConfig { get; set; }
        
        public int InstrumentsInRow { get; set; }
    }
}