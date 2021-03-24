using ScopeIDE.LocationManagment.Configs.Sides;

namespace ScopeIDE.LocationManagment.Configs {
    public class LocationManagerConfig : ILocationManagerConfig {
        public ILocationSideConfig StaticUp { get; set; }
        public ILocationSideConfig Left { get; set; }
        public ILocationSideConfig StaticLeft { get; set; }
        public LocationManagerConfig(ILocationSideConfig staticUp, ILocationSideConfig staticLeft, ILocationSideConfig left) {
            StaticUp = staticUp;
            StaticLeft = staticLeft;
            Left = left;
        }
    }
}