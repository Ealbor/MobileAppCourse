using FinalProject.Models;
using FinalProject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalProject.ViewModels
{
    class RecipesViewModel : BaseViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; set; }
        public Command LoadItemsCommand { get; set; }

        public RecipesViewModel()
        {
            Title = "Favorite Recipes";
            Recipes = new ObservableCollection<Recipe>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewRecipePage, Recipe>(this, "AddRecipe", async (obj, recipe) =>
            {
                var newRecipe = recipe as Recipe;
                Recipes.Add(newRecipe);
                await DataStore.AddItemAsync(newRecipe);
            });
        }



        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Recipes.Clear();
                var recipes = await DataStore.GetItemsAsync(true);
                foreach (var recipe in recipes)
                {
                    Recipes.Add(recipe);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}