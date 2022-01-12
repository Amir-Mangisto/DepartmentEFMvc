namespace DepartmentEFMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEmployeesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.Int(nullable: false),
                        Department = c.String(),
                        Salary = c.Int(nullable: false),
                        Seniority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
