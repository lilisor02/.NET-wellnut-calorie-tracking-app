using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wellnut.Data
{
    [Serializable]
    public class RecipeApiModel
    {

        [JsonProperty("strMeal")]
        public string Title { get; set; }


        [JsonProperty("strMealThumb")]
        public string Picture { get; set; }

        [JsonProperty("idMeal")]
        public int Id { get; set; }

        [JsonProperty("strInstructions")]
        public string Instructions { get; set; }

        [JsonProperty("strTags")]
        public string Tags { get; set; }

        //[JsonProperty("strIngredient")]
        //public string Ingredient { get; set; }

    }
}
