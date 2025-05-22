using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assembly = System.Reflection.Assembly;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using System.Security;

namespace Beametric.General
{
    public static class Globals
    {
        #region Properties
        //Properties

        //Properties-Applications
        public static UIControlledApplication UiCtlApp { get; set; }
        public static ControlledApplication CtlApp { get; set; }
        public static UIApplication UiApp { get; set; }

        //Properties-Assembly, info about dll
        public static Assembly assembly { get; set; }
        public static string AssemblyPath { get; set; }

        //Properties-Revit versions
        public static string RevitVersion { get; set; }
        public static int RevitVersionInt { get; set; }

        //Properties-User names
        public static string UsernameRevit { get; set; }
        public static string UsernameWindows { get; set; }

        //Properties-Guids and versioning
        public static string AddinVersionNumber { get; set; }
        public static string AddinVersionName { get; set; }
        public static string AddinName { get; set; }
        public static string AddinGuid { get; set; }

        //Properties-Dictionaries
        public static Dictionary<String, string> Tooltip { get; set; } = new Dictionary<string, string>();
        #endregion
    }
}
