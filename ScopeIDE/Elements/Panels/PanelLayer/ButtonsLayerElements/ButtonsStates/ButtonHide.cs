using System.Drawing;
using System.Windows.Forms;
using ScopeIDE.Config;

namespace ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements.ButtonsStates {
    public partial class ButtonHide : AButtonLayerInstrument {
        public IButtonLayerController ButtonLayerController { get; }
        private bool _layerVisibleStatus = true;

        public ButtonHide(IDesignConfig designConfig, IButtonLayerController buttonLayerController) :
            base(designConfig) {
            ButtonLayerController = buttonLayerController;
            this.BackColor = DesignConfig.ColorConfig.SecondBackColor; //TODO Why it`s not depend on base class??

            UpdateIcon();
            InitializeComponent();
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(PanelMain.ButtonInstrument));
            this.SuspendLayout();

            FlatStyle = FlatStyle.Flat;

            Font = new Font(
                DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.FontName,
                DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.FontSize,
                DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.FontStyle
            );

            FlatAppearance.BorderSize = 0;
            Margin = new Padding(0);

            Size = new Size(
                DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Width,
                DesignConfig.PanelLayerConfig.ButtonInstrumentsConfig.Height);

            TabStop = false;
            TextAlign = ContentAlignment.MiddleCenter;
            UseVisualStyleBackColor = false;
            AutoSize = false;

            this.ResumeLayout(false);
        }

        protected override void OnMouseClick(MouseEventArgs e) {
            _layerVisibleStatus = !_layerVisibleStatus;
            ButtonLayerController.SetVisible(_layerVisibleStatus);
            UpdateIcon();
            base.OnMouseClick(e);
        }

        private void UpdateIcon() {
            if (_layerVisibleStatus) {
                Text = "👁";
            }
            else {
                Text = "🥽";
            }
        }
    }
}