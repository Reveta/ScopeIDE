using System;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Elements.PanelNavbar;

namespace ScopeIDE.Panels {
    public partial class PanelNavbar : APanelWithButtons {
        public IDesignConfig DesignConfig { get; set; }

        public PanelNavbar(IDesignConfig designConfig) {
            DesignConfig = designConfig;

            AddButton(new ButtonNavbar(){Text = "File"});
            AddButton(new ButtonNavbar(){Text = "Windows"});
            AddButton(new ButtonNavbar(){Text = "Edit"});
            AddButton(new ButtonNavbar(){Text = "View"});
            AddButton(new ButtonNavbar(){Text = "Navigate"});
            AddButton(new ButtonNavbar(){Text = "View"});
            AddButton(new ButtonNavbar(){Text = "Navigadsadasadte"});
            AddButton(new ButtonNavbar(){Text = "Windows"});
            AddButton(new ButtonNavbar(){Text = "Code"});

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

                button.BackColor = DesignConfig.ColorConfig.ContrBackColor;
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
            int x = 5;
            int y = (int) ((DesignConfig.PanelNavbar.Height - DesignConfig.PanelNavbar.Button.Height) / 2f);

            GetAllButtons().ForEach(button => {
                button.Location = new Point(x, y);
                x += button.Width + 5;
            });
            
            
            int height = DesignConfig.PanelNavbar.Height;
            this.Size = new Size(x+5, height);
        }


        private void InitializeComponent() {
            // 
            // PanelNavbar
            // 
            this.ResumeLayout(false);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor;
            this.Name = "PanelNavbar";
            this.PerformLayout();
        }
    }
}