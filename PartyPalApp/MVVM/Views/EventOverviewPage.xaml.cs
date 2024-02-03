using PartyPalApp.MVVM.Models;
using PartyPalApp.ViewModels;

namespace PartyPalApp;

public partial class EventOverviewPage : ContentPage
{
    private EventViewmodel viewmodel;
    private static HashSet<int> signedInEventIds = new HashSet<int>(); // Static set to track signed-in events
    public EventOverviewPage(Event selectedEvent)
	{
		InitializeComponent();
        viewmodel = new EventViewmodel();
        viewmodel.CurrentEvent = selectedEvent;
        BindingContext = viewmodel.CurrentEvent;
        SignInButton.IsEnabled = !signedInEventIds.Contains(selectedEvent.Id);
    }

    private void CloseButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private async void SignInButton_Clicked(object sender, EventArgs e)
    {
        if (!SignInButton.IsEnabled)
            return;

        // Disable the button to prevent multiple clicks
        SignInButton.IsEnabled = false;

        signedInEventIds.Add(viewmodel.CurrentEvent.Id);

        // Perform sign-in logic
        viewmodel.IncrementAttendanceCount.Execute(null);
        viewmodel.Refresh();

        BindingContext = viewmodel.CurrentEvent;

        // Set the flag to indicate that the user is signed in
        SignInButton.Text = "Ingeschreven";
    }
}