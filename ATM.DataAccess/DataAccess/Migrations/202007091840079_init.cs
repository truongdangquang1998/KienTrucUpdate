namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "IdCard", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "IdCard");
        }
    }
}
