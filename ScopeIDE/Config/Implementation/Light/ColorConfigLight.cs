using System.Drawing;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementation.Light {
    public class ColorConfigLight : IColorConfig{
        public Color MainBackColor { get; set; }
        public Color SecondBackColor { get; set; }
        public Color ThirdBackColor { get; set; }
        public Color ContrBackColor { get; set; }
        public Color ActiveBackColor { get; set; }
        public Color FontColorMain { get; set; }

        public ColorConfigLight() {
            MainBackColor = Color.Azure;
            SecondBackColor = Color.Beige;
            ThirdBackColor = Color.Aquamarine;
            ContrBackColor = Color.Aquamarine;
            ActiveBackColor = Color.Aqua;
            FontColorMain = Color.Black;
        }
    }
}