using PartyPalApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPalApp.ViewModels
{
    public class EventHomePageViewModel
    {
        public ObservableCollection<Event> Events { get; set; }

        public EventHomePageViewModel()
        {
            InitializeEvents();
        }


        private void InitializeEvents()
        {
            //Hier Databasee van Events ophalen NU is het HARDCODED!!
            Events = new ObservableCollection<Event>()
            {
                new Event {Title = "Event1", Description = "10.30 - 12.00", Image = "eventbackground.jpg" },
                new Event {Title = "Event2", Description = "12.30 - 13.00", Image = "eventbackground.jpg" },
                new Event {Title = "Event3", Description = "13.00 - 14.00", Image = "eventbackground.jpg"},
                new Event {Title = "Event4", Description = "14.30 - 15.00", Image = "eventbackground.jpg"}
            };
        }
    }

}
