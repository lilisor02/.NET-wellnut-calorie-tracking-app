namespace Wellnut.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserHistories", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.UserHistories", "UserInformationId", "dbo.UserInformations");
            DropIndex("dbo.UserHistories", new[] { "RecipeId" });
            DropIndex("dbo.UserHistories", new[] { "UserInformationId" });
            AlterColumn("dbo.UserHistories", "RecipeId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserHistories", "RecipeId", c => c.Int(nullable: true));
            CreateIndex("dbo.UserHistories", "UserInformationId");
            CreateIndex("dbo.UserHistories", "RecipeId");
            AddForeignKey("dbo.UserHistories", "UserInformationId", "dbo.UserInformations", "UserInformationId", cascadeDelete: false);
            AddForeignKey("dbo.UserHistories", "RecipeId", "dbo.Recipes", "RecipeId", cascadeDelete: false);
        }
    }
}
