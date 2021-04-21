using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.LocationManagment;
using ScopeIDE.LocationManagment.Configs;
using ScopeIDE.Panels;
using ScopeIDE.Panels.PanelTemplates;

namespace ScopeIDE.Elements {
    //TODO Add OnLostFocus override
    public partial class ContextMenu : APanelWithButtons, IEventFormResize, IReLocateControl {
        private List<Button> _buttons;
        public IDesignConfig DesignConfig { get; set; }

        public List<Button> Buttons {
            get => _buttons;
            set {
                _buttons = value;
                Buttons.ForEach(button => AddButtonInstrument(button));
                RePaint();
            }
        }

        public ContextMenu(IDesignConfig designConfig, List<Button> buttons) {
            DesignConfig = designConfig;
            this.DoubleBuffered = true;

            Buttons = buttons;
            Buttons.ForEach(button => AddButtonInstrument(button));

            InitializeComponent();
            RePaint();
            this.Hide();
        }

        public override void AddButtonInstrument(Button button, bool onlyPosition = false) {
            int count = this.GetAllButtons().Count;
            button.Name = "contextItem" + count;
            button.TabIndex = count;

            if (!onlyPosition) {
                button.FlatStyle = FlatStyle.Flat;

                Font font = new Font(
                    DesignConfig.ContextMenuConfig.ButtonConfig.FontName,
                    DesignConfig.ContextMenuConfig.ButtonConfig.FontSize,
                    DesignConfig.ContextMenuConfig.ButtonConfig.FontStyle
                );
                button.Font = font;

                button.BackColor = DesignConfig.ColorConfig.SecondBackColor;
                button.ForeColor = DesignConfig.ColorConfig.FontColorMain;

                button.FlatAppearance.BorderSize = 0;
                button.Margin = new Padding(0);

                button.Size = new Size(
                    DesignConfig.ContextMenuConfig.ButtonConfig.Width,
                    DesignConfig.ContextMenuConfig.ButtonConfig.Height);

                button.TabStop = false;
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.UseVisualStyleBackColor = true;
                button.AutoSize = false;
            }

            this.Controls.Add(button);
        }

        public override void RePaint() {
            int xMargin = 0;
            int yMargin = DesignConfig.Resources.RetreatSize;

            Buttons.ForEach(button => {
                button.Location = new Point(xMargin, yMargin);
                yMargin += button.Height;
            });

            this.Size = new Size(DesignConfig.ContextMenuConfig.Width, DesignConfig.ContextMenuConfig.Height);
        }

        public void EventFormResize(Form form) {
            int maxButtonWidth = DesignConfig.ContextMenuConfig.ButtonConfig.WidthDef;
            
            Buttons.ForEach(control => {
                if (control.Width > maxButtonWidth) {
                    maxButtonWidth = control.Width;
                }
            });

            DesignConfig.ContextMenuConfig.Height = 
                Buttons.Count * DesignConfig.ContextMenuConfig.ButtonConfig.Height + 
                (DesignConfig.Resources.RetreatSize * 2);
            DesignConfig.ContextMenuConfig.ButtonConfig.Width = maxButtonWidth;
            DesignConfig.ContextMenuConfig.Width = maxButtonWidth;
            
            Buttons.ForEach(button => {
                if (button is IEventFormResize element) {
                    element.EventFormResize(form);
                }
            });

            RePaint();
            ReLocateAll();
        }

        private void InitializeComponent() {
            this.ResumeLayout(false);
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor;
            this.BorderStyle = BorderStyle.None;
            this.Name = "contextMenu";
            this.PerformLayout();
        }

        public LocationManager LocationManager { get; set; }
        public void ReLocateAll() {
            LocationManager.ReLocateAll();
        }
    }
}