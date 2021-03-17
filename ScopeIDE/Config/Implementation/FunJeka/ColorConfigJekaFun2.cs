using System.Drawing;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementation.FunJeka {
    public class ColorConfigJekaFun2 : IColorConfig {
        public Color MainBackColor { get; set; }

        public Color SecondBackColor { get; set; }

        public Color ThirdBackColor { get; set; }
        public Color ContrBackColor { get; set; }

        public Color ActiveBackColor { get; set; }

        public Color FontColorMain { get; set; }

        public ColorConfigJekaFun2() {
            MainBackColor = ColorTranslator.FromHtml("#1E1E1E");
            SecondBackColor = ColorTranslator.FromHtml("#2D2D2D");
            ThirdBackColor = ColorTranslator.FromHtml("#3D3D3D");
            ContrBackColor = ColorTranslator.FromHtml("##A30015");
            ActiveBackColor = ColorTranslator.FromHtml("#6B6B6B");
            FontColorMain = ColorTranslator.FromHtml("#FAFAFA");
        }
    }
}