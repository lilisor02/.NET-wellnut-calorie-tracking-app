using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wellnut.Data.Services.ApiService.ApiModels
{
    [Serializable]
    public class IngredientApiModel
    {
        [JsonProperty("idIngredient")]
        public int IngredientId { get; set; }

        [JsonProperty("strIngredient")]
        public string Ingredient { get; set; }

        [JsonProperty("strDescription")]
        public string IngredientDescription { get; set; }
        
    }
}
