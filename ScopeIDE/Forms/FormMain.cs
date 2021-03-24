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
using ScopeIDE.LocationManagment;
using ScopeIDE.LocationManagment.Configs;
using ScopeIDE.LocationManagment.Configs.Sides;
using ScopeIDE.Panels;
using ContextMenu = ScopeIDE.Elements.ContextMenu;

namespace ScopeIDE.Forms {
    public partial class FormMain : ShadowedForm, IFormResizable {
        public IDesignConfig DesignConfig { get; set; }
        private MyStyleExtenstion _styleExtenstion;
        private LocationManager _locationManager;
        public EScales Scales { get; set; }

        private PanelInstrument _panelInstrumentPanel1;
        private PanelInstrument _panelInstrumentPanel2;
        private PanelNavbar _panelNavbar1;
        private PanelToolBox _panelToolBox;
        private PanelMain _panelMain1;

        private int def = 4;

        public FormMain(IDesignConfig designConfig) {
            DoubleBuffered = true;
            DesignConfig = designConfig;
            components = new Container();
            UpdateScale();

            FormConfig();
            InitializeComponent();

            AddPanelMain();
            AddPanelNavbar();
            AddPanelInstrument();
            AddPanelLayer();
            AddPanelToolBox();
            AddLocationManager();
        }


        protected override void OnResize(EventArgs e) {
            UpdateScale();

            int coof = Scales switch {
                EScales.HD => DesignConfig.Scale.HD,
                EScales.FullHD => DesignConfig.Scale.FullHD,
                EScales.DoubleHD => DesignConfig.Scale.DoubleHD,
                EScales.FourHD => DesignConfig.Scale.FourHD,
                _ => DesignConfig.Scale.FullHD
            };

            DesignConfig.Resources.RetreatSize = (int) (def / 100f * coof);

            ControlCollectionExt.ToList(this.Controls).ForEach(control => {
                if (control is IEventFormResize element) {
                    element.EventFormResize(this);
                }
            });

            _locationManager?.UpdateDefValues(GetLocationManagerConfig());
            _locationManager?.ReLocateAll();
            base.OnResize(e);
        }

        private ILocationManagerConfig GetLocationManagerConfig() {
            Up up = new Up(
                DesignConfig.PanelNavbar.Height + DesignConfig.Resources.RetreatSize
            );

            StaticLeft staticLeft = new StaticLeft(
                0,
                up.Y + DesignConfig.PanelMainConfig.Height + DesignConfig.Resources.RetreatSize
            );

            Left left = new Left(
                DesignConfig.PanelToolBox.Width + DesignConfig.Resources.RetreatSize,
                up.Y + DesignConfig.PanelMainConfig.Height + DesignConfig.Resources.RetreatSize
            );

            return new LocationManagerConfig(up, staticLeft, left);
        }

        private void AddLocationManager() {
            _locationManager = new LocationManager(GetLocationManagerConfig(), DesignConfig);

            ControlCollectionExt.ToList(this.Controls).ForEach(control => {
                if (control is IReLocateControl reLocateControl) {
                    reLocateControl.LocationManager = _locationManager;
                }
            });


            _locationManager.AddPanel(_panelMain1, LocationSide.StaticUP, 1);
            _locationManager.AddPanel(_panelToolBox, LocationSide.StaticLeft, 1);
            _locationManager.AddPanel(_panelInstrumentPanel1, LocationSide.Left, 1);
            _locationManager.AddPanel(_panelInstrumentPanel2, LocationSide.Left, 2);

            _locationManager.ReLocateAll();
        }

        private void UpdateScale() {
            Scales = this.Width switch {
                <= (int) EScales.HD - 100 => EScales.HD,
                <= (int) EScales.FullHD - 100 => EScales.FullHD,
                <= (int) EScales.DoubleHD - 100 => EScales.DoubleHD,
                <= (int) EScales.FourHD - 100 => EScales.FourHD,
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
                this._panelInstrumentPanel2,
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
                DesignConfig.PanelInstrument.LocationYDef)
            ) {
                TabIndex = 3,
            };

            this.Controls.Add(_panelInstrumentPanel1);
        }

        private void AddPanelLayer() {
            DesignConfig.PanelInstrument.LocationXDef =
                DesignConfig.PanelToolBox.Button.Width + DesignConfig.Resources.RetreatSize +
                DesignConfig.Resources.RetreatSize;

            DesignConfig.PanelInstrument.LocationYDef =
                DesignConfig.PanelMainConfig.Height - DesignConfig.Resources.RetreatSize - 1;

            this._panelInstrumentPanel2 = new PanelInstrument(DesignConfig, new Point(
                DesignConfig.PanelInstrument.LocationXDef,
                DesignConfig.PanelInstrument.LocationYDef)
            ) {
                TabIndex = 3,
            };

            _panelInstrumentPanel2.BackColor = Color.Indigo;

            this.Controls.Add(_panelInstrumentPanel2);
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
            this._styleExtenstion = new MyStyleExtenstion(this, this.components);
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