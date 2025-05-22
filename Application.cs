using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;

namespace Beametric
{
    public class Application : IExternalApplication

    {
        private PushButton pushButton;

        // original user comment
        // static void AddRibbonPanel(UIControlledApplication application)
        // {
        // }

        private void AddRibbonPanelInstance(UIControlledApplication application)
        {
            // create custom ribbon tab
            String tabName = "Beametric";
            application.CreateRibbonTab(tabName);

            // Add a new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Drafting");

            // get .dll assembly path
            string thisAssembplyPath = Assembly.GetExecutingAssembly().Location;

            // create push button
            PushButtonData b1Data = new(
                "MoveDimText",
                "Move" + System.Environment.NewLine + "Dim",
                thisAssembplyPath,
                "Cmd_MoveDimText.MoveDimText");

            pushButton = ribbonPanel.AddItem(b1Data) as PushButton;
            pushButton.ToolTip = "Select a dimension to move the joint text";
            BitmapImage pb1Imange = new(new Uri("pack://application:,,,/Beametric;component/Resources/Icons/MoveDimText32-Light.png"));
            pushButton.LargeImage = pb1Imange;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            // do nothing
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            // call our method creating ribbon panel
            AddRibbonPanelInstance(application);
            return Result.Succeeded;
        }
    }
}