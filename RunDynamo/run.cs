using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Dynamo.Applications;
using RunDynamo.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RunDynamo
{
    public class run : CommandBase
    {
        public dynamoViewModel ViewModel { get; }
        public run(dynamoViewModel viewModel)
        {
            ViewModel = viewModel;
        }


        public override void Execute(object parameter)
        {

            var modelState = DynamoRevit.ModelState;


            TaskDialog td = new TaskDialog("Test")
            {
                Title = "Dynamo status",
                MainInstruction = modelState.ToString(),
                AllowCancellation = false,
                CommonButtons = TaskDialogCommonButtons.Ok
            };

            td.Show();

            if (modelState.ToString() == "StartedUI")
            {


                TaskDialog tda = new TaskDialog("Error Message")
                {
                    Title = "Dynamo Is Open",
                    MainInstruction = "Please Close Dynamo Window and Reuse the Plugin",
                    AllowCancellation = false,
                    CommonButtons = TaskDialogCommonButtons.Ok
                };
                tda.Show();


               
            }
            else
            {


                string Dynamo_Journal_Path = @"C:\Users\Badmin\source\repos\RunDynamo\RunDynamo\Resources\test 03.dyn";



                DynamoRevit dynamoRevit = new DynamoRevit();

                DynamoRevitCommandData dynamoRevitCommandData = new DynamoRevitCommandData();


                dynamoRevitCommandData.Application = ViewModel._UIApplication;


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



                //return externalCommandResult;


            }
        }
    }
}
