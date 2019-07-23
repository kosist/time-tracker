namespace TimeTrackerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedHoursValuesFromFloatToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserReports", "WorkHours", c => c.Double(nullable: false));
            AlterColumn("dbo.UserReports", "BreakHours", c => c.Double(nullable: false));
            AlterColumn("dbo.UserReports", "TimeDifference", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserReports", "TimeDifference", c => c.Single(nullable: false));
            AlterColumn("dbo.UserReports", "BreakHours", c => c.Single(nullable: false));
            AlterColumn("dbo.UserReports", "WorkHours", c => c.Single(nullable: false));
        }
    }
}
