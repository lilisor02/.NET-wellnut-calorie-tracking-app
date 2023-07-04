using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Wellnut.Data;
using Wellnut.Data.Enums;

namespace Wellnut.Web.Models
{
    public class SurveyViewModel
    {
        public int UserInformationId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "What is your name?")]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Birthday is required.")]
        [Display(Name = "Please select your birthday:")]
        public DateTime Birthday { get; set; }
        public string ProfilePicture { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [Display(Name = "Please select your gender:")]
        [MaxLength(1)]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Height is required.")]
        [Display(Name = "How tall are you? (cm)")]
        [MaxLength(4)]
        public double Height { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        [Display(Name = "How much do you weight? (kg)")]
        [MaxLength(4)]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Weight goal is required.")]
        [Display(Name = "What is your weight goal?")]
        [MaxLength(50)]
        public WeightGoal WeightGoal { get; set; }

        [Required(ErrorMessage = "Baseline activity level is required.")]
        [Display(Name = "What is your baseline activity level?")]
        [MaxLength(50)]
        public ActivityLevel ActivityLevel { get; set; }
    }
}