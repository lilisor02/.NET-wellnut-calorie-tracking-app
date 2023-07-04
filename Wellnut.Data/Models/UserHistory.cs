using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wellnut.Data.Models;

namespace Wellnut.Data.Models
{
    public class UserHistory
    {
        [Key]
        public int UserHistoryId { get; set; }

        public DateTime JournalDate { get; set; }

        public int ServingSize { get; set; }

        public virtual int FoodId { get; set; }

        public virtual int UserInformationId { get; set; }

        public Food Food { get; set; }

        public virtual int? RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public UserInformation UserInformation { get; set; }

    }
}



