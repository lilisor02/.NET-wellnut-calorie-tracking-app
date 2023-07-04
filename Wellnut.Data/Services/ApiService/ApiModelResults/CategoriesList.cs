using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wellnut.Data
{
    [Serializable]
    public class CategoriesList
    {
        [JsonProperty("meals")]
        public IEnumerable<CategoriesApiModel> Categories { get; set; }
    }
}
