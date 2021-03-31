using System.Windows.Forms;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Elements {
    public abstract partial class AButtonColorDepend : Button {
        public IColorConfig ColorConfig { get; set; }
        
        public AButtonColorDepend(IColorConfig colorConfig) {
            ColorConfig = colorConfig;
            InitializeComponent();
        }
    }
}