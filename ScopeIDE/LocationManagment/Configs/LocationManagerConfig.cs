using ScopeIDE.LocationManagment.Configs.Sides;

namespace ScopeIDE.LocationManagment.Configs {
    public class LocationManagerConfig : ILocationManagerConfig {
        public ILocationManagerSideConfig StaticUp { get; set; }
        public ILocationManagerSideConfig Left { get; set; }
        public ILocationManagerSideConfig StaticLeft { get; set; }
        public LocationManagerConfig(ILocationManagerSideConfig staticUp, ILocationManagerSideConfig staticLeft, ILocationManagerSideConfig left) {
            StaticUp = staticUp;
            StaticLeft = staticLeft;
            Left = left;
        }
    }
}