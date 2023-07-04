using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wellnut.Data
{
    public enum Gender
    {
        [Display(Name = "M")]
        M,
        [Display(Name = "F")]
        F
    }
}
