namespace PartyPalApp;

public partial class AccountPage : ContentPage
{
	public AccountPage()
	{
		InitializeComponent();
	}

    private async void OnVriendenClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FriendPage());
    }
}