using KingsEventMAUI.ViewModels;

namespace KingsEventMAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new RegisterLoginViewModel(Navigation);
        }
    }
}