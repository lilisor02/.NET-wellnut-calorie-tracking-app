using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wellnut.Data.Enums;
using Wellnut.Data.Models;

namespace Wellnut.Data.Services
{
    public interface IUserData
    {
        int addCredentials(string email, string password);
        int addUserInformation(string name, DateTime birthday, Gender gender, double height, double weight, WeightGoal weightGoal, ActivityLevel activityLevel);
        List<Credentials> LoadUsers();
    }
}
