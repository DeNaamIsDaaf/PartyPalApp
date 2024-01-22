using System;
using System.Collections.ObjectModel;
using PartyPalApp.MVVM.Models;
using Microsoft.Maui.Controls;

namespace PartyPalApp
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Event> events;
        private ObservableCollection<Speaker> speakers;

        public ObservableCollection<Event> Events
        {
            get { return events; }
            set { events = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Speaker> Speakers
        {
            get { return speakers; }
            set { speakers = value; OnPropertyChanged(); }
        }

        public MainPage()
        {
            InitializeComponent();
            InitializeEvents();
            InitializeSpeakers();
            BindingContext = this;

            eventsCollectionView.ItemsSource = Events;
            speakersCollectionView.ItemsSource = Speakers;
        }

        private void InitializeEvents()
        {
            // Add sample events to the collection
            Events = new ObservableCollection<Event>
            {
                new Event("Event 1", "Description"),
                new Event("Event 2", "Description"),
                new Event("Event 3", "Description"),
                new Event("Event 4", "Description"),
                new Event("Event 5", "Description"),
                new Event("Event 6", "Description"),
                new Event("Event 7", "Description"),
                new Event("Event 8", "Description"),
            };
        }

        private void InitializeSpeakers()
        {
            // Add sample speakers to the collection
            Speakers = new ObservableCollection<Speaker>
            {
                new Speaker("Speaker 1", "Title 1", "dotnet_bot.png"),
                new Speaker("Speaker 2", "Title 2", "dotnet_bot.png"),
                new Speaker("Speaker 3", "Title 3", "dotnet_bot.png"),
                new Speaker("Speaker 4", "Title 4", "dotnet_bot.png"),
            };
        }
    }
}
