using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ScopeIDE.libs.ControlExt {
    public static class ControlCollectionExt {
        public static List<Control> ToList(Control.ControlCollection collection) {
            List<Control> controls = new List<Control>();
            foreach (Control o in collection) {
                controls.Add(o);
            }

            return controls;
        }
    }
}