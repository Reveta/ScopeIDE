namespace ScopeIDE.LocationManagment.Configs.Sides {
    public class Up : ILocationManagerSideConfig {
        public int X { get; set; }
        public int Y { get; set; }

        public Up(int yUpLevel) {
            X = 0;
            Y = yUpLevel;
        }
    }
}