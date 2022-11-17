using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using KingsEventMAUI.Views.Dashboard;
using KingsEventMAUI.Views.Startup;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsEventMAUI.ViewModels.Startup
{
    public partial class SignUpPageViewModel : BaseViewModel
    {
        #region Private Fields
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        [MinLength(2)]
        private string _name;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        [MinLength(2)]
        private string _surName;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        private string _password;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        private string _confirmPassword;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        private DatePicker _dateOfBirth;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        private string _location;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        private string _emailAddress;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        private bool _privacyPolicyCheck;

        private readonly IServiceProvider serviceProvider;

        #endregion
        
        #region Properties
        #endregion

        #region Commands
        [RelayCommand]
        async void UserSignUp()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                await App.Current.MainPage.DisplayAlert("ERROR", $"Name is empty!", "OK");
                return;
            }
            else if (string.IsNullOrWhiteSpace(SurName))
            {
                await App.Current.MainPage.DisplayAlert("ERROR", $"Surname is empty!", "OK");
                return;
            }
            else if (string.IsNullOrWhiteSpace(Password))
            {
                await App.Current.MainPage.DisplayAlert("ERROR", $"Password is empty!", "OK");
                return;
            }
            else if (string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                await App.Current.MainPage.DisplayAlert("ERROR", $"Confirm Password is empty!", "OK");
                return;
            }
            //if (DateOfBirth == 0001 && DateOfBirth.Month == 01 && DateOfBirth.Day == 01)
            //{
            //    await App.Current.MainPage.DisplayAlert("ERROR", $"Date of birth is not changed!", "OK");
            //    return;
            //}
            else if (string.IsNullOrWhiteSpace(Location))
            {
                await App.Current.MainPage.DisplayAlert("ERROR", $"Location is empty!", "OK");
                return;
            }
            else if (string.IsNullOrWhiteSpace(EmailAddress))
            {
                await App.Current.MainPage.DisplayAlert("ERROR", $"EmailAddress is empty!", "OK");
                return;
            }
            else if (Password != ConfirmPassword)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", "Entered passwords are not same!", "OK");
            }
            else if (!PrivacyPolicyCheck)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Please read and accept the privacy policy!", "OK");
            }
            else
            {
                try
                {
                    var authProvider = serviceProvider.GetService<FirebaseAuthProvider>();
                    var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(EmailAddress, Password, $"{Name} {SurName}");
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
                    else if (ex.Reason.Equals(AuthErrorReason.MissingPassword))
                        await App.Current.MainPage.DisplayAlert("ERROR", "Password is empty!", "OK");
                    else if (ex.Reason.Equals(AuthErrorReason.MissingEmail))
                        await App.Current.MainPage.DisplayAlert("ERROR", "Email is empty!", "OK");
                    else if (ex.Reason.Equals(AuthErrorReason.OperationNotAllowed))
                        await App.Current.MainPage.DisplayAlert("ERROR", "Operation is not allowed!", "OK");
                    else if (ex.Reason.Equals(AuthErrorReason.SystemError))
                        await App.Current.MainPage.DisplayAlert("ERROR", "System Error!", "OK");
                    else
                        await App.Current.MainPage.DisplayAlert("ERROR", ex.Message, "OK");

                    //await App.Current.MainPage.DisplayAlert("ERROR", "Could not connect to server!", "OK");
                }
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
        private async Task<bool> IsUserInformationFieldEmpty(string userFieldName)
        {
            if (string.IsNullOrWhiteSpace(userFieldName))
            {
                await App.Current.MainPage.DisplayAlert("ERROR", $"{userFieldName} is empty!", "OK");
                return true;
            }
            return false;
        }
        #endregion
    }
}
