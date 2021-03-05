using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementions.Def {
    public class FormSizeDef : IFormSize{
        public int WidthDef { get; set; }
        public int HeightDef { get; set; }
        
        public int Width { get; set; }
        public int Height { get; set; }
        public int XDef { get; set; }
        public int YDef { get; set; }

        public FormSizeDef() {
            WidthDef = 800;
            HeightDef = 600;

            Width = WidthDef;
            Height = WidthDef;

            Rectangle primaryScreenBounds = Screen.PrimaryScreen.Bounds;
            var width = primaryScreenBounds.Width / 2.5;
            var height = primaryScreenBounds.Height / 2.5;
            YDef = (int) height;
            XDef = (int) width;
        }
    }
}