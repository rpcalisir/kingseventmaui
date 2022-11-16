using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using KingsEventMAUI.Views.Dashboard;
using KingsEventMAUI.Views.Startup;
using Microsoft.Extensions.DependencyInjection;
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
        private string _confirmPassword;
        [ObservableProperty]
        private DateTime _dateOfBirth;
        [ObservableProperty]
        private string _location;
        [ObservableProperty]
        private string _emailAddress;
        [ObservableProperty]
        private bool _privacyPolicyCheck;
        private readonly IServiceProvider serviceProvider;

        #endregion

        #region Properties
        #endregion

        #region Commands
        [RelayCommand]
        async void UserSignUp()
        {
            if (Password != ConfirmPassword)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", "Entered passwords are not same!", "OK");
                return;
            }

            try
            {
                var authProvider = serviceProvider.GetService<FirebaseAuthProvider>();
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(EmailAddress, Password);
                string token = auth.FirebaseToken;
                if (token != null)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Registration is successfully completed!", "OK");
                    await AppShell.Current.GoToAsync($"//{nameof(SignInPage)}");
                }
            }
            catch (FirebaseAuthException ex)
            {
                if (ex.Reason.Equals(AuthErrorReason.InvalidEmailAddress))
                    await App.Current.MainPage.DisplayAlert("ERROR", "Invalid Email!", "OK");
                else if (ex.Reason.Equals(AuthErrorReason.WeakPassword))
                    await App.Current.MainPage.DisplayAlert("ERROR", "Weak Password!", "OK");
                else if (ex.Reason.Equals(AuthErrorReason.EmailExists))
                    await App.Current.MainPage.DisplayAlert("ERROR", "Email is already registered!", "OK");
                else if (ex.Reason.Equals(AuthErrorReason.TooManyAttemptsTryLater))
                    await App.Current.MainPage.DisplayAlert("ERROR", "Too many attempts, try later!", "OK");
                else if (ex.Reason.Equals(AuthErrorReason.OperationNotAllowed))
                    await App.Current.MainPage.DisplayAlert("ERROR", "Operation is not allowed!", "OK");
                else if (ex.Reason.Equals(AuthErrorReason.SystemError))
                    await App.Current.MainPage.DisplayAlert("ERROR", "System Error!", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("ERROR", ex.Message, "OK");

                //await App.Current.MainPage.DisplayAlert("ERROR", "Could not connect to server!", "OK");
            }

        }
        #endregion

        #region Public Methods
        public SignUpPageViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        #endregion

        #region Private Implementation
        #endregion
    }
}
