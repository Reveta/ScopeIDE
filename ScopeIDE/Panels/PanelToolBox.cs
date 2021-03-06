using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Elements;
using ScopeIDE.Elements.Panels.PanelToolBoxs;
using ScopeIDE.Elements.Panels.PanelToolBoxs.ButtonAdd;
using ScopeIDE.libs.ControlExt;
using ScopeIDE.LocationManagment;
using ScopeIDE.LocationManagment.Configs;
using ScopeIDE.Panels.PanelTemplates;
using ContextMenu = ScopeIDE.Elements.ContextMenu;

namespace ScopeIDE.Panels {
    public partial class PanelToolBox : APanelTemplateWB, IEventFormResize, IReLocateControl {
        public IDesignConfig DesignConfig { get; set; }
        public LocationManager LocationManager { get; set; }
        private readonly List<UserControl> _panels;
        private ButtonToolBoxAdd ButtonToolBoxAdd { get; set; }
        private readonly ContextMenu _contextMenu;


        public PanelToolBox(
            IDesignConfig designConfig,
            List<UserControl> panels,
            ContextMenu contextMenu,
            Point location
                ) : base(location) {
            //TODO придумати як зберігати контекстне меню всередині
            _contextMenu = contextMenu;
            _panels = panels;
            DesignConfig = designConfig;

            SetPanels();
            InitializeComponent();
        }

        private void SetPanels() {
            //TODO split to many methods
            List<Button> addContextMenuButtons = new List<Button>();

            _panels.ForEach(panel => {
                if (panel is null){return;}
                var buttonToolBox = new ButtonToolBox(panel.Name, DesignConfig, panel, LocationManager);
                var menuItem = new ButtonToolBoxAddContextItem(DesignConfig, buttonToolBox, this) {
                    Text = panel.Name
                };

                buttonToolBox.Hide();
                AddButtonInstrument(buttonToolBox);
                addContextMenuButtons.Add(menuItem);
            });

            _contextMenu.Buttons = addContextMenuButtons;
            ButtonToolBoxAdd = new ButtonToolBoxAdd(this.DesignConfig, _contextMenu);
            AddButtonInstrument(ButtonToolBoxAdd);
        }

        public override void AddButtonInstrument(Button button, bool onlyPosition = false) {
            int count = this.GetAllButtons().Count;
            button.Name = "buttonToolbox" + count;
            button.TabIndex = count;

            if (!onlyPosition) {
                button.FlatStyle = FlatStyle.Flat;

                Font font = new Font(
                    DesignConfig.PanelToolBox.Button.FontName,
                    DesignConfig.PanelToolBox.Button.FontSize,
                    DesignConfig.PanelToolBox.Button.FontStyle
                );
                button.Font = font;

                button.FlatAppearance.BorderSize = 0;
                button.Margin = new Padding(0);

                button.Size = new Size(
                    DesignConfig.PanelToolBox.Button.Width,
                    DesignConfig.PanelToolBox.Button.Height);

                button.TabStop = false;
                button.UseVisualStyleBackColor = true;
                button.AutoSize = false;
            }

            this.Controls.Add(button);
        }

        public override void RePaint() {
            int xMargin = 0;
            int yMargin = DesignConfig.Resources.RetreatSize;

            //Paint special Add Button
            ButtonToolBoxAdd.Location = new Point(0, yMargin);
            yMargin += ButtonToolBoxAdd.Height + DesignConfig.Resources.RetreatSize;

            var allButtons = GetAllButtons();
            allButtons
                .FindAll(button => button.Visible)
                .FindAll(button => button != ButtonToolBoxAdd)
                .ForEach(button => {
                    button.Location = new Point(xMargin, yMargin);
                    yMargin += button.Height + DesignConfig.Resources.RetreatSize;;
                });

            _contextMenu.Location = new Point(
                base.Location.X + this.Width + DesignConfig.Resources.RetreatSize,
                base.Location.Y
            );
            
            this.Size = new Size(DesignConfig.PanelToolBox.Width, DesignConfig.PanelToolBox.Height);
            ReLocateAll();
        }

        public void EventFormResize(Form form) {
            ControlCollectionExt.ToList(this.Controls).ForEach(control => {
                if (control is IEventFormResize element) {
                    element.EventFormResize(form);
                }
                _contextMenu.EventFormResize(form);
            });

            DesignConfig.PanelToolBox.Height = form.Height;
            DesignConfig.PanelToolBox.Width = DesignConfig.PanelToolBox.Button.Width + (DesignConfig.Resources.RetreatSize);

            RePaint();
        }

        private void InitializeComponent() {
            this.ResumeLayout(false);
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor;
            this.BorderStyle = BorderStyle.None;
            this.Name = "panelToolBox";
            this.PerformLayout();
        }

        public void ReLocateAll() {
            ControlCollectionExt.ToList(this.Controls).ForEach(control => {
                if (control is IReLocateControl reLocateControl) {
                    reLocateControl.LocationManager = LocationManager;
                }
            });
            
            LocationManager?.ReLocateAll();
        }
    }
}