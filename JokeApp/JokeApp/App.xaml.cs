using JokeApp.Data;
using JokeApp.Views;
using System;
using System.IO;
using Xamarin.Forms;

namespace JokeApp
{
    public partial class App : Application
    {

        static JokeDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            var nav = new NavigationPage(new MainPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;

        }

         public static JokeDatabase Database
        {
            get
            {

                if (database == null)
                {
                    database = new JokeDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "JokeAppSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtJokeId { get; set; }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
