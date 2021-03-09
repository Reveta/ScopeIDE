using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Elements;
using ScopeIDE.Elements.PanelNavbar;
using ScopeIDE.Forms;
using ScopeIDE.libs.ControlExt;

namespace ScopeIDE.Panels {
    public partial class PanelNavbar : APanelWithButtons, IEventFormResize {
        public IDesignConfig DesignConfig { get; set; }

        public PanelNavbar(IDesignConfig designConfig) {
            DesignConfig = designConfig;
            this.DoubleBuffered = true;

            AddButton(new ButtonNavbar(designConfig){Text = "File"});
            AddButton(new ButtonNavbar(designConfig){Text = "Windows"});
            AddButton(new ButtonNavbar(designConfig){Text = "Edit"});
            AddButton(new ButtonNavbar(designConfig){Text = "View"});
            AddButton(new ButtonNavbar(designConfig){Text = "Navigate"});
            AddButton(new ButtonNavbar(designConfig){Text = "View"});
            AddButton(new ButtonNavbar(designConfig){Text = "Navigadsadasadte"});
            AddButton(new ButtonNavbar(designConfig){Text = "Windows"});
            AddButton(new ButtonNavbar(designConfig){Text = "Code"});

            InitializeComponent();
            RePaint();
        }

        public override void AddButton(Button button, bool onlyPosition = false) {
            int count = this.GetAllButtons().Count;
            button.Name = "buttonNavbar" + count;
            button.TabIndex = count;

            if (!onlyPosition) {
                button.FlatStyle = FlatStyle.Flat;

                button.Font = new Font(
                    DesignConfig.Resources.FontName,
                    DesignConfig.Resources.FontSize,
                    DesignConfig.Resources.FontStyle);

                button.BackColor = DesignConfig.ColorConfig.SecondBackColor;
                button.ForeColor = DesignConfig.ColorConfig.FontColorMain;

                button.FlatAppearance.BorderSize = 0;
                button.Margin = new Padding(0);

                button.Size = new Size(
                    DesignConfig.PanelNavbar.Button.Width,
                    DesignConfig.PanelNavbar.Button.Height);

                button.TabStop = false;
                button.TextAlign = ContentAlignment.BottomCenter;
                button.UseVisualStyleBackColor = false;
                button.AutoSize = true;
            }

            this.Controls.Add(button);
        }

        public override void RePaint() {
            int xMargin = 5;
            int yMargin = (int) ((DesignConfig.PanelNavbar.HeightDef - DesignConfig.PanelNavbar.Button.Height) / 1.9f);

            GetAllButtons().ForEach(button => {
                button.Location = new Point(xMargin, yMargin);
                xMargin += button.Width + 5;
            });
            
            this.Size = new Size(xMargin, DesignConfig.PanelNavbar.Height);   

        }


        public void EventFormResize(Form form) {
            ControlCollectionExt.ToList(this.Controls).ForEach(control => {
                if (control is IEventFormResize element) {
                    element.EventFormResize(form);
                }
            });
            
            RePaint();
        }

        private void InitializeComponent() {
            // 
            // PanelNavbar
            // 
            this.ResumeLayout(false);
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor;
            this.Name = "PanelNavbar";
            this.PerformLayout();
        }
    }
}