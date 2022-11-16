using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
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
    public partial class SignInPageViewModel : BaseViewModel
    {
        #region Private Fields
        [ObservableProperty]
        private string _userEmail;
        [ObservableProperty]
        private string _userPassword;

        private const string _webApiKey = "AIzaSyDQjQb9X7a-fIQG58ZTmFlYvOycw92p-0k";
        #endregion

        #region Properties
        //public string UserEmail
        //{
        //    get { return _userEmail; }
        //    set
        //    {
        //        _userEmail = value;
        //        OnPropertyChanged(nameof(UserEmail));
        //    }
        //}

        //public string UserPassword
        //{
        //    get { return _userPassword; }
        //    set
        //    {
        //        _userPassword = value;
        //        OnPropertyChanged(nameof(UserPassword));
        //    }
        //}
        #endregion

        #region Commands
        [RelayCommand]
        async void UserSignIn()
        {
            if (!string.IsNullOrWhiteSpace(UserEmail) && !string.IsNullOrWhiteSpace(UserPassword))
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(_webApiKey));
                try
                {
                    var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserEmail, UserPassword);
                    var content = await auth.GetFreshAuthAsync();
                    var serializedContent = JsonConvert.SerializeObject(content);

                    if (Preferences.ContainsKey(nameof(App.FreshFireBaseToken)))
                    {
                        Preferences.Remove(nameof(App.FreshFireBaseToken));
                    }

                    Preferences.Set(nameof(App.FreshFireBaseToken), serializedContent);
                    App.FreshFireBaseToken = serializedContent;

                    var userDetails = new SignedInUserInfo()
                    {
                        SignedInUserEmail = UserEmail,
                        SignedInUserPassword = UserPassword,
                    };

                    var userDetailsStr = JsonConvert.SerializeObject(userDetails);
                    Preferences.Set(nameof(App.SignedInUserInfo), userDetailsStr);
                    App.SignedInUserInfo = userDetails;

                    AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

                    await AppShell.Current.GoToAsync($"//{nameof(DashboardPage)}");
                }
                catch (FirebaseAuthException ex)
                {
                    if (ex.Reason.Equals(Firebase.Auth.AuthErrorReason.InvalidEmailAddress))
                        await App.Current.MainPage.DisplayAlert("ERROR", "Invalid Email!", "OK");
                    else if(ex.Reason.Equals(Firebase.Auth.AuthErrorReason.WrongPassword))
                        await App.Current.MainPage.DisplayAlert("ERROR", "Wrong Password!", "OK");
                    else
                        await App.Current.MainPage.DisplayAlert("ERROR", "Could not connect to server!", "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("ERROR", "Username of password is empty!", "OK");
            }

            //FIREBASE
            //var authProvider = new FirebaseAuthProvider(new FirebaseConfig(_webApiKey));

            //try
            //{
            //    var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserEmail, UserPassword);
            //    var content = await auth.GetFreshAuthAsync();
            //    var serializedContent = JsonConvert.SerializeObject(content);
            //    Preferences.Set("FreshFireBaseToken", serializedContent);
            //    await _navigation.PushAsync(new LoginPage());
            //}
            //catch (Exception ex)
            //{
            //    await App.Current.MainPage.DisplayAlert("ERROR", ex.Message, "OK");
            //}
            //FIREBASE
        }

        [RelayCommand]
        async void GoToUserSignUpPage()
        {
            await AppShell.Current.GoToAsync(nameof(SignUpPage));
        }
        #endregion

        #region Public Methods
        public SignInPageViewModel()
        {
        }
        #endregion

        #region Private Implementation
        #endregion
    }
}
