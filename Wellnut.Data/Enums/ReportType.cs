using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wellnut.Data.Enums
{
    public enum ReportType
    {
        //[Display(Name = "Weigh Loss Report")]
        //Weight_loss,
        [Display(Name = "Calorie Intake Report")]
        Calorie_intake,
        [Display(Name = "Protein Intake Report")]
        Protein_intake,
        [Display(Name = "Fat Intake Report")]
        Fat_intake,
        [Display(Name = "Carbohydrates Intake Report")]
        Carbs_intake
    }
}
