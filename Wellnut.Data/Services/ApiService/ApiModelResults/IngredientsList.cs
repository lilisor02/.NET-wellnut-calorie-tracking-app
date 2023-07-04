using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wellnut.Data.Services.ApiService.ApiModels;

namespace Wellnut.Data.Services.ApiService.ApiModelResults
{
    [Serializable]
    public class IngredientsList
    {
        [JsonProperty("meals")]
        public IEnumerable<IngredientApiModel> Ingredients { get; set; }
    }
}
