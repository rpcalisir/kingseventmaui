using KingsEventMAUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsEventMAUI.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;

        public LoginCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;

            _loginViewModel.PropertyChanged += _loginViewModel_PropertyChanged;
        }

        private void _loginViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_loginViewModel.UserName) || e.PropertyName == nameof(_loginViewModel.UserPassword))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_loginViewModel.UserName) && !string.IsNullOrEmpty(_loginViewModel.UserPassword) && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            try
            {
                Shell.Current.DisplayAlert("Information", $"Login button is pressed!", "OK");
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error", $"{ex.Message}", "OK");
            }

        }
    }
}
