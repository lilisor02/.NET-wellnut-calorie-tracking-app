using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wellnut.Data.Enums
{
    public enum ActivityLevel
    {
        [Display(Name = "Not active")]
        NotActive,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "Very active")]
        VeryActive
    }
}
