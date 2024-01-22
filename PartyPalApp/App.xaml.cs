using PartyPalApp.MVVM.Views;

namespace PartyPalApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new TabbedPages();
        }
    }
}
