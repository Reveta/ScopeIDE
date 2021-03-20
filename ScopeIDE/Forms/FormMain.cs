using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Implementation.Def;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Elements;
using ScopeIDE.Elements.Panels.ContextMenu;
using ScopeIDE.Elements.Panels.PanelNavbar;
using ScopeIDE.Forms.FormStyls;
using ScopeIDE.libs.ControlExt;
using ScopeIDE.libs.Egolds;
using ScopeIDE.Panels;
using ContextMenu = ScopeIDE.Elements.ContextMenu;

namespace ScopeIDE.Forms {
    public partial class FormMain : ShadowedForm, IFormResizable {
        public IDesignConfig DesignConfig { get; set; }
        private MyStyleExtenstion _styleExtenstion;
        public EScales Scales { get; set; }

        private PanelInstrument _panelInstrumentPanel1;
        private PanelNavbar _panelNavbar1;
        private PanelToolBox _panelToolBox;
        private PanelMain _panelMain1;

        public FormMain(IDesignConfig designConfig) {
            DesignConfig = designConfig;
            components = new Container();
            UpdateScale();

            FormConfig();
            InitializeComponent();

            AddPanelNavbar();
            AddPanelInstrument();
            AddPanelMain();
            AddPanelToolBox();
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
                TabIndex = 0,
                Location = new Point(
                    DesignConfig.PanelNavbar.LogoWidth + 25,
                    (DesignConfig.PanelNavbar.Height * -1) + 1)
            };

            this.Controls.Add(_panelNavbar1);
        }

        private void AddPanelMain() {
            this._panelMain1 = new PanelMain(DesignConfig) {
                TabIndex = 1,
                Location = new Point(0, 0 + DesignConfig.Resources.RetreatSize)
            };

            this.Controls.Add(_panelMain1);
        }

        private void AddPanelToolBox() {
            List<UserControl> panelsToolBox = new List<UserControl>() {
                this._panelMain1,
                this._panelNavbar1,
                this._panelInstrumentPanel1,
            };

            var contextMenu = new ContextMenu(DesignConfig, new List<Button>());

            _panelToolBox = new PanelToolBox(DesignConfig, panelsToolBox, contextMenu) {
                TabIndex = 2,
                Location = new Point(0, 55),
            };

            this.Controls.Add(contextMenu);
            this.Controls.Add(_panelToolBox);
        }

        private void AddPanelInstrument() {
            this._panelInstrumentPanel1 = new PanelInstrument(DesignConfig) {
                TabIndex = 3,
                Location = new Point(DesignConfig.PanelToolBox.Button.Width + 5, DesignConfig.PanelMainConfig.Height - 5)
            };

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
            this.Padding = Padding.Empty;
            this.Margin = Padding.Empty;
            this.Height = DesignConfig.FormSize.HeightDef;
            this.Width = DesignConfig.FormSize.WidthDef;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(
                DesignConfig.FormSize.XDef,
                DesignConfig.FormSize.YDef);
        }
    }
}