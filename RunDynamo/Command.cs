#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Dynamo.Core;
using Dynamo.Applications;
using System.Reflection;
using RunDynamo.ViewsModels;
using System.Xml.Linq;
using System.Linq;
using Dynamo.Applications.Models;
using Dynamo.Controls;
using Dynamo.ViewModels;
using System.Windows;
using System.Windows.Controls;
using static Dynamo.Applications.DynamoRevit;
using static Dynamo.ViewModels.SearchViewModel;

#endregion

namespace RunDynamo
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {



            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;


            var viewModel = new dynamoViewModel(uiapp);
            viewModel.ShowDialog();








            return Result.Succeeded;

            }


             
            }
        }

        
    
