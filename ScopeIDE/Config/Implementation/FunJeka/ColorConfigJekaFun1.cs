using System.Drawing;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementation.FunJeka {
    public class ColorConfigJekaFun1 : IColorConfig {
        public Color MainBackColor { get; set; }

        public Color SecondBackColor { get; set; }

        public Color ThirdBackColor { get; set; }
        public Color ContrBackColor { get; set; }

        public Color ActiveBackColor { get; set; }

        public Color FontColorMain { get; set; }

        public ColorConfigJekaFun1() {
            MainBackColor = ColorTranslator.FromHtml("#1A1521");
            SecondBackColor = ColorTranslator.FromHtml("#271F30");
            ThirdBackColor = ColorTranslator.FromHtml("#33293F");
            ContrBackColor = ColorTranslator.FromHtml("#33293F");
            ActiveBackColor = ColorTranslator.FromHtml("#6C5A49");
            FontColorMain = ColorTranslator.FromHtml("#FAFAFA");
        }
    }
}