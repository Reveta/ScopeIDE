using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.Forms {
    public interface IFormResizable {
        public IDesignConfig DesignConfig { get; set; }
        public EScales Scales { get; set; }
    }
}