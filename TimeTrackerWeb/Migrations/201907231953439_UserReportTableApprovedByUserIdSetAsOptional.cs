namespace TimeTrackerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserReportTableApprovedByUserIdSetAsOptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserReports", "ApprovedByUserId", "dbo.Users");
            DropIndex("dbo.UserReports", new[] { "ApprovedByUserId" });
            AlterColumn("dbo.UserReports", "ApprovedByUserId", c => c.Int());
            CreateIndex("dbo.UserReports", "ApprovedByUserId");
            AddForeignKey("dbo.UserReports", "ApprovedByUserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserReports", "ApprovedByUserId", "dbo.Users");
            DropIndex("dbo.UserReports", new[] { "ApprovedByUserId" });
            AlterColumn("dbo.UserReports", "ApprovedByUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserReports", "ApprovedByUserId");
            AddForeignKey("dbo.UserReports", "ApprovedByUserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
