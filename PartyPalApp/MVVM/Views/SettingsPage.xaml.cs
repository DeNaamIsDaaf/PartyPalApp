using PartyPalApp.MVVM.Views;

namespace PartyPalApp;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private async void AdminButton_Clicked(object sender, EventArgs e)
    {
        string password = await DisplayPromptAsync("Wachtwoord", "Voer een wachtwoord in", "OK", "Annuleer", keyboard: Keyboard.Text);

        // Handle the entered password (you can perform your validation logic here)
        if (!string.IsNullOrEmpty(password))
        {
            // Do something with the password (e.g., validate or process)
            // For demonstration purposes, we'll display the password in another alert
            await DisplayAlert("Wachtwoord","Wachtwoord is correct!","Verder");
            await Navigation.PushAsync(new AdminPage());
        }
    }

    private async void PrivacyAndSecurityButton_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sorry!", "Deze functie wordt bij de volgende update uitgwerkt.", "OK");
    }

    private async void AppearanceButton_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sorry!", "Deze functie wordt bij de volgende update uitgwerkt.", "OK");
    }

    private async void ProblemButton_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sorry!", "Deze functie wordt bij de volgende update uitgwerkt.", "OK");
    }

    private async void FeedbackButton_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sorry!", "Deze functie wordt bij de volgende update uitgwerkt.", "OK");
    }
}