﻿using System.Windows.Forms;

namespace ScopeIDE.Panels.PanelTemplates {
    public interface IPanelWithButtons {
        public void AddLayer(Button button, bool onlyPosition = false);

        public void RePaint();

    }
}