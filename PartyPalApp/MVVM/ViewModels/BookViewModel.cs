using PartyPalApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace PartyPalApp.MVVM.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            LoadDefaultBooks();
        }

        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();

        private void LoadDefaultBooks()
        {
            Books?.Clear();
            Books.Add(new Book()
            {
                Id = 1,
                Image = "partypall.png",
                Title = "Welkom bij PartyPal",
                Description = "Ontdek een wereld vol evenementen en boeiende activiteiten met PartyPal. Of je nu op zoek bent naar opwindende workshops, bruisende feesten of andere unieke gebeurtenissen.."
            });

            Books.Add(new Book()
            {
                Id = 2,
                Image = "foodimage.png",
                Title = "Foodie Alert!",
                Description = "Onze cateraar heeft iets lekkers voor jou! Dit keer in de aanbieding... pumpumpumpaaaa: Snacks zoals jij ze kent. Pizza, Hamburgers, Hotdogs en dat allemaal onder het genot van een lekker drankje"
            });

            Books.Add(new Book()
            {
                Id = 3,
                Image = "notificationonboard.png",
                Title = "Herinner ons",
                Description = "Mis nooit boeiend nieuws met de klik van een knop! Sta PartyPal toe je meldingen te sturen."
            });
        }

    }
}
