using System;
using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Forms;

namespace ScopeIDE.Elements.Panels.PanelLayer {
    public partial class ButtonLayer : ButtonColorDepend, IButtonLayer, IEventFormResize {
        public IDesignConfig DesignConfig { get; }
        public IButtonLayerController ButtonLayerController { get; }
        private UserControl _layerScreen;

        public ButtonLayer(IDesignConfig designConfig, IButtonLayerController buttonLayerController) : base(designConfig.ColorConfig) {
            DesignConfig = designConfig;
            ButtonLayerController = buttonLayerController;
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor;
            
            
            UpdateLayerScreen();

            InitializeComponent();
        }

        private void UpdateLayerScreen() {
            _layerScreen ??= new UserControl();

            var retreat = DesignConfig.Resources.RetreatSize;
            var layerScreenBackgroundImage = ButtonLayerController.GetLayerScreen();
            _layerScreen.BackgroundImage = layerScreenBackgroundImage;
            _layerScreen.Width = this.Height - (retreat * 2);
            _layerScreen.Height = this.Height - (retreat * 2);
            _layerScreen.Location = new Point(retreat, retreat);
            
            this.Controls.Add(_layerScreen);
        }

        public void EventFormResize(Form form) {
            if (form is not IFormResizable formResizable) return;

            UpdateLayerScreen();
            
            int coof = formResizable.Scales switch {
                EScales.HD => DesignConfig.Scale.HD,
                EScales.FullHD => DesignConfig.Scale.FullHD,
                EScales.DoubleHD => DesignConfig.Scale.DoubleHD,
                EScales.FourHD => DesignConfig.Scale.FourHD,
                _ => DesignConfig.Scale.FullHD
            };

            DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontSize = DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontSizeDef / 100 * coof;

            DesignConfig.PanelLayerConfig.ButtonLayerConfig.Height =
                (int) (DesignConfig.PanelLayerConfig.ButtonLayerConfig.HeightDef / 100f * coof);

            
            this.Width = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Width;
            this.Height = DesignConfig.PanelLayerConfig.ButtonLayerConfig.Height;
            this.Font = new Font(
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontName,
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontSize,
                DesignConfig.PanelLayerConfig.ButtonLayerConfig.FontStyle
            );
        }
    }
}