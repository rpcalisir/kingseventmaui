using KingsEventMAUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsEventMAUI.Commands
{
    internal class RegisterUserCommand : CommandBase
    {
        private readonly RegisterViewModel _registerViewModel;

        public RegisterUserCommand(RegisterViewModel registerViewModel)
        {
            _registerViewModel = registerViewModel;

            _registerViewModel.PropertyChanged += _registerViewModel_PropertyChanged;

        }

        private void _registerViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_registerViewModel.Name) || (e.PropertyName == nameof(_registerViewModel.Password)))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_registerViewModel.Name) && !string.IsNullOrEmpty(_registerViewModel.Password) && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            try
            {

            }
            catch (Exception)
            {
            }

        }
    }
}
