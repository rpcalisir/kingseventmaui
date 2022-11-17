namespace KingsEventMAUI.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();

        if (App.SignedInUserInfo != null)
        {
            lblUserPassword.Text = App.SignedInUserInfo.SignedInUserName;
            lblUserEmail.Text = App.SignedInUserInfo.SignedInUserEmail;
        }
    }
}