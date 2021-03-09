using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Elements;
using ScopeIDE.Forms.FormStyls;
using ScopeIDE.libs.ControlExt;
using ScopeIDE.libs.Egolds;
using ScopeIDE.Panels;

namespace ScopeIDE.Forms {
    public partial class FormMain : ShadowedForm, IFormResizable {
        public IDesignConfig DesignConfig { get; set; }
        private MyStyleExtenstion _styleExtenstion;
        public EScales Scales { get; set; }

        private PanelInstrument _panelInstrumentPanel1;
        private PanelNavbar _panelNavbar1;

        public FormMain(IDesignConfig designConfig) {
            DesignConfig = designConfig;
            components = new Container();
            UpdateScale();

            FormConfig();
            InitializeComponent();
            AddPanelInstrument();
            AddPanelNavbar();
        }

        protected override void OnResize(EventArgs e) {
            UpdateScale();
            ControlCollectionExt.ToList(this.Controls).ForEach(control => {
                if (control is IEventFormResize element) {
                    element.EventFormResize(this);
                }
            });

            base.OnResize(e);
        }

        private void UpdateScale() {
            Scales = this.Width switch {
                < 1080 => EScales.HD,
                < 1720 => EScales.FullHD,
                < 2360 => EScales.DoubleHD,
                < 3560 => EScales.FourHD,
                _ => EScales.FourHD
            };
        }

        private void AddPanelNavbar() {
            _panelNavbar1 = new PanelNavbar(DesignConfig) {
                Location = new Point(
                    DesignConfig.PanelNavbar.LogoWidth + 25,
                    DesignConfig.PanelNavbar.Height * -1)
            };

            this.Controls.Add(_panelNavbar1);
        }

        private void AddPanelInstrument() {
            this._panelInstrumentPanel1 = new PanelInstrument(DesignConfig) {TabIndex = 0};

            this.Controls.Add(_panelInstrumentPanel1);
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // FormMain
            // 
            this.Name = "FormMain";
            this.ResumeLayout(false);
        }

        private void FormConfig() {
            _styleExtenstion = new MyStyleExtenstion(this, this.components);

            this.Height = DesignConfig.FormSize.HeightDef;
            this.Width = DesignConfig.FormSize.WidthDef;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(
                DesignConfig.FormSize.XDef,
                DesignConfig.FormSize.YDef);
        }
    }
}