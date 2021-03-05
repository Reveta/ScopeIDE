using System.Drawing;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementions.Def {
    public class ColorConfigDef : IColorConfig{
        public Color MainBackColor { get; set; }
        public Color SecondBackColor { get; set; }
        public Color ContrBackColor { get; set; }
        public Color ActiveBackColor { get; set; }
        public Color FontColorMain { get; set; }

        public ColorConfigDef() {
            MainBackColor = Color.DimGray;
            SecondBackColor = Color.Gray;
            ContrBackColor = Color.DarkGray;
            ActiveBackColor = Color.LightGray;
            FontColorMain = Color.Azure;
        }
    }
}