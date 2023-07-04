using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Wellnut.Data.Models;
using Wellnut.Data;
using Wellnut.Data.Enums;
using Wellnut.Data.Services.ApiService.ApiModels;
using Wellnut.Data.Services.ApiService.ApiModelResults;

public class MealDbService
{
    public async Task<IEnumerable<RecipeApiModel>> GetRecipiesByCategory(string searchTermCategory, string searchTermArea, string searchTermIngredient, string searchType)
    {
        List<RecipeApiModel> recipes = new List<RecipeApiModel>();

        string url = $"https://www.themealdb.com/api/json/v1/1/filter.php";
        string parameters = "";

        if (searchType != null)
        {
            if (searchType == "Category")
            {
                parameters = $"?c={searchTermCategory}";
            }
            else if (searchType == "Area")
            {
                parameters = $"?a={searchTermArea}";
            }
            else if (searchType == "Ingredient")
            {
                parameters = $"?i={searchTermIngredient}";
            }
        }

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.GetAsync(parameters).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var recipeList = JsonConvert.DeserializeObject<RecipeList>(jsonString);

            if (recipeList.Recipes != null)
            {
                recipes.AddRange(recipeList.Recipes);
            }
        }

        return recipes;
    }

    public async Task<IEnumerable<RecipeApiModel>> GetRecipeById(int id)
    {
        List<RecipeApiModel> recipes = new List<RecipeApiModel>();

        string url = $"https://www.themealdb.com/api/json/v1/1/lookup.php";
        string parameters = $"?i={id}";

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.GetAsync(parameters).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var recipeList = JsonConvert.DeserializeObject<RecipeList>(jsonString);

            if (recipeList != null)
            {
                recipes.AddRange(recipeList.Recipes);
            }
        }

        return recipes;
    }

    //public async Task<IEnumerable<RecipeByAreaApiModel>> GetRecipiesByArea(string searchTerm)
    //{
    //    List<RecipeByAreaApiModel> recipes = new List<RecipeByAreaApiModel>();

    //    var url = $"https://www.themealdb.com/api/json/v1/1/filter.php";
    //    var parameters = $"?a={searchTerm}";

    //    HttpClient client = new HttpClient();
    //    client.BaseAddress = new Uri(url);
    //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    //    HttpResponseMessage response = await client.GetAsync(parameters).ConfigureAwait(false);

    //    if (response.IsSuccessStatusCode)
    //    {
    //        var jsonString = await response.Content.ReadAsStringAsync();
    //        var recipeList = JsonConvert.DeserializeObject<RecipeByAreaList>(jsonString);

    //        if (recipeList != null)
    //        {
    //            recipes.AddRange(recipeList.Recipes);
    //        }
    //    }

    //    return recipes;
    //}

    public async Task<IEnumerable<CategoriesApiModel>> GetAllCategories()
    {
        List<CategoriesApiModel> categories = new List<CategoriesApiModel>();

        var url = $"https://www.themealdb.com/api/json/v1/1/list.php";
        var parameters = $"?c=list";

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.GetAsync(parameters).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var categoryList = JsonConvert.DeserializeObject<CategoriesList>(jsonString);

            if (categoryList != null)
            {
                categories.AddRange(categoryList.Categories);
            }
        }

        return categories;
    }

    public async Task<IEnumerable<AreaApiModel>> GetAllAreas()
    {
        List<AreaApiModel> areas = new List<AreaApiModel>();

        var url = $"https://www.themealdb.com/api/json/v1/1/list.php";
        var parameters = $"?a=list";

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.GetAsync(parameters).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var areaList = JsonConvert.DeserializeObject<AreasList>(jsonString);

            if (areaList != null)
            {
                areas.AddRange(areaList.Areas);
            }
        }

        return areas;
    }

    public async Task<IEnumerable<IngredientApiModel>> GetAllIngredients()
    {
        List<IngredientApiModel> ingredients = new List<IngredientApiModel>();

        var url = $"https://www.themealdb.com/api/json/v1/1/list.php";
        var parameters = $"?i=list";

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.GetAsync(parameters).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var ingredientList = JsonConvert.DeserializeObject<IngredientsList>(jsonString);

            if (ingredientList != null)
            {
                ingredients.AddRange(ingredientList.Ingredients);
            }
        }

        return ingredients;
    }
}