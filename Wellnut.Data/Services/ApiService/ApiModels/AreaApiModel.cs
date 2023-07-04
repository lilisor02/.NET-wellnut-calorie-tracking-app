using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wellnut.Data.Services.ApiService.ApiModels
{
    [Serializable]
    public class AreaApiModel
    {
        [JsonProperty("strArea")]
        public string Area { get; set; }
    }
}
