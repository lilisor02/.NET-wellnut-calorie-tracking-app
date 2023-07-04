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
    public class AreasList
    {
        [JsonProperty("meals")]
        public IEnumerable<AreaApiModel> Areas { get; set; }
    }

}
