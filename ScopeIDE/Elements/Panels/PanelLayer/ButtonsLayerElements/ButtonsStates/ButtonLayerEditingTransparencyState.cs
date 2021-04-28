using System;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;

namespace ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements.ButtonsStates {
    public class ButtonLayerEditingTransparencyState : UserControl, IButtonLayerState {
        protected IDesignConfig DesignConfig { get; }
        private IButtonLayerController ButtonLayerController { get; }
        public TextBox TransparencyLevel { get; set; }
        public TrackBar TransparencyBar { get; set; }


        public ButtonLayerEditingTransparencyState(IDesignConfig designConfig,
            IButtonLayerController buttonLayerController) {
            DesignConfig = designConfig;
            ButtonLayerController = buttonLayerController;
            BackColor = DesignConfig.ColorConfig.ThirdBackColor;
            this.LostFocus += (sender, args) => LostFocusAction();

            UpdateState();
            TransparencyLevel.Focus();
        }

        private void LostFocusAction() {
            if (!TransparencyBar.Focused && !TransparencyLevel.Focused && !this.Focused) {
                CancelEdit();
            }
        }
        
        public void UpdateState() {
            this.Height = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Height;
            this.Width = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Width;

            UpdateTranspLevel();
            UpdateTranspBar();
        }

        protected virtual void UpdateTranspBar() {
            if (TransparencyBar == null) {
                TransparencyBar = new TrackBar() {
                    Visible = true,
                    Maximum = 100,
                    Minimum = 0,
                    ForeColor = DesignConfig.ColorConfig.FontColorMain,
                    BackColor = DesignConfig.ColorConfig.ThirdBackColor,
                    AutoSize = false,
                };

                TransparencyBar.ValueChanged += (sender, args) => {
                        ButtonLayerController.Transparency = TransparencyBar.Value;
                        TransparencyLevel.Text = TransparencyBar.Value.ToString();
                    };
                
                TransparencyBar.LostFocus += (sender, args) => LostFocusAction();
                TransparencyBar.KeyDown += Txt_PreviewKeyDown;
                this.Controls.Add(TransparencyBar);
            }


            TransparencyBar.Width = Width - TransparencyLevel.Width 
                                          - (DesignConfig.Resources.RetreatSize * 3);
            TransparencyBar.Height = DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Height 
                                     - (DesignConfig.Resources.RetreatSize * 2);

            TransparencyBar.Location = new Point(
                DesignConfig.Resources.RetreatSize,
                DesignConfig.Resources.RetreatSize);
        }

        protected virtual void UpdateTranspLevel() {
            if (TransparencyLevel == null) {
                TransparencyLevel = new TextBox {
                    Text = ButtonLayerController.Transparency.ToString(),
                    Visible = true,
                    BorderStyle = BorderStyle.None,
                    TextAlign = HorizontalAlignment.Center,
                    ForeColor = DesignConfig.ColorConfig.FontColorMain,
                    MaxLength = 4,
                    BackColor = DesignConfig.ColorConfig.ThirdBackColor,
                    AutoSize = false,
                };
                
                TransparencyLevel.LostFocus += (sender, args) => LostFocusAction();
                TransparencyLevel.KeyDown += Txt_PreviewKeyDown;
                this.Controls.Add(TransparencyLevel);
            }


            TransparencyLevel.Width = DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Width;
            TransparencyLevel.Height = TransparencyLevel.Width / 2 - DesignConfig.Resources.RetreatSize;

            TransparencyLevel.Location = new Point(
                Width - TransparencyLevel.Width - DesignConfig.Resources.RetreatSize,
                Height / 2 - DesignConfig.Resources.RetreatSize * 2);
            
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
            ButtonLayerController.Transparency = Convert.ToInt32(TransparencyLevel.Text);
            ((IButtonLayer)this.Parent).ShowMainState();
        }

        private void CancelEdit() {
            TransparencyLevel.Text = ButtonLayerController.Transparency.ToString();
            ((IButtonLayer)this.Parent).ShowMainState();
        }

    }
}