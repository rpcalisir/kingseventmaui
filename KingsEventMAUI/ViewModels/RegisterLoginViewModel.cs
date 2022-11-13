using Firebase.Auth;
using KingsEventMAUI.Views;
using Newtonsoft.Json;
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
        #region Private Fields
        private string _userEmail;
        private string _userPassword;
        private readonly INavigation _navigation;
        private string _webApiKey = "AIzaSyDQjQb9X7a-fIQG58ZTmFlYvOycw92p-0k";

        #endregion

        #region Properties
        public string UserEmail
        {
            get { return _userEmail; }
            set
            {
                _userEmail = value;
                OnPropertyChanged(nameof(UserEmail));
            }
        }

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

        #endregion

        #region Public Methods
        public RegisterLoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            OpenLoginPageCommand = new Command(LoginBtnTappedAsync);
            OpenRegisterPageCommand = new Command(RegisterBtnTappedAsync);
        }

        #endregion

        #region Private Implementations

        private async void LoginBtnTappedAsync(object obj)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(_webApiKey));

            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserEmail, UserPassword);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("FreshFireBaseToken", serializedContent);
                await _navigation.PushAsync(new LoginPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", ex.Message, "OK");
            }

        }
        private async void RegisterBtnTappedAsync(object obj)
        {
            await _navigation.PushAsync(new RegisterPage());
        }
        #endregion

    }
}
