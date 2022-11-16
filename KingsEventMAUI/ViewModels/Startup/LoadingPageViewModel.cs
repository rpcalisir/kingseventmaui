using CommunityToolkit.Mvvm.Input;
using KingsEventMAUI.Controls;
using KingsEventMAUI.Models;
using KingsEventMAUI.Views.Dashboard;
using KingsEventMAUI.Views.Startup;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsEventMAUI.ViewModels.Startup
{
    public partial class LoadingPageViewModel : BaseViewModel
    {
        #region Private Fields
        #endregion

        #region Properties
        #endregion

        #region Commands

        #endregion

        #region Public Methods
        public LoadingPageViewModel()
        {
            CheckUserSignInDetails();
        }


        #endregion

        #region Private Implementation
        private async void CheckUserSignInDetails()
        {
            string userDetailsStr = Preferences.Get(nameof(App.SignedInUserInfo), "");

            if (string.IsNullOrWhiteSpace(userDetailsStr))
            {
                //Navigate to Login Page
                await Shell.Current.GoToAsync($"//{nameof(SignInPage)}");
            }
            else
            {
                //User is opened the app first time, signed in (App.SignedInUserInfo is set in Login Page) and user information is shown in top of flyout menu,
                //then user closed the app and opened again, LoginViewModel code will not be executed this time so App.SignedInUserInfo will not be set, it will be null, since App.SignedInUserInfo is resetting each time app resets, then user info will not be displayed on the top of flyout menu

                //To prevent this, meaning displayin the user info in every case, following two lines are added.
                var userDetails = JsonConvert.DeserializeObject<SignedInUserInfo>(userDetailsStr);
                App.SignedInUserInfo = userDetails;

                AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

                //Navigate to Dashboard
                await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
            }
        }

        #endregion
    }
}
