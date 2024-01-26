using PartyPalApp.MVVM.ViewModels;

namespace PartyPalApp;

public partial class FriendPage : ContentPage
{
    private FriendViewModel? viewModel;

    public FriendPage()
	{
        viewModel = new FriendViewModel();
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void backButtonClicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}