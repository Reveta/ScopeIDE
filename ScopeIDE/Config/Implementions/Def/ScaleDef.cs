using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementions.Def {
    public class ScaleDef : IScale{
        public int FullHD { get; set; }
        public int DoubleHD { get; set; }
        public int FourHD { get; set; }
        public int HD { get; set; }

        public ScaleDef() {
            HD = 80;
            FullHD = 100;
            DoubleHD = 125;
            FourHD = 170;
        }
    }
}