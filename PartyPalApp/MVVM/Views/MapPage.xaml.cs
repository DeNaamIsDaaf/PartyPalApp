namespace PartyPalApp;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        LayoutImage.Source = "layout.png";
    }

    private void CalculateRoute_Clicked(object sender, EventArgs e)
    {
        LayoutImage.Source = "map_emergency.png";
    }
}