namespace TimeTrackerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTimeRecordsCollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeRecords", "UserReportDb_Id", c => c.Int());
            CreateIndex("dbo.TimeRecords", "UserReportDb_Id");
            AddForeignKey("dbo.TimeRecords", "UserReportDb_Id", "dbo.UserReports", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeRecords", "UserReportDb_Id", "dbo.UserReports");
            DropIndex("dbo.TimeRecords", new[] { "UserReportDb_Id" });
            DropColumn("dbo.TimeRecords", "UserReportDb_Id");
        }
    }
}
