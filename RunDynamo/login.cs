using Autodesk.Revit.DB;
using RunDynamo.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RunDynamo
{
    public class login : CommandBase
    {
        public dynamoViewModel ViewModel { get; }
        public login(dynamoViewModel viewModel)
        {
            ViewModel = viewModel;
        }


        public override void Execute(object parameter)
        {

            try
            {
                ViewModel.bimtecUsers.Add("akamal@bimtec-eng.com", "123");

                

                if (ViewModel.bimtecUsers.Keys.Contains(ViewModel.UserEmailAdress) && ViewModel.bimtecUsers.Values.Contains(ViewModel.UserEmailPassword))
                {
                    string x = "Successful Login";
                    ViewModel.LoginStatus = x;
                    ViewModel.emailOrPassActive = false;
                }
                else
                {
                    string x = "Login Failed";
                    ViewModel.LoginStatus = x;
                    ViewModel.UserEmailAdress = null; ViewModel.UserEmailPassword = null;
                }

                
                

            }
            catch (Exception)
            {

                throw;
            }

        


        }
    }
}
