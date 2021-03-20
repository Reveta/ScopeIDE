using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.Panels.ContextMenu {
    public partial class ButtonContextMenuItem : Button, IEventFormResize {
        public IDesignConfig DesignConfig;

        public ButtonContextMenuItem(IDesignConfig designConfig) {
            DesignConfig = designConfig;
            DesignConfig.PanelNavbar.Button.Height = this.Height;

            InitializeComponent();
        }

        public void EventFormResize(Form form) {
            if (form is IFormResizable formResizable) {
                DesignConfig.PanelNavbar.Button.FontSize =
                    (int) (DesignConfig.PanelNavbar.Button.FontSizeDef / 100 * formResizable.Scales switch {
                        EScales.HD => DesignConfig.Scale.HD,
                        EScales.FullHD => DesignConfig.Scale.FullHD,
                        EScales.DoubleHD => DesignConfig.Scale.DoubleHD,
                        EScales.FourHD => DesignConfig.Scale.FourHD,
                        _ => DesignConfig.Scale.FourHD
                    });

                this.Font = new Font(
                    DesignConfig.ContextMenuConfig.ButtonConfig.FontName,
                    DesignConfig.ContextMenuConfig.ButtonConfig.FontSize,
                    DesignConfig.ContextMenuConfig.ButtonConfig.FontStyle
                );

                this.Padding = new Padding(
                    DesignConfig.Resources.RetreatSize,0,
                    DesignConfig.Resources.RetreatSize, 0);

                this.Width = DesignConfig.ContextMenuConfig.ButtonConfig.Width;
                this.Height = DesignConfig.ContextMenuConfig.ButtonConfig.Height;
            }
        }
    }
}