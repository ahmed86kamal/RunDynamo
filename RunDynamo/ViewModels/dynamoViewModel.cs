using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Visual;
using Autodesk.Revit.UI;
using Dynamo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace RunDynamo.ViewsModels
{
    public class dynamoViewModel : ViewModelBase
    {



        public ICommand login { set; get; }
        public ICommand run { set; get; }


        #region UI Elements

        public Dictionary<string, string> bimtecUsers { get; set; } = new Dictionary<string, string>();


        public ObservableCollection<string> ListOfScripts { get; set; } = new ObservableCollection<string>();

        public bool _emailOrPassActive;

        public bool emailOrPassActive
        {
            get { return _emailOrPassActive; }
            set
            {
                _emailOrPassActive = value;
                OnPropertyChanged(nameof(emailOrPassActive));
            }
        }

        private string _UserEmailAdress;
        public string UserEmailAdress
        {
            get { return _UserEmailAdress; }
            set
            {
                _UserEmailAdress = value;
                OnPropertyChanged(nameof(UserEmailAdress));
            }
        }
        private string _UserEmailPassword;
        public string UserEmailPassword
        {
            get { return _UserEmailPassword; }
            set
            {
                _UserEmailPassword = value;
                OnPropertyChanged(nameof(UserEmailPassword));
            }
        }

        private string _LoginStatus;
        public string LoginStatus
        {
            get { return _LoginStatus; }
            set
            {
                _LoginStatus = value;
                OnPropertyChanged(nameof(LoginStatus));
            }
        }
        

        #endregion

        public UIApplication _UIApplication { get; }

        public Application Application { get; }

        public ExternalCommandData CommandData { get; }
    

        public dynamoViewModel(Autodesk.Revit.UI.UIApplication uiapp)
        {

            login = new login(this);
            run = new run(this);
            _UIApplication = uiapp;


            DirectoryInfo d = new DirectoryInfo(@"C:\Users\Badmin\source\repos\RunDynamo\RunDynamo\Resources"); //Assuming Test is your Folder

            FileInfo[] Files = d.GetFiles("*.dyn"); //Getting dyn files
            string str = "";

            foreach (FileInfo file in Files)
            {
                str =  file.Name;
                ListOfScripts.Add(str);
            }




        }




        #region View Management
        public Window MainView { get; set; }

        public void ShowDialog()
        {
            if (MainView == null)
            {
                MainView = new MainWindow(this);
            }
            MainView.ShowDialog();
        }
        public void HideDialog()
        {
            MainView?.Hide();
        }
        public void CloseDialog()
        {
            MainView?.Close();
            MainView = null;
        }




        #endregion
    }
}
