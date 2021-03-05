using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Implementions;
using ScopeIDE.Config.Implementions.Def;
using ScopeIDE.Config.Implementions.Light;
using ScopeIDE.Config.Interfaces;
using ScopeIDE.Forms;
using ScopeIDE.Forms.FormStyls;

namespace ScopeIDE {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IDesignConfig designConfigDef = new DesignEmpty() {
                InstrumentPanel = new InstrumentPanelDef()
            };

            Application.Run(new FormMain(designConfigDef));


            
        }
    }
}