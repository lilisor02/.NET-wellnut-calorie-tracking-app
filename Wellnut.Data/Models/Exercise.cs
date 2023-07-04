using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wellnut.Data.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public string Description { get; set; }

        public int BurnedCalories { get; set; }

        public virtual int UserInformationId { get; set; }

        public UserInformation UserInformation { get; set; }
    }
}
