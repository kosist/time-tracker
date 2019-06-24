namespace DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTablesCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RecordTime = c.DateTime(nullable: false),
                        ActivityTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityTypes", t => t.ActivityTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ActivityTypeId);
            
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                        NumberOfWorkingDaysPerWeek = c.Int(nullable: false),
                        NumberOfDailyWorkHours = c.Single(nullable: false),
                        BreakDurationInMinutes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        WorkHours = c.Single(nullable: false),
                        BreakHours = c.Single(nullable: false),
                        TimeDifference = c.Single(nullable: false),
                        TimeDifferenceReason = c.String(),
                        ApprovedByUserId = c.Int(nullable: false),
                        ApprovedFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApprovedByUserId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.ApprovedByUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserReports", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserReports", "ApprovedByUserId", "dbo.Users");
            DropForeignKey("dbo.TimeRecords", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.TimeRecords", "ActivityTypeId", "dbo.ActivityTypes");
            DropIndex("dbo.UserReports", new[] { "ApprovedByUserId" });
            DropIndex("dbo.UserReports", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "PositionId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropIndex("dbo.TimeRecords", new[] { "ActivityTypeId" });
            DropIndex("dbo.TimeRecords", new[] { "UserId" });
            DropTable("dbo.UserReports");
            DropTable("dbo.Positions");
            DropTable("dbo.Departments");
            DropTable("dbo.Users");
            DropTable("dbo.ActivityTypes");
            DropTable("dbo.TimeRecords");
        }
    }
}
