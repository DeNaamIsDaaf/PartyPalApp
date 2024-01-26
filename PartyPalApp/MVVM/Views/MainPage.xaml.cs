using System;
using System.Collections.ObjectModel;
using PartyPalApp.MVVM.Models;
using Microsoft.Maui.Controls;
using PartyPalApp.ViewModels;

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
                new Speaker("Speaker 1", "Title 1", "cookiemonster.png"),
                new Speaker("Speaker 2", "Title 2", "elmo.png"),
                new Speaker("Speaker 3", "Title 3", "beetle.png"),
                new Speaker("Miel", "Title 4", "boef.png"),
            };
        }
    }
}
