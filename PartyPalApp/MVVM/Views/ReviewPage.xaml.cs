namespace PartyPalApp;

public partial class ReviewPage : ContentPage
{
	public ReviewPage()
	{
		InitializeComponent();
	}
    private void OnArrow1Tapped(object sender, EventArgs e)
    {
        DisplayAlert("Arrow Tapped", "Arrow 1 werkt", "OK");
    }
	private void OnArrow2Tapped(object sender, EventArgs e)
	{
		DisplayAlert("Arrow Tapped", "Arrow 2 werkt", "OK");
	}
}