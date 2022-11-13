using Firebase.Auth;
using KingsEventMAUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KingsEventMAUI.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Private Fields
        private string _name;
        private string _surName;
        private string _password;
        private DateTime _dateOfBirth;
        private string _location;
        private string _emailAddress;
        private bool _privacyPolicyCheck;
        private INavigation _navigation;
        private string _webApiKey = "AIzaSyDQjQb9X7a-fIQG58ZTmFlYvOycw92p-0k";

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string SurName
        {
            get { return _surName; }
            set
            {
                _surName = value;
                OnPropertyChanged(nameof(SurName));
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }

        public string Location
        {
            get { return _location; }
            set 
            { 
                _location = value; 
                OnPropertyChanged(nameof(Location));
            }
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            set
            {
                _emailAddress = value;
                OnPropertyChanged(nameof(EmailAddress));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        //TBD Bind this property to Page Switch and add logic to Register button
        public bool PrivacyPolicyCheck
        {
            get { return _privacyPolicyCheck; }
            set
            {
                _privacyPolicyCheck = value;
                OnPropertyChanged(nameof(PrivacyPolicyCheck));
            }
        }

        #endregion

        public ICommand RegisterUserCommand { get; }

        public RegisterViewModel(INavigation navigation)
        {
            Title = "Register";
            _navigation = navigation;
            RegisterUserCommand = new Command(RegisterUserTappedAsync);
        }

        private async void RegisterUserTappedAsync(object obj)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(_webApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(EmailAddress, Password);
                string token = auth.FirebaseToken;
                if (token!=null)
                    await App.Current.MainPage.DisplayAlert("Alert", "Registration is successfully completed!", "OK");
                await this._navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", ex.Message, "OK");
            }
        }
    }
}
