namespace TimeTrackerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredAnnotationForLookupTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ActivityTypes", "Name", c => c.String());
            AlterColumn("dbo.Departments", "Name", c => c.String());
            AlterColumn("dbo.Positions", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Positions", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ActivityTypes", "Name", c => c.String(nullable: false));
        }
    }
}
