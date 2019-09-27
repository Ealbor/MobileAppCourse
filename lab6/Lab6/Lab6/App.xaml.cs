using Lab6.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab6
{
    public partial class App : Application
    {
        static PlayerDatabase database;


        public static PlayerDatabase Database
        {
            get
            {
                if(database == null){
                    database = new PlayerDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Players.db3"));
                }
                return database;
            }
        }

        public App()
        {

            InitializeComponent();

            MainPage = new NavigationPage(new PlayerRecords());
        }

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
