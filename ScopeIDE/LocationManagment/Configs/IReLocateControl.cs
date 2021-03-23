namespace ScopeIDE.LocationManagment.Configs {
    public interface IReLocateControl {
        public LocationManager LocationManager { get; set; }

        public void ReLocateAll();

    }
}