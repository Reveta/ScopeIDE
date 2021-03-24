namespace ScopeIDE.LocationManagment.Configs {
    public interface ILocationManagerConfig {
        public ILocationSideConfig StaticUp { get; set; }
        public ILocationSideConfig Left { get; set; }
        public ILocationSideConfig StaticLeft { get; set; }


    }
}