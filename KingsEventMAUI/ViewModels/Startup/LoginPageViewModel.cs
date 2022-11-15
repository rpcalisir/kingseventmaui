using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using KingsEventMAUI.Views.Dashboard;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsEventMAUI.ViewModels.Startup
{
    public partial class LoginPageViewModel : BaseViewModel
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
        async void UserLogin()
        {
            await AppShell.Current.GoToAsync($"//{nameof(DashboardPage)}");

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
        #endregion

        #region Public Methods
        public LoginPageViewModel()
        {
        }
        #endregion

        #region Private Implementation
        #endregion
    }
}
