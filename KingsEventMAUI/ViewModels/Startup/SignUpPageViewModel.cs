using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using KingsEventMAUI.Views.Dashboard;
using KingsEventMAUI.Views.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsEventMAUI.ViewModels.Startup
{
    public partial class SignUpPageViewModel : BaseViewModel
    {
        #region Private Fields
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _surName;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private DateTime _dateOfBirth;
        [ObservableProperty]
        private string _location;
        [ObservableProperty]
        private string _emailAddress;
        [ObservableProperty]
        private bool _privacyPolicyCheck;

        private const string _webApiKey = "AIzaSyDQjQb9X7a-fIQG58ZTmFlYvOycw92p-0k";
        #endregion

        #region Properties
        #endregion

        #region Commands
        [RelayCommand]
        async void UserSignUp()
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(_webApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(EmailAddress, Password);
                string token = auth.FirebaseToken;
                if (token != null)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Registration is successfully completed!", "OK");
                    await AppShell.Current.GoToAsync($"//{nameof(DashboardPage)}");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", ex.Message, "OK");
            }

        }
        #endregion

        #region Public Methods
        #endregion

        #region Private Implementation
        #endregion
    }
}
