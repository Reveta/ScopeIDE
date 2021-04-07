using System;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;

namespace ScopeIDE.libs {
    public class EditableButton : UserControl {
        private TextBox txt;

        public enum EditModes {
            OnPressF2,
            OnDoubleClick,
            Programmatically
        }

        public EditModes EditMode { get; set; } = EditModes.OnDoubleClick;
        public bool IsEditing => txt.Visible;

        public EditableButton(IDesignConfig config, string text) {
            this.Font = new Font(
                config.PanelInstrument.Button.FontName,
                config.PanelInstrument.Button.FontSize,
                config.PanelInstrument.Button.FontStyle
            );
            this.Text = text;
            this.Width = 200;
            this.Height = 50;

            txt = new TextBox();
            txt.Text = text;
            txt.BackColor = config.ColorConfig.SecondBackColor;
            txt.ForeColor = config.ColorConfig.FontColorMain;

            txt.TextAlign = HorizontalAlignment.Center;
            txt.Visible = false;
            txt.Multiline = true;
            txt.Dock = DockStyle.Fill;
            this.Controls.Add(txt);
            txt.KeyDown += Txt_PreviewKeyDown;
        }

        private void Txt_PreviewKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                EndEdit();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyData == Keys.Escape) {
                CancelEdit();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        public void BeginEdit() {
            txt.Text = this.Text;
            txt.SelectAll();
            txt.Visible = true;
            txt.Focus();
        }

        public void EndEdit() {
            this.Text = txt.Text;
            txt.Visible = false;
            this.Focus();
        }

        public void CancelEdit() {
            txt.Visible = false;
            this.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (!IsEditing && EditMode == EditModes.OnPressF2) {
                BeginEdit();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnDoubleClick(EventArgs e) {
            if (EditMode == EditModes.OnDoubleClick)
                BeginEdit();
            else
                base.OnClick(e);
        }
    }
}