using System;
using System.Collections.ObjectModel;
using PartyPalApp.MVVM.Models;
using Microsoft.Maui.Controls;
using PartyPalApp.ViewModels;
using PartyPalApp.Logic;

namespace PartyPalApp
{
    public partial class MainPage : ContentPage
    {

        private EventViewmodel? viewModel;

        //private ObservableCollection<Event> events;
        private ObservableCollection<Speaker> speakers;

        //public ObservableCollection<Event> Events
        //{
        //    get { return events; }
        //    set { events = value; OnPropertyChanged(); }
        //}

        public ObservableCollection<Speaker> Speakers
        {
            get { return speakers; }
            set { speakers = value; OnPropertyChanged(); }
        }


        public MainPage()
        {
            viewModel = new EventViewmodel();
            InitializeComponent();
            InitializeSpeakers();
            BindingContext = viewModel;

            speakersCollectionView.ItemsSource = Speakers;
        }

        private void InitializeSpeakers()
        {
            // Add sample speakers to the collection
            Speakers = new ObservableCollection<Speaker>
            {
                new Speaker("Koekie Monster", "Over koekjes", "cookiemonster.png"),
                new Speaker("Elmo", "Over liefde", "elmo.png"),
                new Speaker("Beetle", "Over de natuure", "beetle.png"),
                new Speaker("Boef", "Over Straattaal", "boef.png"),
            };
        }

        private async void JokeButtonGenerator_Clicked(object sender, EventArgs e)
        {
            List<Joke> dadJokes = await DadJokeLogic.GetRandomJoke();
            DeliveryJokeLabel.Text = null;
            JokeLabel.Text = null;

            if (dadJokes != null && dadJokes.Count > 0)
            {
                if (dadJokes[0].type == "twopart")
                {
                    JokeLabel.Text = $"{dadJokes[0].setup}";

                    // Delay for 2 seconds before showing the delivery part
                    await Task.Delay(1200);

                    DeliveryJokeLabel.Text += $"\n{dadJokes[0].delivery}";
                    JokeFrame.IsVisible = true;
                }
                else if (dadJokes[0].type == "single")
                {
                    JokeLabel.Text = $"{dadJokes[0].joke}";
                    JokeFrame.IsVisible = true;
                }

            else
                {
                    JokeLabel.Text = "Mop ophalen Mislukt.";
                }
            }
        }

        private async void ZieMeerLabel_Tapped(object sender, TappedEventArgs e)
        {
            await DisplayAlert("Geen extra functionaliteiten", "Er zijn geen andere functionaliteiten beschikbaar tijdens het wachten.", "OK");
        }
    }
}
