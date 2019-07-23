namespace TimeTrackerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedIntoBreakDurationHoursAndChangedToFloatType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "BreakDurationHours", c => c.Single(nullable: false));
            DropColumn("dbo.Users", "BreakDurationInMinutes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "BreakDurationInMinutes", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "BreakDurationHours");
        }
    }
}
