using ScopeIDE.LocationManagment.Configs.Sides;

namespace ScopeIDE.LocationManagment.Configs {
    public class LocationManagerConfig : ILocationManagerConfig {
        public ILocationManagerSideConfig Up { get; set; }
        public ILocationManagerSideConfig Left { get; set; }
        public ILocationManagerSideConfig StaticLeft { get; set; }
        public LocationManagerConfig(ILocationManagerSideConfig up, ILocationManagerSideConfig staticLeft, ILocationManagerSideConfig left) {
            Up = up;
            StaticLeft = staticLeft;
            Left = left;
        }
    }
}