namespace ScopeIDE.LocationManagment.Configs.Sides {
    public class StaticLeft : ILocationManagerSideConfig {
        public int X { get; set; }
        public int Y { get; set; }

        public StaticLeft(int xLevel, int yLevel) {
            X = xLevel;
            Y = yLevel;
        }
    }
}