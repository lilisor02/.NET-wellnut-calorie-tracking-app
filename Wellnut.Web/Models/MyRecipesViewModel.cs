using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Wellnut.Web.Models
{
    public class MyRecipesViewModel
    {
        public int RecipeId { get; set; }

        public int UserInformationId { get; set; }

        public string RecipeName { get; set; }


        [Display(Name = "Serving size (g):")]
        [Required(ErrorMessage = "Serving size is required.")]
        [Range(0, int.MaxValue)]
        public int ServingSize { get; set; }

        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
    }
}