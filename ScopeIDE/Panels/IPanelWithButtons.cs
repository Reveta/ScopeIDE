using System.Collections.Generic;
using System.Windows.Forms;

namespace ScopeIDE.Panels {
    public interface IPanelWithButtons {
        public void AddButton(Button button, bool onlyPosition = false);

        public void RePaint();

    }
}