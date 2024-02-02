using PartyPalApp.MVVM.Models;
using PartyPalApp.MVVM.ViewModels;
using PartyPalApp.ViewModels;

namespace PartyPalApp.MVVM.Views;

public partial class AdminPage : ContentPage
{
    private EventViewmodel eventViewmodel;
    private ActivityViewModel activityViewModel;
    public AdminPage()
	{
		InitializeComponent();
        eventViewmodel = new EventViewmodel();
        BindingContext = eventViewmodel;

        activityViewModel = new ActivityViewModel();

        EventPicker.BindingContext = eventViewmodel;
        ActivityPicker.BindingContext = activityViewModel;
        UpdateActivityPicker.BindingContext = activityViewModel;

        EventDatePicker.MinimumDate = DateTime.Now;
        UpdateEventDatePicker.MinimumDate = DateTime.Now;
    }

    private async void SelectEventImageButton_Clicked(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Kies een Afbeelding",
            FileTypes = FilePickerFileType.Images
        });
        if (result == null)
            return;
        var stream = await result.OpenReadAsync();
        SelectedEventImage.Source = ImageSource.FromStream(() => stream);
        if (BindingContext is EventViewmodel viewModel)
        {
            viewModel.CurrentEvent.Image = result.FullPath;
        }
    }
    private void OnSaveEventButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Opgeslagen!", "Het nieuwe evenement is aangemaakt.", "OK");
        SelectedEventImage.Source = null;
        EventDescriptionEntry.Text = null;
        EventTitleEntry.Text = null;

        eventViewmodel.Refresh();
    }
    private void OnSaveActivityButton_Clicked(object sender, EventArgs e)
    {
        Activity temporaryActivity = new Activity
        {
            Name = ActivityNameEntry.Text,
            StartTime = ActivityStartTimePicker.Time,
            EndTime = ActivityEndTimePicker.Time,
            ParentEvent = EventPicker.SelectedItem as Event,
            EventId = (EventPicker.SelectedItem as Event)?.Id
        };

        // Save the temporary activity to the database
        App.ActivityRepo.SaveEntity(temporaryActivity);

        // Associate the activity with the corresponding event
        if (EventPicker.SelectedItem is Event selectedEvent)
        {
            if (selectedEvent.Activities == null)
            {
                selectedEvent.Activities = new List<Activity>();
            }

            selectedEvent.Activities.Add(temporaryActivity);
            eventViewmodel.AddOrUpdateCommand?.Execute(selectedEvent); // Save the event to update the association
        }

        // Output details to the console
        Console.WriteLine($"Saved Activity: {temporaryActivity.Name}");
        Console.WriteLine($"Start Time: {temporaryActivity.StartTime}");
        Console.WriteLine($"End Time: {temporaryActivity.EndTime}");
        Console.WriteLine($"Associated Event: {temporaryActivity.ParentEvent?.Title} (ID: {temporaryActivity.ParentEvent?.Id})");

        DisplayAlert("Opgeslagen!", "De activiteit is succesvol aangemaakt!", "OK");

        // Clear the form or perform any additional actions after saving
        ActivityNameEntry.Text = string.Empty;
        ActivityStartTimePicker.Time = new TimeSpan(0, 0, 0);
        ActivityEndTimePicker.Time = new TimeSpan(0, 0, 0);
        EventPicker.SelectedItem = null;

        // Refresh the activities in your ViewModel if needed
        activityViewModel.Refresh();
    }

    private async void RemoveActivityButton_Clicked(object sender, EventArgs e)
    {
        var selectedActivity = ActivityPicker.SelectedItem as Activity;
        activityViewModel.DeleteCommand?.Execute(selectedActivity);
        await DisplayAlert("Verwijderd!", "De activiteit is succesvol verwijderd!", "OK");
    }

    private async void RemoveEventButton_Clicked(object sender, EventArgs e)
    {
        bool userResponse = await DisplayAlert("Weet je het zeker?", "Bij het verwijderen van dit evenement worden ook alle activiteiten verwijderd", "Verder", "Annuleer");

        if (userResponse)
        {
            var selectedEvent = RemoveEventPicker.SelectedItem as Event;

            // Ensure selectedEvent is not null before accessing its properties
            if (selectedEvent != null)
            {
                // Use the DeleteWithChildrenCommand to remove the event and its activities with recursion
                eventViewmodel.DeleteWithChildrenCommand?.Execute(selectedEvent);

                await DisplayAlert("Verwijderd!", "Het evenement en alle activiteiten zijn succesvol verwijderd!", "OK");
                eventViewmodel.Refresh();
            }
            else
            {
                // Handle the case where selectedEvent is null
                await DisplayAlert("Fout", "Geen evenement geselecteerd om te verwijderen.", "OK");
            }
        }
        else
        {
            // User clicked "Annuleer", display a message or perform other actions
            await DisplayAlert("Annulering", "Het verwijderen is geannuleerd.", "OK");
        }
    }

    private void UpdateEventPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (sender is Picker picker && picker.SelectedItem is Event selectedEvent)
        {
            // Update the Entry fields with the selected event's title and description
            UpdateEventTitleEntry.Text = selectedEvent.Title;
            UpdateEventDescriptionEntry.Text = selectedEvent.Description;
            UpdatedSelectedEventImage.Source = selectedEvent.Image;
            UpdateEventDatePicker.Date = selectedEvent.Date;
        }
    }

    private async void UpdateSelectEventImageButton_Clicked(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Kies een Afbeelding",
            FileTypes = FilePickerFileType.Images
        });
        if (result == null)
            return;
        var stream = await result.OpenReadAsync();
        UpdatedSelectedEventImage.Source = ImageSource.FromStream(() => stream);
        if (BindingContext is EventViewmodel viewModel)
        {
            viewModel.CurrentEvent.Image = result.FullPath;
        }
    }

    private void UpdateEvent_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Bijgwerkt!", "Het evenement is bijgewerkt.", "OK");
        UpdatedSelectedEventImage.Source = null;
        UpdateEventTitleEntry.Text = null;
        UpdateEventDescriptionEntry.Text = null;

        eventViewmodel.Refresh();
    }

    private void UpdateActivityPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (sender is Picker picker && picker.SelectedItem is Activity selectedActivity)
        {
            // Update the Entry and TimePicker fields with the selected activity's properties
            UpdateActivityNameEntry.Text = selectedActivity.Name;
            UpdateActivityStartTimePicker.Time = selectedActivity.StartTime;
            UpdateActivityEndTimePicker.Time = selectedActivity.EndTime;
        }
    }

    private void UpdateActivity_Clicked(object sender, EventArgs e)
    {

        DisplayAlert("Error!", "Deze functionaliteit moet nog uitgewerkt worden.", "OK");
    }
}