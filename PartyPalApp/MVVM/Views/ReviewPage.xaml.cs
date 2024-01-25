using PartyPalApp.MVVM.ViewModels;

namespace PartyPalApp;

public partial class ReviewPage : ContentPage
{
    private ReviewViewModel viewModel;

    public ReviewPage()
    {
        InitializeComponent();
        viewModel = new ReviewViewModel();
        BindingContext = viewModel;
    }
}