using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wellnut.Data.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        public string FoodName { get; set; }

        public int Calories { get; set; }

        public float Protein { get; set; }

        public float Carbs { get; set; }

        public float Fat { get; set; }
    }
}
