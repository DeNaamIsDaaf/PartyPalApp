﻿namespace PartyPalApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new EventHomePage());
        }
    }
}