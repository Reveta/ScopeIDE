using System.Drawing;

namespace ScopeIDE.Config.Interfaces {
    public interface IResources {
        public FontFamily FontName { get; set; }
        public float FontSize { get; set; }
        public FontStyle FontStyle { get; set; }
    
        public int RetreatSize { get; set; }
    }
}