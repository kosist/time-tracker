using System.Data.SqlClient;

namespace DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Common.Tables;
    
    public partial class SetDefaultTablesData : DbMigration
    {
        public override void Up()
        {
            // update Departments table
            Sql("INSERT INTO Departments VALUES ('BackOffice')");
            Sql("INSERT INTO Departments VALUES ('Software Department')");
            Sql("INSERT INTO Departments VALUES ('Electrical Engineering Department')");
            Sql("INSERT INTO Departments VALUES ('Mechanical Engineering Department')");
            Sql("INSERT INTO Departments VALUES ('Sales Department')");
            Sql("INSERT INTO Departments VALUES ('HR Department')");

            // update ActivityTypes table
            Sql($"INSERT INTO ActivityTypes VALUES ('{Activities.Break.ToString()}')");
            Sql($"INSERT INTO ActivityTypes VALUES ('{Activities.StartWork.ToString()}')");
            Sql($"INSERT INTO ActivityTypes VALUES ('{Activities.StopWork.ToString()}')");

            // update Positions table
            Sql("INSERT INTO Positions VALUES ('CEO')");
            Sql("INSERT INTO Positions VALUES ('Team Lead')");
            Sql("INSERT INTO Positions VALUES ('Engineer')");
            Sql("INSERT INTO Positions VALUES ('Technician')");
            Sql("INSERT INTO Positions VALUES ('Intern')");
            Sql("INSERT INTO Positions VALUES ('Office Manager')");
            Sql("INSERT INTO Positions VALUES ('HR Manager')");
            Sql("INSERT INTO Positions VALUES ('Sales Representative')");
        }
        
        public override void Down()
        {
            Sql("DROP Departments");
            Sql("DROP ActivityTypes");
            Sql("DROP Positions");
        }
    }
}
