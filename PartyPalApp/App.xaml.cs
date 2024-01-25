using PartyPalApp.MVVM.Models;
using PartyPalApp.MVVM.Views;
using PartyPalApp.Repositories;

namespace PartyPalApp
{
    public partial class App : Application
    {
        public static BaseRepository<Event>? EventRepo { get; private set; }
        public App(BaseRepository<Event>? eventRepo)
        {
            InitializeComponent();
            EventRepo = eventRepo;
            MainPage = new NavigationPage(new TabbedPages());
        }
    }
}
