namespace TimeTrackerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTimeRecordsFromUserReportTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TimeRecords", "UserReportDb_Id", "dbo.UserReports");
            DropIndex("dbo.TimeRecords", new[] { "UserReportDb_Id" });
            DropColumn("dbo.TimeRecords", "UserReportDb_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeRecords", "UserReportDb_Id", c => c.Int());
            CreateIndex("dbo.TimeRecords", "UserReportDb_Id");
            AddForeignKey("dbo.TimeRecords", "UserReportDb_Id", "dbo.UserReports", "Id");
        }
    }
}
