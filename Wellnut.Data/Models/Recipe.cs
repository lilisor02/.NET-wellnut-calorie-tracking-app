using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wellnut.Data.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        public string RecipeName { get; set; }

        public int ServingSize { get; set; }

        public virtual int FoodId { get; set; }

        public Food Ingredient { get; set; }

        public virtual int UserInformationId { get; set; }

        public UserInformation UserInformation { get; set; }
    }
}
