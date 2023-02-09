using RunDynamo.ViewsModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RunDynamo
{
    public abstract class CommandBase : ICommand
    {
        #region Command Elements
        public event EventHandler CanExecuteChanged;
        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public virtual bool CanExecute(object parameter)
        { return true; }

        public abstract void Execute(object parameter);


        #endregion Command Elements 

        /// <summary>
        /// Convert List of objects to obsdervable collection
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="ListToBeConverted">
        /// List of type <see cref="T"> where t is type of list </see>/&gt;
        /// </param>
        /// <returns> </returns>
        public static ObservableCollection<T> ConvertListToObservableCollection<T>(List<T> ListToBeConverted)
        {
            ObservableCollection<T> values = new ObservableCollection<T>();
            if (null != ListToBeConverted)
            {
                foreach (var item in ListToBeConverted)
                {
                    values.Add(item);
                }
            }
            return values;
        }
    }
}
