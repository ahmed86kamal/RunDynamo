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



            var modelState = DynamoRevit.ModelState;


            TaskDialog td = new TaskDialog("Test")
            {
                Title = "Dynamo status",
                MainInstruction = modelState.ToString(),
                AllowCancellation = false,
                CommonButtons = TaskDialogCommonButtons.Ok
            };

            td.Show();

            if (modelState.ToString() == "NotStarted")
            {
                string Dynamo_Journal_Path = @"C:\Users\Badmin\Desktop\test 01.dyn";



                DynamoRevit dynamoRevit = new DynamoRevit();

                DynamoRevitCommandData dynamoRevitCommandData = new DynamoRevitCommandData();


                dynamoRevitCommandData.Application = commandData.Application;


                IDictionary<string, string> journalData = new Dictionary<string, string>
            {

                {Dynamo.Applications.JournalKeys.ShowUiKey, false.ToString() }, // don't show DynamoUI at runtime
                {Dynamo.Applications.JournalKeys.AutomationModeKey, true.ToString() }, // run journal automatically
                {Dynamo.Applications.JournalKeys.DynPathKey, Dynamo_Journal_Path }, // run node at this file path
                {Dynamo.Applications.JournalKeys.DynPathExecuteKey, true.ToString() }, // The journal file can specify if the Dynamo workspace opened
                {Dynamo.Applications.JournalKeys.ForceManualRunKey, false.ToString() }, // don't run in manual mode
                {Dynamo.Applications.JournalKeys.ModelShutDownKey, true.ToString() },
                {Dynamo.Applications.JournalKeys.ModelNodesInfo, false.ToString() }
            };

                dynamoRevitCommandData.JournalData = journalData;
                Result externalCommandResult = dynamoRevit.ExecuteCommand(dynamoRevitCommandData);



                return externalCommandResult;
            }
            else
            {

                TaskDialog tda = new TaskDialog("Error Message")
                {
                    Title = "Dynamo Is Open",
                    MainInstruction = "Please Close Dynamo Window and Reuse the Plugin",
                    AllowCancellation = false,
                    CommonButtons = TaskDialogCommonButtons.Ok
                };
                tda.Show();

               

                return Result.Succeeded;

            }


             
            }
        }

        }
    
