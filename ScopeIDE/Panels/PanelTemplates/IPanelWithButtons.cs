using System.Windows.Forms;

namespace ScopeIDE.Panels.PanelTemplates {
    public interface IPanelWithButtons {
        public void AddButton(Button button, bool onlyPosition = false);

        public void RePaint();

    }
}