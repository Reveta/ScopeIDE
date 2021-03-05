using System.Drawing;

namespace ScopeIDE.Config.Interfaces {
    public interface IColorConfig {
        public Color MainBackColor { get; set; }
        public Color SecondBackColor { get; set; }
        public Color ContrBackColor { get; set; }
        public Color ActiveBackColor { get; set; }
        public Color FontColorMain { get; set; }
    }
}