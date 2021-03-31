using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Elements;
using ScopeIDE.Elements.Panels.PanelMain;
using ScopeIDE.libs.ControlExt;
using ScopeIDE.Panels.PanelTemplates;

namespace ScopeIDE.Panels {
    public partial class PanelMain : APanelTemplateWB, IEventFormResize{

        public IDesignConfig DesignConfig { get; set; }
        public PanelMain(IDesignConfig designConfig, Point location) : base(location) {
            DesignConfig = designConfig;
            DoubleBuffered = true;
            
            AddButton(new AButtonMainInstrument(designConfig){Text = "😁"});
            AddButton(new AButtonMainInstrument(designConfig){Text = "😂"});
            AddButton(new AButtonMainInstrument(designConfig){Text = "😊"});
            AddButton(new AButtonMainInstrument(designConfig){Text = "🤣"});
            AddButton(new PartitionMainPanel(designConfig), true);
            AddButton(new AButtonMainInstrument(designConfig){Text = "❤"});
            AddButton(new AButtonMainInstrument(designConfig){Text = "😍"});
            AddButton(new AButtonMainInstrument(designConfig){Text = "😁"});
            AddButton(new AButtonMainInstrument(designConfig){Text = "😂"});
            AddButton(new AButtonMainInstrument(designConfig){Text = "😊"});
            AddButton(new AButtonMainInstrument(designConfig){Text = "🤣"});
            AddButton(new PartitionMainPanel(designConfig), true);
            AddButton(new AButtonMainInstrument(designConfig){Text = "🤣"});
            AddButton(new AButtonMainInstrument(designConfig){Text = "😁"});

            InitializeComponent();
            RePaint();
        }

        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            this.ResumeLayout(false);
            
            RePaint();
            this.Name = "PanelMain";
            this.PerformLayout();
        }

        public override void AddButton(Button button, bool onlyPosition = false) {
            int count = this.GetAllButtons().Count;
            button.Name = "buttonMainInstrument" + count;
            button.TabIndex = count;

            if (!onlyPosition) {
                button.FlatStyle = FlatStyle.Flat;

                button.FlatAppearance.BorderSize = 0;
                button.Margin = new Padding(0);

                button.Size = new Size(
                    DesignConfig.PanelMainConfig.Button.Width,
                    DesignConfig.PanelMainConfig.Button.Height);

                button.TabStop = false;
                button.TextAlign = ContentAlignment.MiddleCenter;
                button.UseVisualStyleBackColor = false;
                button.AutoSize = false;
            }

            this.Controls.Add(button);
        }

        public override void RePaint() {
            int xMargin = DesignConfig.Resources.RetreatSize;;
            int yMargin = (int) ((DesignConfig.PanelMainConfig.Height - DesignConfig.PanelMainConfig.Button.Height) / 2f);
            ControlCollectionExt.ToList(this.Controls).ForEach(control => {
                control.Location = new Point(xMargin, yMargin);
                xMargin += control.Width + DesignConfig.Resources.RetreatSize;;
            });
            
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor;
            this.Height = DesignConfig.PanelMainConfig.Height;
            this.Width = DesignConfig.PanelMainConfig.Width;
        }

        public void EventFormResize(Form form) {
            ControlCollectionExt.ToList(this.Controls).ForEach(control => {
                if (control is IEventFormResize element) {
                    element.EventFormResize(form);
                }
            });
            
            DesignConfig.PanelMainConfig.Width = form.Width;
            DesignConfig.PanelMainConfig.Height = DesignConfig.PanelMainConfig.Button.Height + (DesignConfig.Resources.RetreatSize * 2);
            
            RePaint();
        }
    }
}