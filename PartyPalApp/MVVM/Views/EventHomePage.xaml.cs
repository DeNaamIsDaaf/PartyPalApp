
using PartyPalApp.ViewModels;
using System.Collections.ObjectModel;


namespace PartyPalApp;

public partial class EventHomePage : ContentPage
{
	private EventViewmodel? viewModel;
    public EventHomePage()
	{
		viewModel = new EventViewmodel(); 
		InitializeComponent();
		BindingContext = viewModel;
	}
}