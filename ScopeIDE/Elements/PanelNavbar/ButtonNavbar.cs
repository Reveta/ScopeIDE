using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.PanelNavbar {
    public partial class ButtonNavbar : Button, IEventFormResize {
        public IDesignConfig DesignConfig;

        public ButtonNavbar(IDesignConfig designConfig) {
            DesignConfig = designConfig;
            this.TextAlign = ContentAlignment.TopCenter;
            this.Padding = Padding.Empty;
            this.Margin = Padding.Empty;

            this.Height = DesignConfig.PanelNavbar.Height;
            
            this.DoubleBuffered = true;
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


                var newWidth = 0;
                this.Width = newWidth; //Set minWidth, it will be automatic resize, but without it it can`t resize to lower
                this.Height = DesignConfig.PanelNavbar.LogoHeight;
            }

        }
    }
}