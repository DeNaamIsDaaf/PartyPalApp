using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPalApp.MVVM.Models
{
    public class Event
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        // Add more properties as needed

        public Event(string title, string description, string image)
        {
            Title = title;
            Description = description;
            Image = image;
        }
    }
}
