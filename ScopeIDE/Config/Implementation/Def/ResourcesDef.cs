using System.Drawing;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementation.Def {
    public class ResourcesDef : IResources{
        public FontFamily FontName { get; set; }
        public float FontSize { get; set; }
        public FontStyle FontStyle { get; set; }
        public int RetreatSize { get; set; }

        public ResourcesDef() {
            FontName = FontFamily.GenericSerif;
            FontSize = 15f;
            FontStyle = FontStyle.Regular;
            RetreatSize = 4;
        }
    }
}