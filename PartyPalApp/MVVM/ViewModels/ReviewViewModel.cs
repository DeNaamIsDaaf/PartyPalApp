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
                new Review ("Jan Janssen", "Echt een leuk evenement!", 8 ),
                new Review ("Peter Gilles", "Heel educatief!", 9),
                new Review ("Alice Johnson", "Geweldige ervaring!", 10),
                // Add more reviews as needed
            };
        }
    }
}
