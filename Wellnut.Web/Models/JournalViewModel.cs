using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Wellnut.Data.Models;

namespace Wellnut.Web.Models
{
    public class JournalViewModel
    {
        public int UserHistoryId { get; set; }

        public int UserInformationId { get; set; }

        [Display(Name = "Select date:")]
        [Required(ErrorMessage = "Date is required.")]
        public DateTime JournalDate { get; set; }

        [Display(Name = "Serving size (g):")]
        [Required(ErrorMessage = "Serving size is required.")]
        [Range(0, int.MaxValue)]
        public int ServingSize { get; set; }

        [Display(Name = "Food name:")]
        [Required(ErrorMessage = "Food name is required.")]

        public int FoodId { get; set;}
        public string FoodName { get; set; }
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }



    }

}

//public string SearchTerm { get; set; }
//public Food Food { get; set; }
//public UserInformation UserInformation { get; set; }

//public UserHistory UserHistory { get; set; }