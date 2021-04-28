using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Elements;
using ScopeIDE.Elements.Panels.PanelNavbar;
using ScopeIDE.libs.ControlExt;
using ScopeIDE.Panels.PanelTemplates;

namespace ScopeIDE.Panels {
    public partial class PanelNavbar : APanelTemplateWB, IEventFormResize {
        public IDesignConfig DesignConfig { get; set; }

        public PanelNavbar(IDesignConfig designConfig, Point location) : base(location) {
            DesignConfig = designConfig;
            this.DoubleBuffered = true;

            AddButtonInstrument(new ButtonNavbar(designConfig){Text = "File"});
            AddButtonInstrument(new ButtonNavbar(designConfig){Text = "Windows"});
            AddButtonInstrument(new ButtonNavbar(designConfig){Text = "Edit"});
            AddButtonInstrument(new ButtonNavbar(designConfig){Text = "View"});
            AddButtonInstrument(new ButtonNavbar(designConfig){Text = "Navigate"});
            AddButtonInstrument(new ButtonNavbar(designConfig){Text = "View"});
            AddButtonInstrument(new ButtonNavbar(designConfig){Text = "Navigadsadasadte"});
            AddButtonInstrument(new ButtonNavbar(designConfig){Text = "Windows"});
            AddButtonInstrument(new ButtonNavbar(designConfig){Text = "Code"});

            InitializeComponent();
            RePaint();
        }

        public override void AddButtonInstrument(Button button, bool onlyPosition = false) {
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
                button.TextAlign = ContentAlignment.TopCenter;
                button.UseVisualStyleBackColor = false;
                button.AutoSize = true;
            }

            this.Controls.Add(button);
        }

        public override void RePaint() {
            int xMargin = 0;
            int yMargin = (int) ((DesignConfig.PanelNavbar.Height - DesignConfig.PanelNavbar.Button.Height) / 2f);

            GetAllButtons().ForEach(button => {
                button.Location = new Point(xMargin, yMargin);
                xMargin += button.Width;
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