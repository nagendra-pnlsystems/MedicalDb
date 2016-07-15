namespace MedicalDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EntryModels", "PhoneNumber", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EntryModels", "PhoneNumber");
        }
    }
}
