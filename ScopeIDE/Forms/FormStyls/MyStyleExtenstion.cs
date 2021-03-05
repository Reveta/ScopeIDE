using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.libs.Egolds;

namespace ScopeIDE.Forms.FormStyls {
    public class MyStyleExtenstion : EgoldsFormStyle {
        public readonly IDesignConfig DesignConfig;

        public MyStyleExtenstion(FormMain scopeFormMain, IContainer container) : base(container) {
            DesignConfig = scopeFormMain.DesignConfig;
           
            StylesDictionary.Add(fStyle.ConfigBasedStyle,
                new EgoldsStyle() {
                    FormBorderStyle = FormBorderStyle.None,
                    BackColor = DesignConfig.ColorConfig.MainBackColor,
                    HeaderHeight = DesignConfig.PanelNavbar.Height,
                    HeaderColor = DesignConfig.ColorConfig.SecondBackColor,
                    HeaderTextColor = DesignConfig.ColorConfig.FontColorMain,
                    HeaderTextFont = new Font(
                        DesignConfig.Resources.FontName,
                        DesignConfig.Resources.FontSize,
                        DesignConfig.Resources.FontStyle
                        ),
                    ControlBoxButtonsWidth = HeaderHeight,
                    ControlBoxIconsSize = new Size(DesignConfig.PanelNavbar.Height / 5, DesignConfig.PanelNavbar.Height / 5),
                    UseSecondControlBoxIconsColorOnHover = true, // <-
                    ControlBoxEnabledIconsColor = DesignConfig.ColorConfig.FontColorMain,
                    IconSize = new Size(DesignConfig.PanelNavbar.LogoWidth, DesignConfig.PanelNavbar.LogoHeight),
                    ControlBoxOnHoverIconsColor = DesignConfig.ColorConfig.ContrBackColor,
                    
                    
                });

            this.AllowUserResize = true;
            // this.ContextMenuForm = new ContextMenuStrip(new Container());
            
            Form = scopeFormMain;
            FormStyle = fStyle.ConfigBasedStyle;

        }
    }
}