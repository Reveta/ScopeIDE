using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.LocationManagment.Configs;

namespace ScopeIDE.LocationManagment {
    public class LocationManager {
        private Dictionary<LocationSide, List<LocationContainers>> Containers { get; }
        private Dictionary<LocationSide, LocationSideConfig> LocationSideConfigs { get; }

        private ILocationManagerConfig _managerConfig;

        public LocationManager(ILocationManagerConfig managerConfig, IDesignConfig designConfig) {
            _managerConfig = managerConfig;
            LocationSideConfigs = new Dictionary<LocationSide, LocationSideConfig>();
            Containers = new Dictionary<LocationSide, List<LocationContainers>>();

            var allLocationSidesValues = Enum.GetValues(typeof(LocationSide)).Cast<LocationSide>().ToList();
            allLocationSidesValues.ForEach(side => {
                Containers.Add(side, new List<LocationContainers>());
                LocationSideConfigs.Add(side, new LocationSideConfig(side, _managerConfig, designConfig));
            });
        }

        public void UpdateDefValues(ILocationManagerConfig managerConfig) {
            _managerConfig = managerConfig;
        }

        public LocationManager AddPanel(UserControl control, LocationSide side, int position) {
            Containers[side].Add(new LocationContainers(control, side, position));
            return this;
        }

        public void ReLocateAll() {
            LocationSideConfigs.Keys.ToList().ForEach(side => LocationSideConfigs[side].CleanPositions(_managerConfig));

            Containers.Keys.ToList().ForEach(side => {
                var containersBySide = Containers[side];
                containersBySide.Sort((cont1, cont2) => cont2.Position - cont1.Position);
                containersBySide
                    .FindAll(containers => containers.Panel.Visible)
                    .ForEach(ReLoad);
            });
        }

        private void ReLoad(LocationContainers cont) {
            var configs = LocationSideConfigs[cont.LocationSide];

            cont.SetLocation(configs.XLevel, configs.YLevel);
            configs.AddToLevels(cont);
        }
    }
}