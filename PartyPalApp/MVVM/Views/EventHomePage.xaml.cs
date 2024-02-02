
using PartyPalApp.MVVM.ViewModels;
using PartyPalApp.ViewModels;
using System.Collections.ObjectModel;


namespace PartyPalApp;

public partial class EventHomePage : ContentPage
{
    private ActivityViewModel? _activityViewModel;
    private EventViewmodel? _eventViewModel;
    public EventHomePage()
	{
        // Instantiate EventViewModel and ActivityViewModel before calling InitializeComponent()
        _eventViewModel = new EventViewmodel();
        _activityViewModel = new ActivityViewModel();
        InitializeComponent();
        // Set EventViewModel as the binding context for the entire page
        BindingContext = _eventViewModel;

        // Set ActivityViewModel as the binding context specifically for the ListView
        ActivityListView.BindingContext = _activityViewModel;
    }

    protected override void OnAppearing()
    {
        _eventViewModel.Refresh();
        _activityViewModel.Refresh();

        // Set the correct property for CarouselView.ItemsSource
        EventCarousel.ItemsSource = _eventViewModel.Events;

        // Set the correct property for ListView.ItemsSource
        ActivityListView.ItemsSource = _activityViewModel.Activities;

    }
}