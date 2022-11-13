using KingsEventMAUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KingsEventMAUI.ViewModels
{
    public class RegisterLoginViewModel : BaseViewModel
    {
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

        public ICommand OpenLoginPageCommand { get; }
        public ICommand OpenRegisterPageCommand { get; }

        private readonly INavigation _navigation;

        public RegisterLoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            OpenLoginPageCommand = new Command(LoginBtnTappedAsync);
            OpenRegisterPageCommand = new Command(RegisterBtnTappedAsync);
        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            await _navigation.PushAsync(new RegisterPage());
        }

        private async void LoginBtnTappedAsync(object obj)
        {
            await _navigation.PushAsync(new LoginPage());
        }
    }
}
