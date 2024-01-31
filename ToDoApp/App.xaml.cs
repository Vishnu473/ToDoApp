using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoApp.Views;

namespace ToDoApp
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ToDoPageView());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

