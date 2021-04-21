using System.Drawing;

namespace ScopeIDE.Elements.Panels.PanelLayer.ButtonsLayerElements {
    public interface IButtonLayerController {

        public string Name { get; set; }
        public int Transparency { get; set; }
        public Bitmap GetLayerScreen();
        public void SetVisible(bool layerVisibleStatus);
    }
}