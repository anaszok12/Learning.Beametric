using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
#if REVIT2024_OR_GREATER
using Autodesk.Revit.UI.Events;
#endif

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

#if REVIT2024_OR_GREATER
            updateImageByTheme();
            application.ThemeChanged += ThemeChanged;
#else
            BitmapImage pb1Imange = new(new Uri("pack://application:,,,/Beametric;component/Resources/Icons/MoveDimText32-Light.png"));
            pushButton.LargeImage = pb1Imange;
#endif
        }

#if REVIT2024_OR_GREATER
        private void setButtonLargeImage(string largePicName)
        {
            string largeImageUri = $"pack://application:,,,/Beametric;component/Resources/Icons/{largePicName}";
            pushButton.LargeImage = new System.Windows.Media.Imaging.BitmapImage(new Uri(largeImageUri));
        }

        private void updateImageByTheme()
        {
            UITheme theme = UIThemeManager.CurrentTheme;
            switch (theme)
            {
                case UITheme.Dark:
                    setButtonLargeImage("MoveDimText32-Dark.png");
                    break;
                case UITheme.Light:
                    setButtonLargeImage("MoveDimText32-Light.png");
                    break;
            }
        }

        private void ThemeChanged(object sender, ThemeChangedEventArgs e)
        {
            updateImageByTheme();
        }
#endif

        public Result OnShutdown(UIControlledApplication application)
        {
            // do nothing
#if REVIT2024_OR_GREATER
            application.ThemeChanged -= ThemeChanged;
#endif
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