using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScopeIDE.Panels.PanelTemplates {
    public abstract class APanelWithButtons : UserControl, IPanelWithButtons {
        public abstract void AddLayer(Button button, bool onlyPosition = false);
        public abstract void RePaint();

        public List<Button> GetAllButtons() {
            return this.Controls.OfType<Button>().ToList();
        }
    }
}