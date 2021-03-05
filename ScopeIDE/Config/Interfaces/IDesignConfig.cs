namespace ScopeIDE.Config.Interfaces {
    public interface IDesignConfig {
        public IColorConfig ColorConfig { get; set; }
        public IFormSize FormSize { get; set; }
        public  IInstrumentPanel InstrumentPanel { get; set; }
        public IResources Resources { get; set; }

        public IScale Scale { get; set; }
    }
}