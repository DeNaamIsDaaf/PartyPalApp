namespace PartyPalApp.MVVM.Views;

public partial class TabbedPages : TabbedPage
{
	public TabbedPages()
	{
		InitializeComponent();

        // Set homepage as startpage
        CurrentPage = homePage;
    }
}