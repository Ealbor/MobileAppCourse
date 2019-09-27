using Lab6.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab6
{
// Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
     
        public MainPage()
        {
            InitializeComponent();
        }

        async void ToAct2(object sender, EventArgs e) { 
            if (PlayerName.Text != null) {

                var player = (Player)BindingContext;
                player.Name = PlayerName.Text;
                player.Score = 0;
                ////Going to have to use this method again once the game is over on the act2
                await App.Database.SavePlayerAsync(player);
                

                //This is the trick to solving the double 
                await Navigation.PushAsync(new Activity2(player));

                //Need to reset the string for after 
                PlayerName.Text = "";
            }
            else {
                validation.Text = "PLEASE ENTER PLAYER NAME TO CONTINUE";
            }
        }
    }
}




