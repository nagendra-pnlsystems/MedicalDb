namespace MedicalDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate17 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EntryModels", "DOB", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EntryModels", "DOB", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}
