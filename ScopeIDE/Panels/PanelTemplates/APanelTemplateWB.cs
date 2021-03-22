using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;

namespace ScopeIDE.Panels.PanelTemplates {
    public abstract class APanelTemplateWB :  APanelWithButtons, ILocationConfig{

        public ALocationFiller LocationFiller { get; set; }
        
        public int LocationXDef { get; set; }
        public int LocationYDef { get; set; }

        protected APanelTemplateWB(Point point) {
            LocationFiller = new ALocationFiller(point.X,  point.Y);
            
            LocationXDef = point.X;
            LocationYDef = point.Y;
            base.Location = new Point(LocationXDef, LocationYDef);

        }
    }
}