using PartyPalApp.MVVM.Models;
using PartyPalApp.MVVM.Views;
using PartyPalApp.Repositories;

namespace PartyPalApp
{
    public partial class App : Application
    {
        public static BaseRepository<Event>? EventRepo { get; private set; }
        public static BaseRepository<Activity>? ActivityRepo { get; private set; }
        public App(BaseRepository<Event>? eventRepo, BaseRepository<Activity>? activiyRepo)
        {
            InitializeComponent();
            EventRepo = eventRepo;
            ActivityRepo = activiyRepo;
            MainPage = new NavigationPage(new OnBoardingPage());
        }
    }
}
