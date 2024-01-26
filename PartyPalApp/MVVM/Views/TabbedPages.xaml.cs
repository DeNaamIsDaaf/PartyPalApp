namespace PartyPalApp.MVVM.Views;

public partial class TabbedPages : TabbedPage
{
	public TabbedPages()
	{
		InitializeComponent();

        // Set homepage as startpage
        CurrentPage = homePage;
    }

    private async void QrScannerClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new QrPage());
    }

    private async void AccountClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccountPage());
    }
}