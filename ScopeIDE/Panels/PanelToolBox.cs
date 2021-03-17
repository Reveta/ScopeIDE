using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Elements;
using ScopeIDE.Elements.PanelInstruments;
using ScopeIDE.Elements.PanelNavbar;
using ScopeIDE.Elements.PanelToolBox;
using ScopeIDE.libs.ControlExt;

namespace ScopeIDE.Panels {
    public partial class PanelToolBox : APanelWithButtons, IEventFormResize {
        public IDesignConfig DesignConfig { get; set; }
        private readonly List<UserControl> _panels;

        public PanelToolBox(IDesignConfig designConfig, List<UserControl> panels) {
            _panels = panels;
            DesignConfig = designConfig;
            this.DoubleBuffered = true;
            
            SetPanels();

            InitializeComponent();
            RePaint();
        }

        private void SetPanels() {
            _panels.ForEach(panel => {
                AddButton(new ButtonToolBox(panel.Name, DesignConfig, panel));
            });
        }

        public override void AddButton(Button button, bool onlyPosition = false) {
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
                
                button.BackColor = DesignConfig.ColorConfig.SecondBackColor;
                button.ForeColor = DesignConfig.ColorConfig.FontColorMain;

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

            GetAllButtons().ForEach(button => {
                button.Location = new Point(xMargin, yMargin);
                yMargin += button.Height;
            });
            
            this.Size = new Size(DesignConfig.PanelToolBox.Width, DesignConfig.PanelToolBox.Height);
        }

        public void EventFormResize(Form form) {
            ControlCollectionExt.ToList(this.Controls).ForEach(control => {
                if (control is IEventFormResize element) {
                    element.EventFormResize(form);
                }
            });

            DesignConfig.PanelToolBox.Height = form.Height;
            DesignConfig.PanelToolBox.Width = DesignConfig.PanelToolBox.Button.Width;

            RePaint();
        }

        private void InitializeComponent() {
            this.ResumeLayout(false);
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor;
            this.BorderStyle = BorderStyle.None;
            this.Name = "panelToolBox";
            this.PerformLayout();
        }
    }
}