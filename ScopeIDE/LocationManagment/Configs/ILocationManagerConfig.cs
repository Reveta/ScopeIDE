namespace ScopeIDE.LocationManagment.Configs {
    public interface ILocationManagerConfig {
        public ILocationManagerSideConfig StaticUp { get; set; }
        public ILocationManagerSideConfig Left { get; set; }


    }
}