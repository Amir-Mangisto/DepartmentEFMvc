namespace DepartmentEFMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateManagerTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "LastName", c => c.Int(nullable: false));
        }
    }
}
