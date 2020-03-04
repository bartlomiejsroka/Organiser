using OrganiserApp.ViewModels;
using OrganiserApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Windows;

namespace OrganiserApp.Services
{
    class WindowService : IWindowService
    {
        #region public methods
        /// <summary>
        /// Opens error dialog window
        /// </summary>
        /// <param name="viewModel"></param>
        public void ShowErrorWindow(object viewModel)
        {
            var win = new Error
            {
                DataContext = viewModel
            };
            win.ShowDialog();
        }
     
        /// <summary>
        /// Creats view basing on VM
        /// </summary>
        /// <param name="viewModel"></param>
        public void ShowWindow(ViewModelBase viewModel)
        {
            var modelType = viewModel.GetType();
            var windowTypeName
                = modelType.Name.Replace("ViewModel", string.Empty);
            var windowTypes
                = from t in modelType.Assembly.GetTypes()
                  where t.IsClass
          && t.Name == windowTypeName
                  select t;
            Window win = Activator.CreateInstance(windowTypes.Single()) as Window;
            win.DataContext = viewModel;
            win.Show();
        }
        #endregion
    }
}
