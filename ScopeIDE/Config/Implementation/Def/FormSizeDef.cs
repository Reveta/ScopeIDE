using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Config.Implementation.Def {
    public class FormSizeDef : IFormSize{
        public int WidthDef { get; set; }
        public int HeightDef { get; set; }
        
        public int Width { get; set; }
        public int Height { get; set; }
        public int LocationXDef { get; set; }
        public int LocationYDef { get; set; }

        public FormSizeDef() {
            WidthDef = 1280;
            HeightDef = 720;

            Width = WidthDef;
            Height = WidthDef;

            Rectangle primaryScreenBounds = Screen.PrimaryScreen.Bounds;
            var width = primaryScreenBounds.Width / 2.5;
            var height = primaryScreenBounds.Height / 2.5;
            LocationYDef = (int) height;
            LocationXDef = (int) width;
        }
    }
}