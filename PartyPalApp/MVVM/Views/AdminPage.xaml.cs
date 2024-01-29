using PartyPalApp.ViewModels;

namespace PartyPalApp.MVVM.Views;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
		InitializeComponent();
        BindingContext = new EventViewmodel();
        EventDatePicker.MinimumDate = DateTime.Now;
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
        EventDescriptionEntry = null;
        EventTitleEntry = null;

    }
}