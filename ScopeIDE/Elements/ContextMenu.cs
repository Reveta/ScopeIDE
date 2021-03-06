using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Forms;
using ScopeIDE.LocationManagment;
using ScopeIDE.LocationManagment.Configs;
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

            this.LostFocus += (sender, args) => {
                this.Hide();
            };
            
            Buttons = buttons;
            Buttons.ForEach(button => AddButtonInstrument(button));

            InitializeComponent();
            this.Hide();
        }

        public override void AddButtonInstrument(Button button, bool onlyPosition = false) {
            int count = this.GetAllButtons().Count;
            button.Name = "contextItem" + count;
            button.TabIndex = count;
            button.LostFocus += (sender, args) => this.Hide();

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

        public void EventFormResize(Form form) {
            Buttons.ForEach(button => {
                if (button is IEventFormResize element) {
                    button.AutoSize = false;
                    element.EventFormResize(form);
                }
            });
            
            int maxButtonWidth = 0;
            Buttons.ForEach(control => {
                if (control is IEventFormResize resize) {
                    control.AutoSize = true;
                    if (control.Width > maxButtonWidth) {
                        maxButtonWidth = control.Width;
                    }
                }
            });

            DesignConfig.ContextMenuConfig.ButtonConfig.WidthDef = maxButtonWidth;


            DesignConfig.ContextMenuConfig.Width = maxButtonWidth;

            DesignConfig.ContextMenuConfig.Height = 
            DesignConfig.ContextMenuConfig.ButtonConfig.Height * (Buttons.Count) 
            + (DesignConfig.Resources.RetreatSize * 2);

            RePaint();
            ReLocateAll();
        }

        public override void RePaint() {
            int xMargin = 0;
            int yMargin = DesignConfig.Resources.RetreatSize;

            Buttons.ForEach(button => {
                button.Location = new Point(xMargin, yMargin);
                button.Width = DesignConfig.ContextMenuConfig.ButtonConfig.WidthDef;
                yMargin += button.Height;
            });

            this.Size = new Size(DesignConfig.ContextMenuConfig.Width, DesignConfig.ContextMenuConfig.Height);
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
            LocationManager?.ReLocateAll();
        }
        
    }
}