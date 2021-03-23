using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScopeIDE.LocationManagment {
    public class LocationContainers {
        public int Position { get; set; }
        public LocationSide LocationSide { get; set; }

        public Size Size => Panel.Size;

        public UserControl Panel { get; set; }

        public LocationContainers(UserControl panel, LocationSide side, int position) {
            this.Panel = panel;
            this.LocationSide = side;
            this.Position = position;
        }

        public void SetLocation(int configsXLevel, int configsYLevel) {
            Panel.Location = new Point(configsXLevel, configsYLevel);
        }
    }
}