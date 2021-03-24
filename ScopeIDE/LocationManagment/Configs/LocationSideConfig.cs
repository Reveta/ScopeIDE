using System;
using ScopeIDE.Config.Interfaces;

namespace ScopeIDE.LocationManagment.Configs {
    public class LocationSideConfig {
        private LocationSide Side { get; set; }
        public ILocationManagerConfig ManagerConfig { get; set; }
        public IDesignConfig DesignConfig { get; set; }

        public int XLevel { get; set; }
        public int YLevel { get; set; }

        public LocationSideConfig(LocationSide side, ILocationManagerConfig managerConfig, IDesignConfig designConfig) {
            Side = side;
            ManagerConfig = managerConfig;
            DesignConfig = designConfig;

            CleanPositions(managerConfig);
        }

        public void AddToLevels(LocationContainers cont) {
            YLevel = Side switch {
                LocationSide.StaticUP => YLevel + cont.Size.Height + DesignConfig.Resources.RetreatSize,
                LocationSide.Left => YLevel + cont.Size.Height + DesignConfig.Resources.RetreatSize,
                LocationSide.StaticLeft => YLevel + cont.Size.Height + DesignConfig.Resources.RetreatSize
            };
        }

        public void CleanPositions(ILocationManagerConfig managerConfig) {
            ManagerConfig = managerConfig;
            
            switch (Side) {
                case LocationSide.StaticUP:
                    XLevel = ManagerConfig.StaticUp.X;
                    YLevel = ManagerConfig.StaticUp.Y;
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