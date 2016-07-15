namespace MedicalDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EntryModels", "Principal_First_Name", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.EntryModels", "Principal_Middle_Name", c => c.String(unicode: false));
            AddColumn("dbo.EntryModels", "Principal_Last_Name", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.EntryModels", "insurance_companyname", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.EntryModels", "policy", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EntryModels", "policy");
            DropColumn("dbo.EntryModels", "insurance_companyname");
            DropColumn("dbo.EntryModels", "Principal_Last_Name");
            DropColumn("dbo.EntryModels", "Principal_Middle_Name");
            DropColumn("dbo.EntryModels", "Principal_First_Name");
        }
    }
}
