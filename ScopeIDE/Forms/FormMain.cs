using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Elements;
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

            AddPanelMain();
            AddPanelNavbar();
            AddPanelInstrument();
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
            DesignConfig.PanelNavbar.LocationXDef = DesignConfig.PanelNavbar.LogoWidth + 25;
            DesignConfig.PanelNavbar.LocationYDef = (DesignConfig.PanelNavbar.Height * -1) + 1;

            _panelNavbar1 = new PanelNavbar(DesignConfig, new Point(
                DesignConfig.PanelNavbar.LocationXDef,
                DesignConfig.PanelNavbar.LocationYDef
            )) {
                TabIndex = 0,
            };

            this.Controls.Add(_panelNavbar1);
        }

        private void AddPanelMain() {
            DesignConfig.PanelMainConfig.LocationXDef = 0;
            DesignConfig.PanelMainConfig.LocationYDef = 0 + DesignConfig.Resources.RetreatSize;

            this._panelMain1 = new PanelMain(DesignConfig, new Point(
                DesignConfig.PanelMainConfig.LocationXDef,
                DesignConfig.PanelMainConfig.LocationYDef
            )) {
                TabIndex = 1,
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

            DesignConfig.PanelToolBox.LocationXDef = 0;
            DesignConfig.PanelToolBox.LocationYDef = 55;
            _panelToolBox = new PanelToolBox(DesignConfig, panelsToolBox, contextMenu, new Point(
                DesignConfig.PanelToolBox.LocationXDef,
                DesignConfig.PanelToolBox.LocationYDef
            )) {
                TabIndex = 2,
            };

            this.Controls.Add(contextMenu);
            this.Controls.Add(_panelToolBox);
        }

        private void AddPanelInstrument() {
            DesignConfig.PanelInstrument.LocationXDef =
                DesignConfig.PanelToolBox.Button.Width + DesignConfig.Resources.RetreatSize +
                DesignConfig.Resources.RetreatSize;

            DesignConfig.PanelInstrument.LocationYDef =
                DesignConfig.PanelMainConfig.Height - DesignConfig.Resources.RetreatSize - 1;

            this._panelInstrumentPanel1 = new PanelInstrument(DesignConfig, new Point(
                DesignConfig.PanelInstrument.LocationXDef,
                DesignConfig.PanelInstrument.LocationYDef
                )) {
                TabIndex = 3,
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
                DesignConfig.FormSize.LocationXDef,
                DesignConfig.FormSize.LocationYDef);
        }
    }
}