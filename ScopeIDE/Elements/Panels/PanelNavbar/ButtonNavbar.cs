using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.Panels.PanelNavbar {
    public partial class ButtonNavbar : Button, IEventFormResize {
        public IDesignConfig DesignConfig;

        public ButtonNavbar(IDesignConfig designConfig) {
            DesignConfig = designConfig;
            DesignConfig.PanelNavbar.Button.Height = this.Height;
            
            InitializeComponent();
        }

        public void EventFormResize(Form form) {
            if (form is IFormResizable formResizable) {
                DesignConfig.PanelNavbar.Button.FontSize =
                    (int) (DesignConfig.PanelNavbar.Button.FontSizeDef / 100 *  formResizable.Scales switch {
                        EScales.HD => DesignConfig.Scale.HD,
                        EScales.FullHD => DesignConfig.Scale.FullHD,
                        EScales.DoubleHD => DesignConfig.Scale.DoubleHD,
                        EScales.FourHD => DesignConfig.Scale.FourHD,
                        _ => DesignConfig.Scale.FourHD
                    });
                
                this.Font = new Font(
                    DesignConfig.PanelNavbar.Button.FontName,
                    DesignConfig.PanelNavbar.Button.FontSize,
                    DesignConfig.PanelNavbar.Button.FontStyle
                );

                this.Width  = DesignConfig.PanelNavbar.Button.Width;
                this.Height = DesignConfig.PanelNavbar.LogoHeight;
            }

        }
    }
}