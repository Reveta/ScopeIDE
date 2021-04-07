using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ScopeIDE.Elements.Panels.PanelLayer.Buttons {
    public partial class AButtonLayer {
        private EditModes EditMode { get; set; } = EditModes.OnDoubleClick;
        private bool IsEditing => NameBox.Visible;

        private void ConfigNameBox() {
            NameBox = new TextBox {
                Text = Text,
                Visible = false,
                Multiline = true,
                Dock = DockStyle.Fill,
                BackColor = this.BackColor,
                BorderStyle = BorderStyle.None,
                TextAlign = HorizontalAlignment.Center,
                ForeColor = DesignConfig.ColorConfig.FontColorMain,
                MaxLength = 12
            };

            NameBox.LostFocus += (sender, args) => EndEdit();
            NameBox.KeyDown += Txt_PreviewKeyDown;
        }

        public enum EditModes {
            OnPressF2,
            OnDoubleClick,
            Programmatically
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

        private void BeginEdit() {
            NameBox.Text = this.Text;
            NameBox.SelectAll();
            NameBox.Visible = true;
            ShowOnlyName(true);
            NameBox.Focus();
        }

        private void EndEdit() {
            CancelEdit();
            ButtonLayerController.SetName(NameBox.Text);
            Text = NameBox.Text;
            Focus();
        }

        private void CancelEdit() {
            NameBox.Visible = false;
            ShowOnlyName(false);
            Focus();
        }

        private void ShowOnlyName(bool onlyName) {
            _layerScreen.Visible = !onlyName;
            _buttonHide.Visible = !onlyName;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (!IsEditing && EditMode == EditModes.OnPressF2) {
                BeginEdit();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnClick(EventArgs e) {
            if (EditMode == EditModes.OnDoubleClick) {
                BeginEdit();
            }

            base.OnClick(e);
        }
    }
}