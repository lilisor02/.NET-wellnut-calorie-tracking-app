using DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wellnut.Data.Enums;
using Wellnut.Data.Models;

namespace Wellnut.Data.Services
{
    public class SqlUserData : IUserData
    {

        private readonly WellnutContext db;

        public SqlUserData(WellnutContext db)
        {
            this.db = db;
        }

        public int addCredentials(string email, string password)
        {
            Credentials data = new Credentials
            {
                Email = email,
                Password = password
            };

            string sql = @"insert into dbo.Credentials (Email, Password) values (@Email, @Password);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public int addUserInformation(string name, DateTime birthday, Gender gender, double height, double weight, WeightGoal weightGoal, ActivityLevel activityLevel)
        {
            List<int> userList = db.Credentials.Select(x => x.CredentialsId).ToList();

            int ultimulId = userList.Last();


            UserInformation data = new UserInformation
            {
                Username = name,
                Birthday = birthday,
                Gender = gender,
                Height = height,
                Weight = weight,
                WeightGoal = weightGoal,
                ActivityLevel = activityLevel,
                CredentialsId = ultimulId
            };

            string sql = @"insert into dbo.UserInformations (Username, Birthday, Gender, Height, Weight, WeightGoal, ActivityLevel, CredentialsId) values (@Username, @Birthday, @Gender, @Height, @Weight, @WeightGoal, @ActivityLevel, @CredentialsId);";

            return SqlDataAccess.SaveData(sql, data);
        }


        public List<Credentials> LoadUsers()
        {
            string sql = @"select Id, Email from dbo.Credentials;";

            return SqlDataAccess.LoadData<Credentials>(sql);
        }
    }
}
