using PartyPalApp.MVVM.ViewModels;
using PartyPalApp.MVVM.Views;

namespace PartyPalApp;

public partial class OnBoardingPage : ContentPage
{
	public OnBoardingPage()
	{
		InitializeComponent();
        BindingContext = new BookViewModel();
        MyButton.Text = "Volgende";
	}

    private async void MyButton_Clicked(object sender, EventArgs e)
    {
        if (myCarousel.CurrentItem == myCarousel.ItemsSource.Cast<object>().Last())
        {
            var tabbedPage = new NavigationPage(new TabbedPages());
            // Use NavigationPage if needed
            await Navigation.PushModalAsync(tabbedPage);
        }
        else
        {
            myCarousel.CurrentItem = myCarousel.ItemsSource.Cast<object>()
                .SkipWhile(item => item != myCarousel.CurrentItem)
                .Skip(1)
                .First();
        }
    }

    private void myCarousel_PositionChanged(object sender, PositionChangedEventArgs e)
    {
        if(e.CurrentPosition == (int)myCarousel.ItemsSource.Cast<object>().Count() - 1)
        {
            MyButton.BackgroundColor = Color.FromRgb(24, 106, 185);
            MyButton.Text = "Naar de App";
        }
        else
        {
            MyButton.BackgroundColor = Color.FromRgb(255, 0, 0);
            MyButton.Text = "Volgende";
        }
    }
}