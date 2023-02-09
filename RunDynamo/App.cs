#region Namespaces
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Dynamo.Core;
using Dynamo.Applications;
using System.Windows;

using Image = System.Drawing.Image;

#endregion

namespace RunDynamo
{
    class App : IExternalApplication
    {
        const string RIBBON_TAB = "BIMTEC";
        const string RIBBON_PANEL1 = "BIMTEC Panel";


        public Result OnStartup(UIControlledApplication a)
        {
            // get the ribbon tab
            try
            {
                a.CreateRibbonTab(RIBBON_TAB);
            }
            catch (Exception) { } // tab already exists

            // get or create the panel
            RibbonPanel panel1 = null;

            List<RibbonPanel> panels = a.GetRibbonPanels(RIBBON_TAB);
            foreach (RibbonPanel pnl in panels)
            {
                if (pnl.Name == RIBBON_PANEL1)
                {
                    panel1 = pnl;
                    break;
                }

            }

            // couldn't find the panel, create it
            if (panel1 == null)
            {
                panel1 = a.CreateRibbonPanel(RIBBON_TAB, RIBBON_PANEL1);
            }


            // get the image for the button
            //Image img = logo;
            //ImageSource imgsrc = GetImageSource(img);


            // create the button data
            PushButtonData btnData = new PushButtonData(
                "RunDynamoScipts",
                "RunDynamoScipts",
                Assembly.GetExecutingAssembly().Location,
                "RunDynamo.Command"
                )
            {
                ToolTip = "Add Tool Tip",
                LongDescription = "BIMTEC Long Desc",
                //Image = imgSrc,
                //LargeImage = imgSrc
            };

  

      

       

            // add the button to the ribbon
            PushButton button = panel1.AddItem(btnData) as PushButton;
            button.Enabled = true;
     

 



            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }

        /* protected void BtnConfirm_Click(object sender, EventArgs e)  // Website redirect test for the button  
         {
             Response.Redirect("Confirm.apx");
         } */

        private BitmapSource GetImageSource(Image img)
        {
            BitmapImage bmp = new BitmapImage();

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                ms.Position = 0;

                bmp.BeginInit();

                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.UriSource = null;
                bmp.StreamSource = ms;

                bmp.EndInit();
            }

            return bmp;
        }
    }
}