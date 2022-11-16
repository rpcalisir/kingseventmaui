using CommunityToolkit.Mvvm.Input;
using KingsEventMAUI.Views.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsEventMAUI.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        #region Private Fields
        #endregion

        #region Properties
        #endregion

        #region Commands
        [RelayCommand]
        async void UserSignout()
        {
            if (Preferences.ContainsKey(nameof(App.SignedInUserInfo)))
            {
                Preferences.Remove(nameof(App.SignedInUserInfo));
            }

            await AppShell.Current.GoToAsync($"//{nameof(SignInPage)}");
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Implementation
        #endregion
    }
}
