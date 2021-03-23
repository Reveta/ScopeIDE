using System;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.LocationManagment.Configs {
    public class LocationSideConfig {
        private LocationSide Side { get; set; }
        public LocationManagerConfig ManagerConfig { get; set; }
        public IDesignConfig DesignConfig { get; set; }

        public int XLevel { get; set; }
        public int YLevel { get; set; }

        public LocationSideConfig(LocationSide side, LocationManagerConfig managerConfig, IDesignConfig designConfig) {
            Side = side;
            ManagerConfig = managerConfig;
            DesignConfig = designConfig;

            CleanPositions(managerConfig);
        }

        public void AddToLevels(LocationContainers cont) {
            YLevel = Side switch {
                LocationSide.UP => YLevel + cont.Size.Height + DesignConfig.Resources.RetreatSize,
                LocationSide.Left => YLevel + cont.Size.Height + DesignConfig.Resources.RetreatSize,
                LocationSide.StaticLeft => YLevel + cont.Size.Height + DesignConfig.Resources.RetreatSize
            };
        }

        public void CleanPositions( LocationManagerConfig managerConfig) {
            ManagerConfig = managerConfig;
            
            switch (Side) {
                case LocationSide.UP:
                    XLevel = ManagerConfig.Up.X;
                    YLevel = ManagerConfig.Up.Y;
                    break;
                case LocationSide.Left:
                     XLevel = ManagerConfig.Left.X;
                     YLevel = ManagerConfig.Left.Y;
                    break;
                case LocationSide.StaticLeft:
                     XLevel = ManagerConfig.StaticLeft.X;
                     YLevel = ManagerConfig.StaticLeft.Y;
                    break;

            }
        }
    }
}