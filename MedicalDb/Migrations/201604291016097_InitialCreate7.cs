namespace MedicalDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EntryModels", "Beneficiary_First_Name", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.EntryModels", "Beneficiary_Middle_Name", c => c.String(unicode: false));
            AddColumn("dbo.EntryModels", "Beneficiary_Last_Name", c => c.String(nullable: false, unicode: false));
            DropColumn("dbo.EntryModels", "First_Name");
            DropColumn("dbo.EntryModels", "Middle_Name");
            DropColumn("dbo.EntryModels", "Last_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EntryModels", "Last_Name", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.EntryModels", "Middle_Name", c => c.String(unicode: false));
            AddColumn("dbo.EntryModels", "First_Name", c => c.String(nullable: false, unicode: false));
            DropColumn("dbo.EntryModels", "Beneficiary_Last_Name");
            DropColumn("dbo.EntryModels", "Beneficiary_Middle_Name");
            DropColumn("dbo.EntryModels", "Beneficiary_First_Name");
        }
    }
}
