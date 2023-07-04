namespace Wellnut.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        CredentialsId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.CredentialsId);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ExerciseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duration = c.Int(nullable: false),
                        Description = c.String(),
                        BurnedCalories = c.Int(nullable: false),
                        UserInformationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExerciseId)
                .ForeignKey("dbo.UserInformations", t => t.UserInformationId, cascadeDelete: true)
                .Index(t => t.UserInformationId);
            
            CreateTable(
                "dbo.UserInformations",
                c => new
                    {
                        UserInformationId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        ProfilePicture = c.String(),
                        Gender = c.Int(nullable: false),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        WeightGoal = c.Int(nullable: false),
                        ActivityLevel = c.Int(nullable: false),
                        CredentialsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserInformationId)
                .ForeignKey("dbo.Credentials", t => t.CredentialsId, cascadeDelete: true)
                .Index(t => t.CredentialsId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        FoodName = c.String(),
                        Calories = c.Int(nullable: false),
                        Protein = c.Single(nullable: false),
                        Carbs = c.Single(nullable: false),
                        Fat = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        RecipeName = c.String(),
                        ServingSize = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                        UserInformationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeId)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.UserInformations", t => t.UserInformationId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.UserInformationId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        ReportName = c.String(),
                        ReportDate = c.DateTime(nullable: false),
                        UserHistoryId = c.Int(nullable: false),
                        ExerciseId = c.Int(nullable: false),
                        UserInformationId = c.Int(),
                    })
                .PrimaryKey(t => t.ReportId)
                .ForeignKey("dbo.Exercises", t => t.ExerciseId, cascadeDelete: true)
                .ForeignKey("dbo.UserHistories", t => t.UserHistoryId, cascadeDelete: true)
                .ForeignKey("dbo.UserInformations", t => t.UserInformationId)
                .Index(t => t.UserHistoryId)
                .Index(t => t.ExerciseId)
                .Index(t => t.UserInformationId);
            
            CreateTable(
                "dbo.UserHistories",
                c => new
                    {
                        UserHistoryId = c.Int(nullable: false, identity: true),
                        JournalDate = c.DateTime(nullable: false),
                        ServingSize = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                        UserInformationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserHistoryId)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.UserInformations", t => t.UserInformationId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.RecipeId)
                .Index(t => t.UserInformationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "UserInformationId", "dbo.UserInformations");
            DropForeignKey("dbo.Reports", "UserHistoryId", "dbo.UserHistories");
            DropForeignKey("dbo.UserHistories", "UserInformationId", "dbo.UserInformations");
            DropForeignKey("dbo.UserHistories", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.UserHistories", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Reports", "ExerciseId", "dbo.Exercises");
            DropForeignKey("dbo.Recipes", "UserInformationId", "dbo.UserInformations");
            DropForeignKey("dbo.Recipes", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Exercises", "UserInformationId", "dbo.UserInformations");
            DropForeignKey("dbo.UserInformations", "CredentialsId", "dbo.Credentials");
            DropIndex("dbo.UserHistories", new[] { "UserInformationId" });
            DropIndex("dbo.UserHistories", new[] { "RecipeId" });
            DropIndex("dbo.UserHistories", new[] { "FoodId" });
            DropIndex("dbo.Reports", new[] { "UserInformationId" });
            DropIndex("dbo.Reports", new[] { "ExerciseId" });
            DropIndex("dbo.Reports", new[] { "UserHistoryId" });
            DropIndex("dbo.Recipes", new[] { "UserInformationId" });
            DropIndex("dbo.Recipes", new[] { "FoodId" });
            DropIndex("dbo.UserInformations", new[] { "CredentialsId" });
            DropIndex("dbo.Exercises", new[] { "UserInformationId" });
            DropTable("dbo.UserHistories");
            DropTable("dbo.Reports");
            DropTable("dbo.Recipes");
            DropTable("dbo.Foods");
            DropTable("dbo.UserInformations");
            DropTable("dbo.Exercises");
            DropTable("dbo.Credentials");
        }
    }
}
