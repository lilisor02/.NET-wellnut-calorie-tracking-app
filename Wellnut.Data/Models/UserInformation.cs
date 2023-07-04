using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wellnut.Data.Enums;

namespace Wellnut.Data.Models
{
    public class UserInformation
    {
        [Key]
        public int UserInformationId { get; set; }

        public string Username { get; set; }

        public DateTime Birthday { get; set; }

        public string ProfilePicture { get; set; }

        public Gender Gender { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public WeightGoal WeightGoal { get; set; }

        public ActivityLevel ActivityLevel { get; set; }

        public virtual int CredentialsId { get; set; }

        public Credentials Credentials { get; set; }

    }
}
