using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wellnut.Data.Enums
{
    public enum WeightGoal
    {
        [Display(Name = "Lose weight")]
        LoseWeight,
        [Display(Name = "Maintain weight")]
        MaintainWeight,
        [Display(Name = "Gain weight")]
        GainWeight
    }
}
