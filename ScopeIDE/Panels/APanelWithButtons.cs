using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ScopeIDE.Elements;

namespace ScopeIDE.Panels {
    public abstract class APanelWithButtons : UserControl, IPanelWithButtons {
        public abstract void AddButton(Button button, bool onlyPosition = false);
        public abstract void RePaint();

        protected List<Button> GetAllButtons() {
            return this.Controls.OfType<Button>().ToList();
        }
    }
}