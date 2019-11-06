using JokeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using JokeApp.Views;

namespace JokeApp
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //This resets the "resume" id since we just want to restart from here

            ((App)App.Current).ResumeAtJokeId = -1;
            listView.ItemsSource = await App.Database.GetJokesAsync();
        }

        async void OnJokeAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JokePage
            {
                BindingContext = new Joke()
            }); 
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                await Navigation.PushAsync(new JokePage
                {
                    BindingContext = e.SelectedItem as Joke
                });
        }

    }
}
