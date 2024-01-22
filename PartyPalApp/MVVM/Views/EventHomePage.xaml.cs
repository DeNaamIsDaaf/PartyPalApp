using PartyPalApp.ViewModels;
using System.Collections.ObjectModel;


namespace PartyPalApp;

public partial class EventHomePage : ContentPage
{
	private EventHomePageViewModel? viewModel;
    public EventHomePage()
	{
		viewModel = new EventHomePageViewModel(); 
		InitializeComponent();
		BindingContext = viewModel;
	}
}