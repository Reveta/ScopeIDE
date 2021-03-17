using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScopeIDE.Config;
using ScopeIDE.Config.Implementation;
using ScopeIDE.Config.Implementation.Def;
using ScopeIDE.Config.Implementation.FunJeka;
using ScopeIDE.Config.Implementation.Light;
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
                PanelInstrument = new PanelInstrumentDef(),
                ColorConfig = new ColorConfigJekaFun1()
            };

            Application.Run(new FormMain(designConfigDef));
        }
    }
}