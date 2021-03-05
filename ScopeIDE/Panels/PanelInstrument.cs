using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Elements;
using ScopeIDE.Elements.PanelInstruments;
using ScopeIDE.libs.ControlExt;

namespace ScopeIDE.Panels {
    public partial class InstrumentPanel : UserControl, IEventFormResize {
        public IDesignConfig DesignConfig { get; }

        private ButtonTransform _buttonTransform1;
        private EState _state;

        public InstrumentPanel(IDesignConfig designConfig) {
            _state = EState.Big;
            DesignConfig = designConfig;
            AddTransformButton();

            AddButton(new ButtonInstrument(designConfig));
            AddButton(new ButtonInstrument(designConfig));
            AddButton(new ButtonInstrument(designConfig));
            AddButton(new ButtonInstrument(designConfig));

            InitializeComponent();
        }

        public void AddButton(Button button, bool onlyPosition = false) {
            int count = this.GetAllButtons().Count;
            button.Name = "buttonInstrument" + count;
            button.TabIndex = count;

            if (!onlyPosition) {
                button.FlatStyle = FlatStyle.Flat;

                button.Font = new Font(
                    DesignConfig.Resources.FontName,
                    DesignConfig.Resources.FontSize,
                    DesignConfig.Resources.FontStyle);

                button.BackColor = DesignConfig.ColorConfig.ContrBackColor;
                button.ForeColor = DesignConfig.ColorConfig.FontColorMain;

                button.FlatAppearance.BorderSize = 0;
                button.Margin = new Padding(0);

                button.Size = new Size(
                    DesignConfig.InstrumentPanel.Button.Width,
                    DesignConfig.InstrumentPanel.Button.Height);

                button.TabStop = false;
                button.TextAlign = ContentAlignment.BottomCenter;
                button.UseVisualStyleBackColor = false;
                button.AutoSize = false;
            }

            this.Controls.Add(button);
        }
        
        #region Initialize_region

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // InstrumentPanel
            // 
            this.AccessibleRole = AccessibleRole.MenuItem;
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor;
            this.BorderStyle = BorderStyle.None;
            this.Location = new Point(0, 83);
            this.Margin = new Padding(0);
            this.Name = "instrumentPanel1";


            this.SetBigStyle();
            this.Name = "InstrumentPanel";
            this.ResumeLayout(false);
        }

        private void AddTransformButton() {
            _buttonTransform1 = new ButtonTransform(DesignConfig) {
                Location = new Point(0, 0),
            };
            this._buttonTransform1.Click += this.buttonTransform1_Click_1;

            this.Controls.Add(_buttonTransform1);
        }

        #endregion
        
        #region EventFormResize

        public void EventFormResize(Form form) {
            ControlCollectionExt.ToList(this.Controls).ForEach(control => {
                if (control is IEventFormResize element) {
                    element.EventFormResize(form);
                }
            });

            RePaint();
        }
        
        #endregion

        #region EventButtonTransformClick_Region

        private void buttonTransform1_Click_1(object sender, EventArgs e) {
            switch (_state) {
                case EState.Big:
                    _state = EState.Small;
                    break;
                case EState.Small:
                    _state = EState.Big;
                    break;
            }

            RePaint();
        }

        private void RePaint() {
            switch (_state) {
                case EState.Big:
                    this.SetBigStyle();
                    break;
                case EState.Small:
                    this.SetSmallStyle();
                    break;
            }
        }

        private void SetBigStyle() {
            _state = EState.Big;
            int width = (DesignConfig.InstrumentPanel.Button.Width * 2) + 20;
            int height = this._buttonTransform1.Height
                         + DesignConfig.InstrumentPanel.Button.Height
                         + ((GetAllButtons().Count / 2) * (DesignConfig.InstrumentPanel.Button.Height + 10));
            
            this.Size = new Size(
                width,
                height
            );

            this._buttonTransform1.SetBigStyle();

            int x1 = 5;
            int x2 = DesignConfig.InstrumentPanel.Button.Width + 5 + x1;
            int y = DesignConfig.InstrumentPanel.Button.Height + this._buttonTransform1.Height;
            bool xState = true;
            foreach (Control element in this.Controls) {
                if (element is ButtonTransform) {
                    continue;
                }

                element.Location = xState ? new Point(x1, y) : new Point(x2, y);
                if (!xState) {
                    y += 5 + element.Size.Width;
                }

                xState = !xState;
            }
        }

        private void SetSmallStyle() {
            _state = EState.Small;
            int width = (DesignConfig.InstrumentPanel.Button.Width) + 10;
            int height = this._buttonTransform1.Height
                         + (GetAllButtons().Count * (DesignConfig.InstrumentPanel.Button.Height + 10));
            
            this.Size = new Size(
                width,
                height
            );

            this._buttonTransform1.SetSmallStyle();

            int x1 = 5;
            int y = DesignConfig.InstrumentPanel.Button.Height + this._buttonTransform1.Height;
            foreach (Control element in this.Controls) {
                if (element is ButtonTransform) {
                    continue;
                }

                element.Location = new Point(x1, y);
                y += 5 + element.Size.Width;
            }
        }

        #endregion

        #region Utill_region

        private List<Button> GetAllButtons() {
            return this.Controls.OfType<Button>().ToList();
        }

        private enum EState {
            Big,
            Small
        }

        #endregion
    }
}