using PartyPalApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPalApp.MVVM.ViewModels
{
    public class ReviewViewModel
    {
        public ObservableCollection<Review> Reviews { get; set; }

        public ReviewViewModel()
        {
            InitializeReviews();
        }

        private void InitializeReviews()
        {
            // Replace this with your logic to fetch reviews from a database or other source.
            Reviews = new ObservableCollection<Review>
            {
                new Review { Name = "Jan Janssen", Description = "Echt een leuk evenement!", Score = 8 },
                new Review { Name = "Peter Gilles", Description = "Heel educatief!", Score = 9 },
                new Review { Name = "Alice Johnson", Description = "Geweldige ervaring!", Score = 10 },
            };
        }
    }
}
