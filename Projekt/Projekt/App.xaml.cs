using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt
{
    public partial class App : Application
    {
        public static string DB_PATH = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()); 
        }

        public App(string DB_path)
        {

            InitializeComponent();

            DB_PATH = DB_path;

            MainPage = new NavigationPage(new MainPage());

        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
