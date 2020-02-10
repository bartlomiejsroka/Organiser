using GalaSoft.MvvmLight.Command;
using OrganiserApp.Services;
using System.Windows;
 

namespace OrganiserApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private MainViewModel mainViewModel = new MainViewModel();
        private WindowService windowService;

        #region Ctors

        public LoginViewModel()
        {
            LoginButtonCommand = new RelayCommand<Window>(CloseWindow);
            windowService = new WindowService();
            LoginData= SettingsService.Deserialize();
            if (LoginData != string.Empty)
            {
                SaveLogin = true;
            }
        }

        #endregion

        #region Properties

        private string loginData;
        public string LoginData
        {
            get
            {
                return loginData;
            }
            set
            {
                loginData = value;
                RaisePropertyChanged("LoginData");
            }
        }

        private bool saveLogin;
        public bool SaveLogin
        {
            get
            {
                return saveLogin;
            }
            set
            {
                saveLogin = value;
                if(value == false)
                {
                    SettingsService.DeleteSerialized();
                }
                RaisePropertyChanged("SaveLogin");
            }
        }

        #endregion

        #region commands
       
        public RelayCommand<Window> LoginButtonCommand { get; private set; }
        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                if (SaveLogin)
                {
                    SettingsService.Serialize(LoginData);
                }
                windowService.ShowMainWindow(mainViewModel);
                window.Close();
            }
        }
        #endregion

    }
}
