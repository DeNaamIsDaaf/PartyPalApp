using PartyPalApp.MVVM.Models;
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
                new Event ("Event1", "10.30 - 12.00", "eventbackground.jpg", DateTime.Now.AddDays(1) ),
                new Event ("Event2", "12.30 - 13.00", "eventbackground.jpg", DateTime.Now.AddDays(2)),
                new Event ("Event3", "13.00 - 14.00", "eventbackground.jpg", DateTime.Now.AddDays(3)),
                new Event ("Event4", "14.30 - 15.00", "eventbackground.jpg", DateTime.Now.AddDays(4))
            };

            Events = new ObservableCollection<Event>(Events.OrderBy(e => e.Date));
        }
    }

}
