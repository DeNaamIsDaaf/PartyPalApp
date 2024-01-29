
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

    protected override void OnAppearing()
    {
        viewModel.Refresh();
        EventCarousel.ItemsSource = viewModel.Events;
        EventListView.ItemsSource = viewModel.Events;

    }
}