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

    private async void OnFaqClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sorry!", "Deze functie wordt bij de volgende update uitgwerkt.", "OK");
    }

    private async void OnReviewClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sorry!", "Deze functie wordt bij de volgende update uitgwerkt.", "OK");
    }

    private async void OnAccountInformationClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sorry!", "Deze functie wordt bij de volgende update uitgwerkt.", "OK");
    }
}