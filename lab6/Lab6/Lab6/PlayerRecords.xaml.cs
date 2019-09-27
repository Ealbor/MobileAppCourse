using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerRecords : ContentPage
    {
        public PlayerRecords()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //This is going to populate the list in the back threads
            
                //Commented out for the time being until I can get the Player object to behave how I want.
            listView.ItemsSource = await App.Database.GetPlayerAsync();
        }

   
            //This method will create a new main page for a new player to play game
        async void OnNewPlayer(object sender, EventArgs e)
        {
            //This will create a new mainPage with with a new userName ready to be used
            await Navigation.PushAsync(new MainPage
            {
                BindingContext = new Player()
            });
        }


            //Would be nice to erase the user entry too
        //async void DeletePlayer(object sender, EventArgs e)
        //{
        //    var player = (Player)BindingContext;
        //    await App.Database.DeletePlayerAsync(player);
        //}
    }
}