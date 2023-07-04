using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Wellnut.Data.Enums;
using Wellnut.Data;

namespace Wellnut.Web.Models
{
    public class AccountViewModel
    {
        public int UserInformationId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid email adress.")]

        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Birthday is required.")]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
        public string ProfilePicture { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [Display(Name = "Gender")]
        [MaxLength(1)]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Height is required.")]
        [Display(Name = "Height (cm)")]
        [MaxLength(4)]
        public double Height { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        [Display(Name = "Weight (kg)")]
        [MaxLength(4)]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Weight goal is required.")]
        [Display(Name = "Weight goal")]
        [MaxLength(50)]
        public WeightGoal WeightGoal { get; set; }

        [Required(ErrorMessage = "Baseline activity level is required.")]
        [Display(Name = "Baseline activity level")]
        [MaxLength(50)]
        public ActivityLevel ActivityLevel { get; set; }
    }
}