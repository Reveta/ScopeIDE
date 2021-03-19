using System.Windows.Forms;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Elements {
    public abstract partial class ButtonColorDepend : Button {
        public IColorConfig ColorConfig { get; set; }
        
        public ButtonColorDepend(IColorConfig colorConfig) {
            ColorConfig = colorConfig;
            InitializeComponent();
        }
    }
}