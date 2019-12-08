using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FinalProject.ViewModels
{
    public class RecipeDetailViewModel: BaseViewModel
    {
        public Recipe Recipe { get; set; }

        public Command URLCommand { get; set; }

        public RecipeDetailViewModel(Recipe recipe = null)
        {
            Title = recipe?.Text;
            Recipe = recipe;


        }







    }





}
