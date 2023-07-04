using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Wellnut.Data.Enums;
using Wellnut.Data.Models;

namespace Wellnut.Web.Models
{
    public class ReportViewModel
    {
        public int ReportId { get; set; }

        [Display(Name = "Name:")]
        public string ReportName { get; set; }

        [Display(Name = "Start date:")]
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime ReportStartDate { get; set; }

        [Display(Name = "End date:")]
        [Required(ErrorMessage = "End date is required.")]
        public DateTime ReportEndDate { get; set; }

        //public DateTime ReportDate { get; set; }

        [Display(Name = "Report type:")]
        public ReportType ReportType { get; set; }

        public virtual int UserHistoryId { get; set; }

        public UserHistory UserHistory { get; set; }

        public virtual int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }

        public virtual int UserInformationId { get; set; }

        public UserInformation UserInformation { get; set; }
    }
}