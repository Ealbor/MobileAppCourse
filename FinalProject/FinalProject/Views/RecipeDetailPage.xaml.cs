using FinalProject.Models;
using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeDetailPage : ContentPage
    {
        

        RecipeDetailViewModel viewModel;

        public RecipeDetailPage(RecipeDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;



        }

        public RecipeDetailPage()
        {
            InitializeComponent();

            var recipe = new Recipe
            {
                Text = "Recipe ONE",
                Title = "This is the first recipe"
            };

            viewModel = new RecipeDetailViewModel(recipe);
            BindingContext = viewModel;
        }


    
        async void takeToSite(object sender, EventArgs args)
        {
            await Browser.OpenAsync((sender as Button).Text, BrowserLaunchMode.SystemPreferred);
        }





    }
}