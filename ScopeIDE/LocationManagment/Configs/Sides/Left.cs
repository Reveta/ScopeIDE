namespace ScopeIDE.LocationManagment.Configs.Sides {
    public class Left : ILocationManagerSideConfig {
        public int X { get; set; }
        public int Y { get; set; }

        public Left(int xLevel, int yLevel) {
            X = xLevel;
            Y = yLevel;
        }
    }
}