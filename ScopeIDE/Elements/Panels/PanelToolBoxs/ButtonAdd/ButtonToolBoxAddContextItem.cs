using System;
using System.Windows.Forms;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Elements.Panels.ContextMenu;
using ScopeIDE.Panels;
using ScopeIDE.Panels.PanelTemplates;

namespace ScopeIDE.Elements.Panels.PanelToolBoxs.ButtonAdd {
    public partial class ButtonToolBoxAddContextItem : ButtonContextMenuItem {
        public Button ScopeButton { get; set; }
        public APanelWithButtons ParentPanelToolBox { get; }
        private bool state;

        public ButtonToolBoxAddContextItem(IDesignConfig designConfig, Button scopeButton,
            APanelWithButtons parentPanelToolBox) : base(designConfig) {
            state = false;
            ScopeButton = scopeButton;
            ParentPanelToolBox = parentPanelToolBox;
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e) {
            if (!state) {
                SetPassiveStyle();
                ScopeButton.Show();
                state = true;
            }
            else {
                SetActiveStyle();
                ScopeButton.Hide();
                state = false;
            }

            ParentPanelToolBox.RePaint();

            base.OnClick(e);
        }

        private void SetActiveStyle() {
            this.BackColor = base.DesignConfig.ColorConfig.SecondBackColor;
        }

        private void SetPassiveStyle() {
            this.BackColor = base.DesignConfig.ColorConfig.ThirdBackColor;
        }
    }
}