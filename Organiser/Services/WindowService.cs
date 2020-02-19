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
        /// Opens main view
        /// </summary>
        /// <param name="viewModel"></param>
        public void ShowMainWindow(object viewModel)
        {
            var win = new Main
            {
                DataContext = viewModel
            };
            win.Show();
        }

        public void ShowErrorWindow(object viewModel)
        {
            var win = new Error
            {
                DataContext = viewModel
            };
            win.Show();
        }


        /// <summary>
        /// Creats view basing on VM
        /// </summary>
        /// <param name="viewModel"></param>
        public void ShowWindow(ViewModelBase viewModel)
        {
            var views = new List<object>();
            var nspace = "OrganiserApp.Views";
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == nspace
                    select t;
            var col = q.Select(x => x.FullName).ToList();
            foreach (string s in col)
            {
                views.Add(Activator.CreateInstance(Assembly.GetExecutingAssembly().FullName, s).Unwrap());
            }
            foreach (Window o in views)
            {
                if (o.DataContext.GetType() == viewModel.GetType())
                {
                    o.DataContext = viewModel;
                    o.Show();
                }
                else
                {
                    o.Close();
                }
            }
            
            }
        #endregion
    }
}
