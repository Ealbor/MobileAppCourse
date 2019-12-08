using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;

namespace FinalProject.Services
{

    //So this MockDataStore is using the interface IDataStore which defines methods.
        //So we know that this class has to use the methods at the very least. 
    public class MockDataStore : IDataStore<Recipe>
    {

        //Not sure why this is as readonly. 
        readonly List<Recipe> recipes;

        public MockDataStore()
        {

            //when we instantiate a datastore, we're creating items! 
                //In this instance, is this datastore an api? 
                    //Would this data below otherwise be the results returned from deserialzing the data that we get from making an API call? 
                        //I think it is, but the difference here is that we know what kind of data to expect. 
                            //Well we do too at this point because of the models that we've defined.  

            //The GUID is a globally unique ID. 
            //This would otherwise be a list of completely new recipes in the context that we need. 

            recipes = new List<Recipe>()
            {
                new Recipe { Id = Guid.NewGuid().ToString(),
                  vegetarian = false,
                    sourceUrl = "",
                    pricePerServing = 20,
                    title = "Veggie Burger",
                    readyInMinutes=20,
                    servings=2,
                    image="",
                    instructions="The trick to a good veggie burger is to not eat one in the first place." +
                    "Real beef is the real answer because it's the only answer.The trick to a good veggie burger is to not eat one in the first place." +
                    "Real beef is the real answer because it's the only answer.The trick to a good veggie burger is to not eat one in the first place." +
                    "Real beef is the real answer because it's the only answer.The trick to a good veggie burger is to not eat one in the first place." +
                    "Real beef is the real answer because it's the only answer.The trick to a good veggie burger is to not eat one in the first place." +
                    "Real beef is the real answer because it's the only answer. ",
                    preparationMinutes=20,
                    cookingMinutes=60 },

                new Recipe { Id = Guid.NewGuid().ToString(),
                    vegetarian = false,
                    sourceUrl = "",
                    pricePerServing = 55,
                    title = "Tacos",
                    readyInMinutes=60,
                    servings=6,
                    image="",
                    instructions="Make Tacos",
                    preparationMinutes=50,
                    cookingMinutes=20 },

                new Recipe { Id = Guid.NewGuid().ToString(),
                    vegetarian = false,
                    sourceUrl = "",
                    pricePerServing = 34,
                    title = "Fish Sandwich",
                    readyInMinutes=60,
                    servings=4,
                    image="",
                    instructions="Make fish",
                    preparationMinutes=60,
                    cookingMinutes=30 }

            };
        }

        public async Task<bool> AddItemAsync(Recipe recipe)
        {
            recipes.Add(recipe);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Recipe recipe)
        {
            var oldRecipe = recipes.Where((Recipe arg) => arg.Id == recipe.Id).FirstOrDefault();
            recipes.Remove(oldRecipe);
            recipes.Add(recipe);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldRecipe = recipes.Where((Recipe arg) => arg.Id == id).FirstOrDefault();
            recipes.Remove(oldRecipe);

            return await Task.FromResult(true);
        }

        public async Task<Recipe> GetItemAsync(string id)
        {
            return await Task.FromResult(recipes.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Recipe>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(recipes);
        }
    }
}