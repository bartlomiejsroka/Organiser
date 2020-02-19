using OrganiserApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganiserApp.Services
{
    interface IWindowService
    {
        public void ShowWindow(ViewModelBase viewModel);
    }
}
