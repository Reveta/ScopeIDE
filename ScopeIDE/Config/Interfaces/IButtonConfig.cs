using System.Drawing;

namespace ScopeIDE.Config.Interfaces {
    public interface IButtonConfig : ISizeConfig {
        public FontFamily FontName { get; set; }
        public float FontSizeDef { get; set; }
        public float FontSize { get; set; }
        public FontStyle FontStyle { get; set; }

    }
}