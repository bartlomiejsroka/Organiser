using System.ComponentModel;

namespace OrganiserApp.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {

        /// <summary>
        /// Base PropertyChanged implementation
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
