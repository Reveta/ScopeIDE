using System.Drawing;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementions.Light {
    public class ColorConfigLight : IColorConfig{
        public Color MainBackColor { get; set; }
        public Color SecondBackColor { get; set; }
        public Color ContrBackColor { get; set; }
        public Color ActiveBackColor { get; set; }
        public Color FontColorMain { get; set; }

        public ColorConfigLight() {
            MainBackColor = Color.Azure;
            SecondBackColor = Color.Beige;
            ContrBackColor = Color.Aquamarine;
            ActiveBackColor = Color.Aqua;
            FontColorMain = Color.Black;
        }
    }
}