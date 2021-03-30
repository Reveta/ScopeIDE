using ScopeIDE.Config.Interfaces;
using ScopeIDE.Config.Interfaces.Panels;

namespace ScopeIDE.Config.Implementation.Def {
    public class PanelLayerConfigDef : IPanelLayerConfig{
        public int WidthDef { get; set; }
        public int Width { get; set; }
        public int HeightDef { get; set; }
        public int Height { get; set; }
        public int LocationXDef { get; set; }
        public int LocationYDef { get; set; }
        public IButtonConfig ButtonInstrumentsConfig { get; set; }
        public IButtonConfig ButtonLayerConfig { get; set; }
        public int InstrumentsInRow { get; set; }

        public PanelLayerConfigDef() {
            WidthDef = 10;
            Width = 10;
            HeightDef = 100;
            Height = 100;
            LocationXDef = 500;
            LocationYDef = 500;

            InstrumentsInRow = 4;

            ButtonInstrumentsConfig = new ButtonInstrumentDef();
            
            ButtonLayerConfig = new ButtonInstrumentDef() {
                WidthDef = 20,
                Width = 20,
                HeightDef = 40,
                Height = 40,
            };
        }
    }
}