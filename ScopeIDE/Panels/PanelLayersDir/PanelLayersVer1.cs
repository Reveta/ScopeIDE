using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Elements;
using ScopeIDE.Elements.Panels.PanelInstruments;
using ScopeIDE.Elements.Panels.PanelLayer;
using ScopeIDE.Elements.Panels.PanelLayer.Buttons;
using ScopeIDE.libs.ControlExt;
using ScopeIDE.LocationManagment;
using ScopeIDE.LocationManagment.Configs;
using ScopeIDE.Panels.PanelTemplates;

namespace ScopeIDE.Panels.PanelLayersDir {
    public partial class PanelLayersVer1 : APanelTemplateWB, IEventFormResize, IReLocateControl {
        public IDesignConfig DesignConfig { get; }
        public LocationManager LocationManager { get; set; }

        private UserControl _layersBack;
        private ButtonTransform _buttonTransform1;


        public PanelLayersVer1(IDesignConfig designConfig, Point location) : base(location) {
            DesignConfig = designConfig;
            AddTransformButton();

            AddButton(new AButtonLayerInstrument(designConfig) {Text = "😁"});
            AddButton(new AButtonLayerInstrument(designConfig) {Text = "🤣"});
            AddButton(new AButtonLayerInstrument(designConfig) {Text = "😊"});
            AddButton(new AButtonLayerInstrument(designConfig) {Text = "😂"});
            AddButton(new AButtonLayerInstrument(designConfig) {Text = "😒"});
            AddButton(new AButtonLayerInstrument(designConfig) {Text = "🤷‍"});

            AddButtonLayer(new ButtonLayerVer2(designConfig, new ButtonLayerControllerMock())); 
            AddButtonLayer(new ButtonLayerVer2(designConfig, new ButtonLayerControllerMock()));
            AddButtonLayer(new ButtonLayerVer2(designConfig, new ButtonLayerControllerMock()));

            AddLayersBack();

            InitializeComponent();
        }

        private void AddTransformButton() {
            _buttonTransform1 = new ButtonTransform(DesignConfig) {
                Text = "<<<",
                Location = new Point(0, DesignConfig.Resources.RetreatSize),
            };

            this.Controls.Add(_buttonTransform1);
        }

        private void AddLayersBack() {
            _layersBack = new UserControl() {
                BackColor = this.DesignConfig.ColorConfig.MainBackColor
            };

            this.Controls.Add(_layersBack);
        }

        public override void AddButton(Button button, bool onlyPosition = false) {
            int count = this.GetAllButtons().Count;
            button.Name = "buttonInstrument" + count;
            button.TabIndex = count;

            if (!onlyPosition) {
                button.FlatStyle = FlatStyle.Flat;

                button.Font = new Font(
                    DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.FontName,
                    DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.FontSize,
                    DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.FontStyle
                );

                button.FlatAppearance.BorderSize = 0;
                button.Margin = new Padding(0);

                button.Size = new Size(
                    DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Width,
                    DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Height);

                button.TabStop = false;
                button.TextAlign = ContentAlignment.MiddleCenter;
                button.UseVisualStyleBackColor = false;
                button.AutoSize = false;
            }


            this.Controls.Add(button);
        }

        public void AddButtonLayer(Button button, bool onlyPosition = false) {
            int count = this.GetAllButtons().Count;
            button.Name = "buttonLayer" + count;
            button.TabIndex = count;

            if (!onlyPosition) {
                button.FlatStyle = FlatStyle.Flat;

                button.Font = new Font(
                    DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontName,
                    DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontSize,
                    DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontStyle
                );

                button.FlatAppearance.BorderSize = 0;
                button.Margin = new Padding(0);

                button.Size = new Size(
                    DesignConfig.PanelLayerConfig.ButtonLayerConfig.Width,
                    DesignConfig.PanelLayerConfig.ButtonLayerConfig.Height);

                button.TabStop = false;
                button.TextAlign = ContentAlignment.MiddleCenter;
                button.UseVisualStyleBackColor = false;
                button.AutoSize = false;
            }

            this.Controls.Add(button);
        }


        public override void RePaint() {
            this.Width = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Width
                         + (DesignConfig.Resources.RetreatSize * 4);

            var controls = ControlCollectionExt.ToList(this.Controls);

            int xLevel = DesignConfig.Resources.RetreatSize;
            int yLevel = DesignConfig.Resources.RetreatSize;

            //add ButtonTransform
            _buttonTransform1.Location = new Point(0, yLevel);
            _buttonTransform1.Width = this.Width;
            _buttonTransform1.Height = DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Height;
            yLevel += _buttonTransform1.Height + DesignConfig.Resources.RetreatSize;

            //add ButtonInstrument
            int count = 0;
            controls.ForEach(control => {
                if (control is IButtonLayerInstrument) {
                    control.Location = new Point(xLevel, yLevel);
                    
                    xLevel += DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Width +
                              DesignConfig.Resources.RetreatSize;

                    count++;
                    if (count >= DesignConfig.PanelLayerConfig.InstrumentsInRow) {
                        count = 0;
                        xLevel = DesignConfig.Resources.RetreatSize;
                        yLevel += DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Height +
                                  DesignConfig.Resources.RetreatSize;
                    }
                }
            });
            
            //add BackgroundFon for ButtonLayer
            if (count != 0) {
                //Add new retreat if need
                yLevel += DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Height +
                          DesignConfig.Resources.RetreatSize;
            }

            _layersBack.Location = new Point(DesignConfig.Resources.RetreatSize, yLevel);
            _layersBack.Width = Width - (DesignConfig.Resources.RetreatSize * 2);
            _layersBack.Height = 0;

            //add ButtonLayer
            yLevel += DesignConfig.Resources.RetreatSize;
            xLevel = DesignConfig.Resources.RetreatSize * 2;
            int backHeight = 0;

            controls.ForEach(control => {
                if (control is IButtonLayer) {
                    control.Location = new Point(xLevel, yLevel);
                    
                    int addHeight = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Height + DesignConfig.Resources.RetreatSize;
                    yLevel += addHeight;
                    backHeight += addHeight;
                }
            });
            
            //set final height for panel and backButtonLayers
            _layersBack.Height = backHeight + DesignConfig.Resources.RetreatSize;
            this.Height = yLevel + DesignConfig.Resources.RetreatSize;
            
            ReLocateAll();
        }


        #region EventFormResize

        public void EventFormResize(Form form) {
            var controls = ControlCollectionExt.ToList(this.Controls);
            controls
                .FindAll(control => control is IButtonLayerInstrument)
                .ForEach(control => {
                    if (control is IEventFormResize element) {
                        element.EventFormResize(form);
                    }
                });

            //SetNew Width for ButtonLayer by count of ButtonInstruments
            DesignConfig.PanelLayerConfig.ButtonLayerConfig.WidthDef =
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.Width =
                    DesignConfig.PanelLayerConfig.InstrumentsInRow *
                    (DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Width + DesignConfig.Resources.RetreatSize) -
                    (DesignConfig.Resources.RetreatSize *3);

            RePaint();
            controls
                .FindAll(control => control is IButtonLayer)
                .ForEach(control => {
                    if (control is IEventFormResize element) {
                        element.EventFormResize(form);
                    }
                });
        }

        #endregion


        #region Initialize_region

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // PanelLayer
            // 
            this.AccessibleRole = AccessibleRole.MenuItem;
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor;
            this.BorderStyle = BorderStyle.None;
            this.Margin = new Padding(0);

            this.Name = "PanelLayer";
            this.ResumeLayout(false);
        }

        #endregion

        public void ReLocateAll() {
            LocationManager?.ReLocateAll();
        }
    }
}