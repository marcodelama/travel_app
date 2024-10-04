﻿using System;
using travel_app.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup;

namespace travel_app
{
    public partial class App : Application
    {
        public static FlyoutPage MasterDet { get; set; }
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new HotelesPage());
            MainPage = new NavigationPage(new travel_app.Views.Inicio());

        }

        protected override void OnStart()
        {
            //Rg.Plugins.Popup.Popup.Init();}
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
