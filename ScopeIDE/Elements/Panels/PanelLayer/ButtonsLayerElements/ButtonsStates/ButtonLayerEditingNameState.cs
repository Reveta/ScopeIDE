using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;

namespace ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements.ButtonsStates {
    public class ButtonLayerEditingNameState : UserControl, IButtonLayerState {
        protected IDesignConfig DesignConfig { get; }
        private IButtonLayerController ButtonLayerController { get; }
        public TextBox NameBox { get; set; }


        public ButtonLayerEditingNameState(IDesignConfig designConfig, IButtonLayerController buttonLayerController) {
            DesignConfig = designConfig;
            ButtonLayerController = buttonLayerController;
            BackColor = DesignConfig.ColorConfig.ThirdBackColor;

            this.Click += (sender, args) => NameBox.Focus();
            UpdateState();
        }
        
        public void UpdateState() {
            this.Height = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Height;
            this.Width = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Width;
            
            UpdateNameBox();
        }

        protected virtual void UpdateNameBox() {
            if (NameBox == null) {
                NameBox = new TextBox {
                    Text = ButtonLayerController.Name,
                    Visible = true,
                    BorderStyle = BorderStyle.None,
                    TextAlign = HorizontalAlignment.Center,
                    ForeColor = DesignConfig.ColorConfig.FontColorMain,
                    MaxLength = 12,
                    BackColor = DesignConfig.ColorConfig.ThirdBackColor,
                };
                
                NameBox.LostFocus += (sender, args) => CancelEdit();
                NameBox.KeyDown += Txt_PreviewKeyDown;
                this.Controls.Add(NameBox);
            }

            NameBox.Location = new Point(0, Height / 2 - DesignConfig.Resources.RetreatSize * 2);
            NameBox.Width = this.Width;
            NameBox.Height = this.Height / 2 - DesignConfig.Resources.RetreatSize;
            
            this.Focus();
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

        private void EndEdit() {
            ButtonLayerController.Name = NameBox.Text;
            ((IButtonLayer)this.Parent).ShowMainState();
        }

        private void CancelEdit() {
            NameBox.Text = ButtonLayerController.Name;
            ((IButtonLayer)this.Parent).ShowMainState();
        }

    }
}