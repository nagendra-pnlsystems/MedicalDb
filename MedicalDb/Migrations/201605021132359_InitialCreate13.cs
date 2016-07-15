namespace MedicalDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EntryModels", "Visa", c => c.String(unicode: false));
            AddColumn("dbo.EntryModels", "Emirates_id_copy", c => c.String(unicode: false));
            AddColumn("dbo.EntryModels", "other_documents", c => c.String(unicode: false));
            DropColumn("dbo.EntryModels", "id_copy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EntryModels", "id_copy", c => c.String(unicode: false));
            DropColumn("dbo.EntryModels", "other_documents");
            DropColumn("dbo.EntryModels", "Emirates_id_copy");
            DropColumn("dbo.EntryModels", "Visa");
        }
    }
}
