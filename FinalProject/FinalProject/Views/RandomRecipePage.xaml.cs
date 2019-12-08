using FinalProject.Models;
using FinalProject.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RandomRecipePage : ContentPage
    {


        SensorSpeed speed = SensorSpeed.Game;

        ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        public ObservableCollection<Recipe> Recipes { get { return recipes; } }

        public Command LoadRandomCommand { get; set; }


        public RandomRecipePage()
        {
            InitializeComponent();

            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            Accelerometer.Start(SensorSpeed.Game);

            GetRandomRecipes();

        }


        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Recipes.Clear();
                GetRandomRecipes();

            });
        }



        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }


        private async void GetRandomRecipes()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://api.spoonacular.com/recipes/random?number=6&apiKey=02a555ce0a0140d19230152bb2be26d6");

            var RO = JsonConvert.DeserializeObject<RootObject>(response);

            List<Recipe> r = RO.Recipes;

            foreach(var recipe in r)
            {
                recipes.Add(recipe);
            }
           
           

            RecipesListView.ItemsSource = recipes;
        }


        async void OnRecipeSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var recipe = args.SelectedItem as Recipe;
            if (recipe == null)
                return;

            await Navigation.PushAsync(new RecipeDetailPage(new RecipeDetailViewModel(recipe)));

            // Manually deselect item.
            RecipesListView.SelectedItem = null;
        }


    }
}