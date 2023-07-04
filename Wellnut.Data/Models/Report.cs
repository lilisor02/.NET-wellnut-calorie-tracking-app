using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wellnut.Data.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        public string ReportName { get; set; }

        public DateTime ReportDate { get; set; }

        public virtual int UserHistoryId { get; set; }

        public UserHistory UserHistory { get; set; }

        public virtual int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }

        public virtual int UserInformationId { get; set; }

        public UserInformation UserInformation { get; set; }
    }
}
