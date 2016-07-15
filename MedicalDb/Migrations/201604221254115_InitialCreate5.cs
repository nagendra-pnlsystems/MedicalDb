namespace MedicalDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EntryModels", "Middle_Name", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EntryModels", "Middle_Name", c => c.String(nullable: false, unicode: false));
        }
    }
}
