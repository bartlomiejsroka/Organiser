using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OrganiserApp.Model
{
    public abstract class BaseModel : INotifyPropertyChanged
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
