using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FinalProject.ViewModels;
using FinalProject.Models;

namespace FinalProject.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class RecipesPage : ContentPage
    {
        RecipesViewModel viewModel;

        public RecipesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RecipesViewModel();
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



        //Again, this is all just navigation really. This one here is creating a new Items Page.
        async void AddRecipe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewRecipePage()));
        }




        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Recipes.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}