using System;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.Panels.PanelToolBoxs.ButtonAdd {
    public partial class AButtonToolBoxAdd : AButtonColorDepend, IEventFormResize {
        public IDesignConfig DesignConfig { get; }
        public Elements.ContextMenu ContextMenu { get; set; }
        private bool state;

        public AButtonToolBoxAdd(IDesignConfig designConfig, Elements.ContextMenu contextMenu) : base(designConfig.ColorConfig) {
            state = false;
            ContextMenu = contextMenu;

            DesignConfig = designConfig;
            Text = "+";

            InitializeComponent();
        }

        protected override void OnClick(EventArgs e) {
            ContextMenu.BringToFront();
            if (!state) {
                ContextMenu.Show();
                state = true;
            }
            else {
                ContextMenu.Hide();
                state = false;
            }
            base.OnClick(e);
        }

        public void EventFormResize(Form form) {
            if (form is not IFormResizable formResizable) return;

            int coof = formResizable.Scales switch {
                EScales.HD => DesignConfig.Scale.HD,
                EScales.FullHD => DesignConfig.Scale.FullHD,
                EScales.DoubleHD => DesignConfig.Scale.DoubleHD,
                EScales.FourHD => DesignConfig.Scale.FourHD,
                _ => DesignConfig.Scale.FullHD
            };

            DesignConfig.PanelInstrument.Button.Height =
                (int) (DesignConfig.PanelInstrument.Button.HeightDef / 100f * coof);

            this.Width = this.Parent.Width;
            
            this.Height = DesignConfig.PanelInstrument.Button.Height;
            this.Font = new Font(
                DesignConfig.PanelInstrument.Button.FontName,
                DesignConfig.PanelInstrument.Button.FontSize,
                DesignConfig.PanelInstrument.Button.FontStyle
            );
        }
    }
}