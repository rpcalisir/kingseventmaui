using KingsEventMAUI.Commands;
using KingsEventMAUI.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KingsEventMAUI.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _webApiKey = "AIzaSyDQjQb9X7a-fIQG58ZTmFlYvOycw92p-0k";

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string _userPassword;

        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }

        public ICommand LoginCommand { get; }

        private readonly INavigation _navigation;

        public LoginViewModel(INavigation navigation)
        {
            LoginCommand = new Command(RegisterBtnTappedAsync);
            _navigation = navigation;
        }

        private void RegisterBtnTappedAsync(object obj)
        {
            _navigation.PushAsync(new RegisterPage());
        }
    }
}
