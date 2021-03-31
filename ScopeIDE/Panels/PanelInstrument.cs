using System;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Elements;
using ScopeIDE.Elements.Panels.PanelInstruments;
using ScopeIDE.libs.ControlExt;
using ScopeIDE.LocationManagment;
using ScopeIDE.LocationManagment.Configs;
using ScopeIDE.Panels.PanelTemplates;

namespace ScopeIDE.Panels {
    public partial class PanelInstrument : APanelTemplateWB, IEventFormResize, IReLocateControl {
        public IDesignConfig DesignConfig { get; }
        public LocationManager LocationManager { get; set; }

        private AButtonTransform _aButtonTransform1;
        private EState _state;


        public PanelInstrument(IDesignConfig designConfig, Point location) : base(location) {
            DesignConfig = designConfig;
            this.DoubleBuffered = true;
            _state = EState.Big;

            AddTransformButton();

            AddButton(new AButtonInstrument(designConfig) {Text = "😍"});
            AddButton(new AButtonInstrument(designConfig){Text = "😘"});
            AddButton(new AButtonInstrument(designConfig){Text = "👌"});
            AddButton(new AButtonInstrument(designConfig){Text = "😒"});
            
            AddButton(new AButtonInstrument(designConfig){Text = "😁"});
            AddButton(new AButtonInstrument(designConfig){Text = "😂"});
            AddButton(new AButtonInstrument(designConfig){Text = "😊"});
            AddButton(new AButtonInstrument(designConfig){Text = "🤣"});
            
            AddButton(new AButtonInstrument(designConfig){Text = "❤"});
            AddButton(new AButtonInstrument(designConfig){Text = "💕"});
            AddButton(new AButtonInstrument(designConfig){Text = "🎉"});

            InitializeComponent();
        }
        
        

        public override void AddButton(Button button, bool onlyPosition = false) {
            int count = this.GetAllButtons().Count;
            button.Name = "buttonInstrument" + count;
            button.TabIndex = count;

            if (!onlyPosition) {
                button.FlatStyle = FlatStyle.Flat;

                button.Font = new Font(
                    DesignConfig.PanelInstrument.Button.FontName,
                    DesignConfig.PanelInstrument.Button.FontSize,
                    DesignConfig.PanelInstrument.Button.FontStyle
                );

                button.FlatAppearance.BorderSize = 0;
                button.Margin = new Padding(0);

                button.Size = new Size(
                    DesignConfig.PanelInstrument.Button.Width,
                    DesignConfig.PanelInstrument.Button.Height);

                button.TabStop = false;
                button.TextAlign = ContentAlignment.MiddleCenter;
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
            this.Margin = new Padding(0);
            this.Name = "instrumentPanel1";


            this.SetBigStyle();
            this.Name = "PanelInstrument";
            this.ResumeLayout(false);
        }

        private void AddTransformButton() {
            _aButtonTransform1 = new AButtonTransform(DesignConfig) {
                Location = new Point(0, DesignConfig.Resources.RetreatSize),
            };
            this._aButtonTransform1.Click += this.AButtonTransform1Click1;

            this.Controls.Add(_aButtonTransform1);
        }

        #endregion

        #region EventFormResize

        public void EventFormResize(Form form) {
            _aButtonTransform1.Location = new Point(0, DesignConfig.Resources.RetreatSize);
            
            var controls = ControlCollectionExt.ToList(this.Controls);
            controls.ForEach(control => {
                if (control is IEventFormResize element) {
                    element.EventFormResize(form);
                }
            });


            RePaint();
        }

        #endregion

        #region EventButtonTransformClick_Region

        private void AButtonTransform1Click1(object sender, EventArgs e) {
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

        public override void RePaint() {
            switch (_state) {
                case EState.Big:
                    this.SetBigStyle();
                    break;
                case EState.Small:
                    this.SetSmallStyle();
                    break;
            }

            ReLocateAll();
        }

        private void SetBigStyle() {
            _state = EState.Big;
            int width = (DesignConfig.PanelInstrument.Button.Width * 2) + (DesignConfig.Resources.RetreatSize * 3);

            var count = GetAllButtons().Count;
            int height =
                (count / 2 * DesignConfig.PanelInstrument.Button.Height) +
                (count / 2 * DesignConfig.Resources.RetreatSize) +
                DesignConfig.Resources.RetreatSize;

            if (count / 2 != 0) {
                height += DesignConfig.PanelInstrument.Button.Height + DesignConfig.Resources.RetreatSize;
            }

            this.Size = new Size(
                width,
                height
            );

            this._aButtonTransform1.SetBigStyle();

            int x1 = DesignConfig.Resources.RetreatSize;
            int x2 = DesignConfig.PanelInstrument.Button.Width + DesignConfig.Resources.RetreatSize + x1;
            int y = this._aButtonTransform1.Height + (DesignConfig.Resources.RetreatSize * 2);
            bool xState = true;
            foreach (Control element in this.Controls) {
                if (element is AButtonTransform) {
                    continue;
                }

                element.Location = xState ? new Point(x1, y) : new Point(x2, y);
                if (!xState) {
                    y += DesignConfig.Resources.RetreatSize + element.Size.Width;
                }

                xState = !xState;
            }
        }

        private void SetSmallStyle() {
            _state = EState.Small;
            int width = (DesignConfig.PanelInstrument.Button.Width) + (DesignConfig.Resources.RetreatSize * 2);
            int height =
                (GetAllButtons().Count * DesignConfig.PanelInstrument.Button.Height) +
                (GetAllButtons().Count * DesignConfig.Resources.RetreatSize) +
                DesignConfig.Resources.RetreatSize;

            this.Size = new Size(
                width,
                height
            );

            this._aButtonTransform1.SetSmallStyle();

            int x1 = DesignConfig.Resources.RetreatSize;
            int y = this._aButtonTransform1.Height + (DesignConfig.Resources.RetreatSize * 2);
            foreach (Control element in this.Controls) {
                if (element is AButtonTransform) {
                    continue;
                }

                element.Location = new Point(x1, y);
                y += DesignConfig.Resources.RetreatSize + element.Size.Width;
            }
        }

        #endregion

        #region Utill_region

        private enum EState {
            Big,
            Small
        }

        #endregion

        public void ReLocateAll() {
            LocationManager?.ReLocateAll();
        }
    }
}