namespace KingsEventMAUI.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();

        if (App.SignedInUserInfo != null)
        {
            lblUserEmail.Text = App.SignedInUserInfo.SignedInUserEmail;
            lblUserPassword.Text = App.SignedInUserInfo.SignedInUserPassword;
        }
    }
}